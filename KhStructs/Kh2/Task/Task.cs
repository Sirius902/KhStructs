namespace KhStructs.Kh2.Task;

// TASK

// size=0x98
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct Task {
    [FieldOffset(0x00)] public delegate* unmanaged[Stdcall]<Task*, void> Run;

    [FieldOffset(0x18)] public void* UserData;

    [FieldOffset(0x58)] public TaskManager* TaskManager;
    [FieldOffset(0x60)] public int Mask;
    [FieldOffset(0x64)] public int Priority;
    [FieldOffset(0x68)] public delegate* unmanaged[Stdcall]<Task*, void> Finish;
    [FieldOffset(0x70)] public void* PFiber70;
    [FieldOffset(0x78)] public Task* Next;
    [FieldOffset(0x80)] public Task* Previous;
    [FieldOffset(0x88)] public nint QWord88;
    [FieldOffset(0x90)] public nint QWord90;

    [MemberFunction("E8 ?? ?? ?? ?? EB 91")]
    public partial void SleepInt(int duration);

    [MemberFunction("48 8B 41 70 F3 0F 5C 0D ?? ?? ?? ??")]
    public partial void SleepFloat(float duration);

    [MemberFunction("48 C7 01 ?? ?? ?? ?? C3")]
    public partial void Invalidate();
}
