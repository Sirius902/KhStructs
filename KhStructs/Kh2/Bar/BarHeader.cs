using System.Collections.Immutable;

namespace KhStructs.Kh2.Bar;

// size=0x10
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BarHeader {
    public fixed byte Magic[4];
    public uint SubfileCount;
    public uint LookupAddress;
    public MsetType MsetType;

    public static readonly ImmutableArray<byte> ExpectedMagic = ImmutableArray.Create<byte>(0x01, 0x52, 0x41, 0x42);
}
