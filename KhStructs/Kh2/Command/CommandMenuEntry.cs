namespace KhStructs.Kh2.Command;

[StructLayout(LayoutKind.Sequential)]
public struct CommandMenuEntry {
    public short Word0;
    public ushort CommandId;
    public byte SideDisplay;
    public byte Usability;
    public byte Index;
    public Hash Hash8;
}
