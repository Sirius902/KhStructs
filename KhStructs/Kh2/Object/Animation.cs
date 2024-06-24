using KhStructs.Kh2.Bar;
using KhStructs.Math;
using KhStructs.Util;

namespace KhStructs.Kh2.Object;

// TODO: Might be larger.
// size=0x210
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct Animation {
    [FieldOffset(0x00)] public BarFile* MsetFile;
    [FieldOffset(0x08)] public BarFile* PriorityMsetFile;
    [FieldOffset(0x10)] public GameObject* Object;
    [FieldOffset(0x1C)] public void* Motion;

    [FieldOffset(0x20)] public void* PVoid20;

    // TODO: Make MotionId an enum.
    [FieldOffset(0x28)] public int ImposedMotionId;
    [FieldOffset(0x2C)] public int MotionId2C;
    [FieldOffset(0x30)] public int MotionIndex30;
    [FieldOffset(0x34)] public int DWord34;
    [FieldOffset(0x38)] public int Float38;
    [FieldOffset(0x3C)] public int Flags3C;
    [FieldOffset(0x40)] public int Float40;
    [FieldOffset(0x44)] public int Float44;
    [FieldOffset(0x48)] public int Float48;
    [FieldOffset(0x4C)] public int Float4C;
    [FieldOffset(0x50)] public int DWord50;
    [FieldOffset(0x54)] public int DWord54;

    // TODO: This may also be a NativeList.
    [FieldOffset(0xD8)] public Animation* WeaponAnimationListHead;

    // TypedHash<Animation>
    [FieldOffset(0xE8)] public Hash NextWeaponAnimationHash;

    [FieldOffset(0x130)] public Vector3 Vec130;
    [FieldOffset(0x13C)] public Vector3 Vec13C;
    [FieldOffset(0x148)] public void* ObjectPaxFile;

    [FieldOffset(0x158)] public GameObject* PObject158;
    [FieldOffset(0x160)] public BarFile* ImposedMsetFile;
    [FieldOffset(0x168)] public byte Byte168;

    [FieldOffset(0x1B0)] public void* PVoid1B0;

    [FieldOffset(0x1F8)] public void* PVoid1F8;
    [FieldOffset(0x200)] public void* PVoid200;
    [FieldOffset(0x208)] public void* PVoid208;

    public Animation* NextWeaponAnimation => (Animation*)Hash.Lookup(this.NextWeaponAnimationHash);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 76 30")]
    public partial Bool8 PlayMotion(int motionId, float blendTime, float startTime);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0B 8B D0")]
    public partial int MotionIdToIndex(int motionId);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 D2 48 8D 4B 38")]
    public partial int ImposeMotion(GameObject* target, int motionId, float blendTime);

    [MemberFunction("40 55 56 41 55")]
    public static partial int ImposeMotionInner(GameObject* gameObject, BarFile* mset, void* pax, GameObject* target,
        float blendTime, int* refCount);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B D6 48 8B CD")]
    public partial void Sync(Animation* other);
}
