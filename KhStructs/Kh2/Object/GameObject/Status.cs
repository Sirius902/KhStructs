namespace KhStructs.Kh2.Object.GameObject;

// TODO: Status is definitely larger than this.
// size=???
[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public struct Status {
    [FieldOffset(0x00)] public int Hp;
    [FieldOffset(0x04)] public int MaxHp;
    [FieldOffset(0x08)] public int MinHp;
}
