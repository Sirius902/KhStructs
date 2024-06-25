namespace KhStructs.Axa;

// Axa::PADDATA

// size=0x44
[StructLayout(LayoutKind.Explicit, Size = 0x44)]
public struct PadData {
    [FieldOffset(0x00)] public PadButtons Buttons;
    [FieldOffset(0x02)] public byte RightStickX;
    [FieldOffset(0x03)] public byte RightStickY;
    [FieldOffset(0x04)] public byte LeftStickX;
    [FieldOffset(0x05)] public byte LeftStickY;
}
