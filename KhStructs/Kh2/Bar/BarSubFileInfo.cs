namespace KhStructs.Kh2.Bar;

// size=0x10
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BarSubFileInfo {
    public SubFileType SubFileType;
    public ushort DuplicateFlag;
    [FixedString("SubFileName")]
    public fixed byte SubFileNameBytes[4];
    public Hash SubFileHash;
    public uint SubFileSize;
}
