namespace KhStructs.Kh2.Bar;

// size=0x10
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BarEntry {
    public SubfileType SubfileType;
    public ushort DuplicateFlag;
    [FixedString("SubfileName")]
    public fixed byte SubfileNameBytes[4];
    public uint SubfileOffset;
    public uint SubfileSize;
}
