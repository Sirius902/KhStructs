using KhStructs.Kh2.Command;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.Util;
using KhStructs.Kh2.Object.VTable;
using KhStructs.Kh2.Script;
using KhStructs.Kh2.Task;
using KhStructs.Math;
using KhStructs.Util;

namespace KhStructs.Kh2.Object;

// YS::OBJ

// TODO: Some of these fields definitely don't exist on all game objects and are probably only on YS::STDOBJ or YS::BTLOBJ.
// size=0xE10
[StructLayout(LayoutKind.Explicit, Size = 0xE10)]
public unsafe partial struct GameObject {
    [FieldOffset(0x00)] public Hash<GameObjectVTable> VTableHash;

    // Hash<GameObject>
    [FieldOffset(0x04)] public Hash ThisHash;
    [FieldOffset(0x08)] public Hash<ObjectEntry> EntryHash;
    [FieldOffset(0x0C)] public Hash<Action> ActionHash;
    [FieldOffset(0x10)] public Hash Hash10;

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
    [FieldOffset(0x128)] public Moveset Moveset;
    [FieldOffset(0x158)] public Animation Animation;

    [FieldOffset(0x390)] public ScriptAction* ScriptAction;

    [FieldOffset(0x5B0)] public Script.Script* Script;
    [FieldOffset(0x5B8)] public int RefCount;

    // TODO: This is definitely only on things that have YS::BTLOBJ.
    [FieldOffset(0x5C0)] public Status.Status* Status;

    [FieldOffset(0x5D8)] public void* PVoid5D8;

    [FieldOffset(0x638)] public int DWord638;

    [FieldOffset(0x648)] public byte Byte648;

    [FieldOffset(0x64C)] public byte Byte64C;

    [FieldOffset(0x670)] public Vector4 Position;

    // Hash<GameObject>
    [FieldOffset(0x6A0)] public Hash ParentHash;

    [FieldOffset(0x6C8)] public Flags6C8 Flags6C8;

    [FieldOffset(0x6D0)] public Vector4 PreviousPosition;
    [FieldOffset(0x6E0)] public Vector4 Velocity;

    [FieldOffset(0x740)] public int DWord740;

    [FieldOffset(0x7B0)] public void* PVoid7B0;
    [FieldOffset(0x7B8)] public int DWord7B8;

    [FieldOffset(0x8B8)] public void* PVoid8B8;

    [FieldOffset(0x910)] public ObjectData ObjectData;

    [FixedSizeArray<nint>(8)] [FieldOffset(0x938)]
    public fixed byte PVoidArray938[16 * 8];

    [FieldOffset(0x9B8)] public Flags9B8 Flags9B8;

    [FieldOffset(0x9F0)] public void* PVoid9F0;

    [FieldOffset(0xA68)] public Vector4 SpawnPosRot;

    // Hash<GameObject>
    [FieldOffset(0xA90)] public Hash NextHash;

    [FieldOffset(0xAC0)] public byte ByteAC0;

    [FieldOffset(0xB94)] public float FloatB94;

    [FieldOffset(0xBA8)] public float AnimationEndDelay;

    [FieldOffset(0xBB0)] public Hash<ushort> BankHash;
    [FieldOffset(0xBB4)] public Hash VoiceHash;

    [FieldOffset(0xCF0)] public uint ReactionCommand;

    [FieldOffset(0xD48)] public float RevengeValue;
    [FieldOffset(0xD4C)] public float RevengeValueMax;

    [FixedSizeArray<Pointer<Weapon>>(2)] [FieldOffset(0xD60)]
    public fixed byte Weapons[2 * 8];

    [FieldOffset(0xD70)] public int PartyDataIndex;

    [FieldOffset(0xDC0)] public UnkCommandStruct* UnkCommandStruct;

    // TODO: Might be PlayerCommand.
    [FieldOffset(0xDD0)] public FieldCommand* FieldCommand;

    [FieldOffset(0xDE0)] public Enum32<ObjectForm> Form;

    [FieldOffset(0xE08)] public nint QWordE08;

    public static IEnumerable<Pointer<GameObject>> All() => new ObjectEnumerator<GameObject>(&Iterate);

    public GameObjectVTable* VTable => this.VTableHash.Lookup();

    public ObjectEntry* Entry => this.EntryHash.Lookup();

    public Action* Action => this.ActionHash.Lookup();

    public GameObject* Parent => (GameObject*)Hash.Lookup(this.ParentHash);

    /// <summary>
    /// Gets the next <see cref="GameObject"/> in the list. This object may be invalid, consider using <see cref="GameObject.Iterate"/>.
    /// </summary>
    public GameObject* Next => (GameObject*)Hash.Lookup(this.ParentHash);

    [StaticAddress("48 8B 15 ?? ?? ?? ?? 33 FF 8B C7", 3, isPointer: false)]
    public static partial NativeList<GameObject>* List();

    [StaticAddress("74 51 48 8B 0D ?? ?? ?? ??", 5, isPointer: true)]
    public static partial TaskManager* TaskManager();

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 F3 0F 11 B3 ?? ?? ?? ??")]
    public partial GameObject* Create(ObjectId id, ObjectEntry* entry, byte priority, Vector4* pos, float rot);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 9F ?? ?? ?? ??")]
    public partial void Dispose();

    [MemberFunction("E9 ?? ?? ?? ?? CC 40 53 48 83 EC 20 8B 81 ?? ?? ?? ??")]
    public partial void DisposeVirtual();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 4B")]
    public static partial GameObject* Spawn(ObjectId id, Vector4* pos, float rot);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 5C C6 0F 57 C9")]
    public partial float GetGroundHeight();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 68 8B CB")]
    public partial Bool8 CanAct();

    [MemberFunction("E8 ?? ?? ?? ?? 83 E8 01 74 2A 83 E8 0D")]
    public partial int GetSkeletonType();

    /// <summary>
    /// Returns the address of the next valid game object after <paramref name="gameObject"/> or null if there are no more.
    /// </summary>
    /// <param name="gameObject">The game object to find the next of or null to get the first <see cref="GameObject"/>.</param>
    /// <returns>The first or next <see cref="GameObject"/>.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 DF")]
    public static partial GameObject* Iterate(GameObject* gameObject);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 A4")]
    public static partial Bool8 IsValid(GameObject* gameObject);

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 65")]
    public partial int GetPartyDataIndex();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B CE 44 0F B6 E0")]
    public partial Bool8 IsHidden();

    [MemberFunction("E8 ?? ?? ?? ?? 84 DB 74 1C")]
    public partial void* Attach(GameObject* parent, int bone, int flags);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 C8 48 8B CB E8 ?? ?? ?? ?? 48 8B CF")]
    public partial float GetRotation();

    [MemberFunction("E8 ?? ?? ?? ?? 0F 10 45 20")]
    public partial Vector4* GetDirection(Vector4* result);
}
