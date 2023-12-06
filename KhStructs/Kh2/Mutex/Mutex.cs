using KhStructs.Util;

namespace KhStructs.Kh2.Mutex;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Mutex {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 80 7B 14 00", 3, isPointer: false)]
    public static partial Mutex* LimitInstance();

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 B0", 3, isPointer: false)]
    public static partial Mutex* PauseMenuInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 40 38 77 14")]
    public partial void Lock(byte id);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 3B C3")]
    public partial void Unlock(byte id);

    [MemberFunction("44 8B 01 85 D2")]
    public partial Bool8 IsLocked(byte id);
}
