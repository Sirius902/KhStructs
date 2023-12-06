namespace KhStructs.Kh2.Bar;

// size=0x78
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct BarTableEntry {
    [FieldOffset(0x00)] public BarTableEntryTag Tag;
    [FieldOffset(0x01)] public BarTableEntryStatus Status;
    [FieldOffset(0x02)] public short RefCount;

    [FixedString("FileName")]
    [FieldOffset(0x04)] public fixed byte FileNameBytes[0x20];

    [FieldOffset(0x44)] public int Flags44;
    [FieldOffset(0x48)] public int Priority;
    [FieldOffset(0x4C)] public int Int4C;
    [FieldOffset(0x50)] public nuint FileSize;
    [FieldOffset(0x58)] public BarFile* BarFile;
    [FieldOffset(0x60)] public BarFile* LoadedBarFile;

    [FieldOffset(0x68)] public short Bank;
    [FieldOffset(0x6A)] public short Word6A;

    // TypedHash<BarTableEntry>
    [FieldOffset(0x70)] public Hash NextHash;

    public BarTableEntry* Next => (BarTableEntry*)Hash.Lookup(this.NextHash);

    [MemberFunction("E8 ?? ?? ?? ?? EB A3")]
    public partial void Flush();

    [MemberFunction("48 85 D2 74 08 49 8B C8")]
    public static partial void ReadCallback(void* bar, nuint size, void* self);
}

public enum BarTableEntryTag : byte {
    Type0 = 0,
    Localization = 1,
    Type2 = 2,
}

public enum BarTableEntryStatus : byte {
    None = 0,
    Reading = 1,
    Status2 = 2,
    Ready = 3,
}
