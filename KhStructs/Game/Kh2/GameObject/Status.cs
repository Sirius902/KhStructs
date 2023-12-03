namespace KhStructs.Game.Kh2.GameObject;

// TODO: Status is definitely larger than this.
// size=???
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct Status {
    [FieldOffset(0x00)] public int Hp;
    [FieldOffset(0x08)] public int MaxHp;
}
