namespace KhStructs.Kh2.Script;

// size=0x10
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ScriptFileHeader {
    [FixedString("Name")]
    public fixed byte NameBytes[0x10];
    public int HeapSize;
    public int FramesSize;
    public int StackSize;
}
