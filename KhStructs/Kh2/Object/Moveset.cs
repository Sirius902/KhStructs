namespace KhStructs.Kh2.Object;

// size=0x28
[StructLayout(LayoutKind.Sequential, Size = 0x30)]
public unsafe partial struct Moveset {
    public float WalkSpeed;
    public float RunSpeed;
    public float JumpHeight;
    public float TurnSpeed;
    public float TerminalVelocity;
    public float Float14;
    public float Acceleration;
    public void* PVoid20;
    public void* PVoid28;

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 48 89 43 28 48 89 43 20")]
    public partial void Apply(int neoMoveset);
}
