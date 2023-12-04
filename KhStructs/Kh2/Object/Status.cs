namespace KhStructs.Kh2.Object;

// TODO: Status is definitely larger than this and also an array.
// size=???
[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public struct Status {
    [FieldOffset(0x00)] public int Hp;
    [FieldOffset(0x04)] public int MaxHp;
    [FieldOffset(0x08)] public int MinHp;
}
