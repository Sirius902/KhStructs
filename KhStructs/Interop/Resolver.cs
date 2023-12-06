using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KhStructs.Interop;

public sealed partial class Resolver {
    private static readonly Lazy<Resolver> Instance = new(() => new Resolver());

    private static readonly Dictionary<SupportedGame, string> GameNamespaces = new() {
        [SupportedGame.Kh1] = $"{nameof(KhStructs)}.{nameof(Kh1)}",
        [SupportedGame.Kh2] = $"{nameof(KhStructs)}.{nameof(Kh2)}",
        [SupportedGame.ReCom] = $"{nameof(KhStructs)}.{nameof(ReCom)}",
        [SupportedGame.Bbs] = $"{nameof(KhStructs)}.{nameof(Bbs)}",
        [SupportedGame.Ddd] = $"{nameof(KhStructs)}.{nameof(Ddd)}",
    };

    private Resolver() {
    }

    public static Resolver GetInstance => Instance.Value;

    private readonly List<Address>?[] preResolveArray = new List<Address>[256];
    private int totalBuckets;

    private readonly List<Address> addresses = new();
    public IReadOnlyList<Address> Addresses => this.addresses.AsReadOnly();

    private ConcurrentDictionary<string, long>? textCache;
    private FileInfo? cacheFile;
    private bool cacheChanged;

    private nint baseAddress;

    private nint targetSpace;
    private int targetLength;

    private int textSectionOffset;
    private int textSectionSize;
    private int dataSectionOffset;
    private int dataSectionSize;
    private int rdataSectionOffset;
    private int rdataSectionSize;

    private bool hasResolved;
    private bool isSetup;

    public void SetupSearchSpace(nint moduleCopy = 0, FileInfo? cacheFile = null) {
        if (this.isSetup) return;
        var module = Process.GetCurrentProcess().MainModule;
        if (module == null)
            throw new Exception("[KhStructs.Resolver] Unable to access process module.");

        this.baseAddress = module.BaseAddress;

        this.targetSpace = moduleCopy == 0 ? this.baseAddress : moduleCopy;
        this.targetLength = module.ModuleMemorySize;

        this.cacheFile = cacheFile;
        if (this.cacheFile is not null) this.LoadCache();

        this.SetupSections();
        this.isSetup = true;
    }

    public void SetupSearchSpace(nint memoryPointer, int memorySize, int textSectionOffset, int textSectionSize,
        int dataSectionOffset, int dataSectionSize, int rdataSectionOffset, int rdataSectionSize,
        FileInfo? cacheFile = null) {
        if (this.isSetup) return;
        this.baseAddress = memoryPointer;
        this.targetSpace = memoryPointer;
        this.targetLength = memorySize;
        this.textSectionOffset = textSectionOffset;
        this.textSectionSize = textSectionSize;
        this.dataSectionOffset = dataSectionOffset;
        this.dataSectionSize = dataSectionSize;
        this.rdataSectionOffset = rdataSectionOffset;
        this.rdataSectionSize = rdataSectionSize;

        this.cacheFile = cacheFile;
        if (this.cacheFile is not null) this.LoadCache();
        this.isSetup = true;
    }

    // adapted from Dalamud SigScanner
    private unsafe void SetupSections() {
        var baseAddress = new ReadOnlySpan<byte>(this.baseAddress.ToPointer(), this.targetLength);

        // We don't want to read all of IMAGE_DOS_HEADER or IMAGE_NT_HEADER stuff so we cheat here.
        var ntNewOffset = BitConverter.ToInt32(baseAddress.Slice(0x3C, 4));
        var ntHeader = baseAddress[ntNewOffset..];

        // IMAGE_NT_HEADER
        var fileHeader = ntHeader[4..];
        var numSections = BitConverter.ToInt16(ntHeader.Slice(6, 2));

        // IMAGE_OPTIONAL_HEADER
        var optionalHeader = fileHeader[20..];

        var sectionHeader = optionalHeader[240..]; // IMAGE_OPTIONAL_HEADER64

        // IMAGE_SECTION_HEADER
        var sectionCursor = sectionHeader;
        for (var i = 0; i < numSections; i++) {
            var sectionName = BitConverter.ToInt64(sectionCursor);

            // .text
            switch (sectionName) {
                case 0x747865742E: // .text
                    this.textSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    this.textSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
                case 0x617461642E: // .data
                    this.dataSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    this.dataSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
                case 0x61746164722E: // .rdata
                    this.rdataSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    this.rdataSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
            }

            sectionCursor = sectionCursor[40..]; // advance by 40
        }
    }

    private void LoadCache() {
        if (this.cacheFile is not { Exists: true }) {
            this.textCache = new ConcurrentDictionary<string, long>();
            return;
        }

        try {
            var json = File.ReadAllText(this.cacheFile.FullName);
            this.textCache =
                JsonSerializer.Deserialize(json, ResolverJsonContext.Default.ConcurrentDictionaryStringInt64) ??
                new ConcurrentDictionary<string, long>();
        } catch {
            this.textCache = new ConcurrentDictionary<string, long>();
        }
    }

    private void SaveCache() {
        if (this.cacheFile == null || this.textCache == null || this.cacheChanged == false)
            return;
        var json = JsonSerializer.Serialize(this.textCache,
            ResolverJsonContext.Default.ConcurrentDictionaryStringInt64);
        if (string.IsNullOrWhiteSpace(json))
            return;
        if (this.cacheFile.Directory is { Exists: false })
            Directory.CreateDirectory(this.cacheFile.Directory.FullName);
        File.WriteAllText(this.cacheFile.FullName, json);
    }

    private bool ResolveFromCache() {
        foreach (var address in this.addresses) {
            if (!this.textCache!.TryGetValue(address.CacheKey, out var offset)) continue;

            address.Value = (nuint)(offset + this.baseAddress);
            var firstByte = (byte)address.Bytes[0];
            this.preResolveArray[firstByte]!.Remove(address);

            if (this.preResolveArray[firstByte]!.Count != 0) continue;

            this.preResolveArray[firstByte] = null;
            this.totalBuckets--;
        }

        return this.addresses.All(a => a.Value != 0);
    }

    // This function is a bit messy, but everything to make it cleaner is slower, so don't bother.
    public unsafe void Resolve(SupportedGame game) {
        if (this.hasResolved)
            return;

        if (this.targetSpace == 0)
            throw new Exception(
                "[KhStructs.Resolver] Attempted to call Resolve() without initializing the search space.");

        if (this.textCache is not null) {
            if (this.ResolveFromCache())
                return;
        }

        var targetSpan =
            new ReadOnlySpan<byte>(this.targetSpace.ToPointer(), this.targetLength)[this.textSectionOffset..];

        for (var location = 0; location < this.textSectionSize; location++) {
            if (this.preResolveArray[targetSpan[location]] is null) continue;

            var availableAddresses = this.preResolveArray[targetSpan[location]]!.ToArray();
            var targetLocationAsUlong = MemoryMarshal.Cast<byte, ulong>(targetSpan[location..]);
            var avLen = availableAddresses.Length;

            for (var i = 0; i < avLen; i++) {
                var address = availableAddresses[i];

                // TODO: This is probably very slow, possibly fix by putting addresses into categories based on namespace.
                if (!AddressIsForGame(address, game)) continue;

                int count;
                var length = address.Bytes.Length;

                for (count = 0; count < length; count++) {
                    if ((address.Mask[count] & address.Bytes[count]) !=
                        (address.Mask[count] & targetLocationAsUlong[count]))
                        break;
                }

                if (count != length) continue;

                var outLocation = location;

                var firstByte = (byte)address.Bytes[0];
                if (firstByte is 0xE8 or 0xE9) {
                    var jumpOffset = BitConverter.ToInt32(targetSpan.Slice(outLocation + 1, 4));
                    outLocation = outLocation + 5 + jumpOffset;
                }

                if (address is StaticAddress staticAddress) {
                    int accessOffset =
                        BitConverter.ToInt32(targetSpan.Slice(outLocation + staticAddress.Offset, 4));
                    outLocation = outLocation + staticAddress.Offset + staticAddress.InstructionSize + accessOffset;
                }

                address.Value = (nuint)(this.baseAddress + this.textSectionOffset + outLocation);

                if (this.textCache?.TryAdd(address.CacheKey, outLocation + this.textSectionOffset) == true)
                    this.cacheChanged = true;

                this.preResolveArray[targetSpan[location]]!.Remove(address);

                if (this.preResolveArray[targetSpan[location]]!.Count != 0) continue;

                this.preResolveArray[targetSpan[location]] = null;
                this.totalBuckets--;
                if (this.totalBuckets == 0)
                    goto outLoop;
            }
        }

        outLoop: ;

        this.SaveCache();
        this.hasResolved = true;
    }

    private static bool AddressIsForGame(Address address, SupportedGame game) {
        using var iterator = GameNamespaces.GetEnumerator();
        while (iterator.MoveNext()) {
            if (!address.Namespace.StartsWith(iterator.Current.Value)) continue;
            if (iterator.Current.Key != game) {
                return false;
            }

            break;
        }

        return true;
    }

    private void RegisterAddress(Address address) {
        this.addresses.Add(address);

        var firstByte = (byte)(address.Bytes[0]);

        if (this.preResolveArray[firstByte] is null) {
            this.preResolveArray[firstByte] = new List<Address>();
            this.totalBuckets++;
        }

        this.preResolveArray[firstByte]!.Add(address);
    }

    [JsonSerializable(typeof(ConcurrentDictionary<string, long>))]
    [JsonSourceGenerationOptions(WriteIndented = true)]
    private partial class ResolverJsonContext : JsonSerializerContext {
    }
}
