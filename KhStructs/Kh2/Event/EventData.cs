namespace KhStructs.Kh2.Event;

// size=variable
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct EventData {
    [FieldOffset(0x09)] public byte Byte9;

    [FixedString("Name")] [FieldOffset(0x0A)]
    public fixed byte NameBytes[0x20];
}
