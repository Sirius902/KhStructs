using KhStructs.Kh2.Object;
using KhStructs.Util;

namespace KhStructs.Kh2.Event;

[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct Event {
    [FieldOffset(0x08)] public EventData* Data;

    [FieldOffset(0x50)] public EventStruct50 Struct50;

    [StaticAddress("48 8B 3D ?? ?? ?? ?? 33 F6 48 85 FF", 3, isPointer: true)]
    public static partial Event* Current();

    [StaticAddress("88 05 ?? ?? ?? ?? 89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ??", 8, isPointer: false)]
    public static partial int* Status();

    [MemberFunction("E8 ?? ?? ?? ?? B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ??")]
    public static partial void Start(Event* ev);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F 38 48 8B 9C 24 ?? ?? ?? ??")]
    public static partial Bool8 IsPlaying();
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EventStruct50 {
    public int Dword0;
    public GameObject* gameObject;
}
