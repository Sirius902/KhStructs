using KhStructs.Kh2.Math;

namespace KhStructs.Kh2.Object.GameObject;

// TODO: Might be larger.
// size=0x210
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct Animation {
    [FieldOffset(0x00)] public void* MsetFile;
    [FieldOffset(0x08)] public void* PriorityMsetFile;
    [FieldOffset(0x10)] public GameObject* Object;
    [FieldOffset(0x1C)] public void* Motion;
    [FieldOffset(0x20)] public void* PVoid20;
    // TODO: Make MotionId an enum.
    [FieldOffset(0x28)] public int MotionId28;
    [FieldOffset(0x2C)] public int MotionId2C;
    [FieldOffset(0x30)] public int MotionIndex30;
    [FieldOffset(0x34)] public int DWord34;
    [FieldOffset(0x38)] public int Float38;
    [FieldOffset(0x3C)] public int Float3C;
    [FieldOffset(0x40)] public int Float40;
    [FieldOffset(0x44)] public int Float44;
    [FieldOffset(0x48)] public int Float48;
    [FieldOffset(0x4C)] public int Float4C;
    [FieldOffset(0x50)] public int DWord50;
    [FieldOffset(0x54)] public int DWord54;

    [FieldOffset(0xD8)] public Animation* WeaponAnimationListHead;

    [FieldOffset(0xE8)] public int NextWeaponAnimationHash;

    [FieldOffset(0x130)] public Vector3 Vec130;
    [FieldOffset(0x13C)] public Vector3 Vec13C;
    [FieldOffset(0x148)] public void* ObjectPaxFile;

    [FieldOffset(0x158)] public nint QWord158;
    [FieldOffset(0x160)] public nint QWord160;
    [FieldOffset(0x168)] public byte Byte168;

    [FieldOffset(0x1B0)] public void* PVoid1B0;

    [FieldOffset(0x1F8)] public void* PVoid1F8;
    [FieldOffset(0x200)] public void* PVoid200;
    [FieldOffset(0x208)] public void* PVoid208;

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 76 30")]
    public static partial void PlayMotion(Animation* animation, int motionId, float a3, float a4);
}
