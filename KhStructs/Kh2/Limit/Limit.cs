using KhStructs.Kh2.Bar;
using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Limit;

// size=???
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Limit {
    [FieldOffset(0x08)] public Hash<BarFile> MsetFile;

    [FieldOffset(0x50)] public int Int50;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 48 8B D9")]
    public partial int ImposeMotion(GameObject* target, int motionId, float blendTime);
}
