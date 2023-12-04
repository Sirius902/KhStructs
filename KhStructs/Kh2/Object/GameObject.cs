using KhStructs.Kh2.Bar;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.VTable;
using KhStructs.Math;

namespace KhStructs.Kh2.Object;

// YS::OBJ

// TODO: Some of these fields definitely don't exist on all game objects and are probably only on YS::STDOBJ or YS::BTLOBJ.
// size=0xE10
[StructLayout(LayoutKind.Explicit, Size = 0xE10)]
public unsafe partial struct GameObject {
    [FieldOffset(0x00)] public int VTableHash;
    [FieldOffset(0x04)] public int ThisHash;
    [FieldOffset(0x08)] public int ObjectEntryHash;
    [FieldOffset(0x0C)] public int ActionEntryHash;
    [FieldOffset(0x10)] public int Hash10;

    [FieldOffset(0x20)] public Vector4 AirVelocity;

    [FieldOffset(0x38)] public float Float38;
    [FieldOffset(0x3C)] public float Float3C;

    // TODO: Might also be static position.
    [FieldOffset(0x70)] public Vector4 ParentPosition;
    [FieldOffset(0x80)] public void* PaxFile;

    [FieldOffset(0xB0)] public void* PVoidB0;

    [FieldOffset(0xE0)] public Vector4 VecE0;
    [FieldOffset(0xF0)] public float Gravity;
    [FieldOffset(0xF4)] public float JumpSlowdownFactor;
    [FieldOffset(0xF8)] public float FloatF8;
    [FieldOffset(0xFC)] public float JumpHeight;

    [FieldOffset(0x108)] public nint QWord108;

    [FieldOffset(0x120)] public Flags120 Flags120;
    [FieldOffset(0x124)] public int Flags124;

    [FieldOffset(0x134)] public int MovementFlags134;

    [FieldOffset(0x158)] public Animation animation;

    [FieldOffset(0x390)] public void* PVoid390;

    [FieldOffset(0x5B0)] public void* AIScript;
    [FieldOffset(0x5B8)] public int RefCount;

    // TODO: This is definitely only on things that have YS::BTLOBJ.
    [FieldOffset(0x5C0)] public Status* BattleStatus;

    [FieldOffset(0x5D8)] public void* PVoid5D8;

    [FieldOffset(0x638)] public int DWord638;

    [FieldOffset(0x648)] public byte Byte648;

    [FieldOffset(0x64C)] public byte Byte64C;

    [FieldOffset(0x670)] public Vector4 Position;

    [FieldOffset(0x6A0)] public int ParentHash;

    [FieldOffset(0x6C8)] public Flags6C8 Flags6C8;

    [FieldOffset(0x6D0)] public Vector4 PreviousPosition;
    [FieldOffset(0x6E0)] public Vector4 Velocity;

    [FieldOffset(0x7B0)] public void* PVoid7B0;
    [FieldOffset(0x7B8)] public int DWord7B8;

    [FieldOffset(0x8B8)] public void* PVoid8B8;

    [FieldOffset(0x920)] public BarFile* MdlxFile;

    [FixedSizeArray<nint>(8)]
    [FieldOffset(0x938)] public fixed byte PVoidArray938[16 * 8];
    [FieldOffset(0x9B8)] public Flags9B8 Flags9B8;

    [FieldOffset(0x9F0)] public void* PVoid9F0;

    [FieldOffset(0xA90)] public int NextHash;

    [FieldOffset(0xAC0)] public byte ByteAC0;

    [FieldOffset(0xB94)] public float FloatB94;

    [FieldOffset(0xBA8)] public float AnimationEndDelay;

    [FieldOffset(0xD48)] public void* PVoidD48;

    [FieldOffset(0xD60)] public GameObject* WeaponListHead;
    [FieldOffset(0xD68)] public GameObject* WeaponListLast;
    [FieldOffset(0xD70)] public int PartyIndex;

    [FieldOffset(0xDC0)] public void* PVoidDC0;

    [FieldOffset(0xDE0)] public ObjectForm Form;

    [FieldOffset(0xE08)] public nint QWordE08;

    public GameObjectVTable* VTable() => (GameObjectVTable*)Hash.Lookup(this.VTableHash);

    public ObjectEntry* ObjectEntry() => (ObjectEntry*)Hash.Lookup(this.ObjectEntryHash);

    // TODO: Add Action.
    public void* Action() => Hash.Lookup(this.ActionEntryHash);

    public GameObject* Parent() => (GameObject*)Hash.Lookup(this.ParentHash);

    [StaticAddress("81 8F ?? ?? ?? ?? ?? ?? ?? ?? 48 89 3D ?? ?? ?? ??", 13, isPointer: true)]
    public static partial GameObject* InitialPlayer();

    /// <summary>
    /// Returns the address of the next valid game object after <paramref name="gameObject"/> or null if there are no more.
    /// </summary>
    /// <param name="gameObject">The game object to find the next of or null to get the first <see cref="GameObject"/>.</param>
    /// <returns>The first or next <see cref="GameObject"/>.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 DF")]
    public static partial GameObject* Next(GameObject* gameObject);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 A4")]
    public static partial bool IsValid(GameObject* gameObject);
}
