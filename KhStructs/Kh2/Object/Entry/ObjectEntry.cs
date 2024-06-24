using KhStructs.Kh2.Bar;
using KhStructs.Util;

namespace KhStructs.Kh2.Object.Entry;

// size=0x60
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ObjectEntry {
    public ObjectId Id;
    public ObjectType Type;
    public byte Subtype;
    public byte DrawPriority;
    public byte SkeletonType;

    [FixedString("Name")] public fixed byte NameBytes[32];

    [FixedString("AnimationName")] public fixed byte AnimationNameBytes[32];

    public ObjectFlags Flags;
    public ObjectTargetType TargetType;
    public ushort NeoStatus;
    public ushort NeoMoveset;
    public float Weight;
    public byte SpawnLimiter;
    public byte Page;
    public ObjectShadowSize ShadowSize;
    public ObjectForm Form;
    public ushort SpawnAdditionalObject1;
    public ushort SpawnAdditionalObject2;
    public ushort SpawnAdditionalObject3;
    public ushort SpawnAdditionalObject4;

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4F E4")]
    public static partial ObjectEntry* Lookup(ObjectId id);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5D 08 FF C6")]
    public static partial void QueueLoad(ObjectId id, int priority, int bank);

    [MemberFunction("E8 ?? ?? ?? ?? 40 38 7B 57")]
    public static partial void QueueLoadInner(ObjectId id, int priority, int bank, int bankLeft);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4C 24 ?? E8 ?? ?? ?? ?? 48 85 FF")]
    public static partial void QueueWeaponLoad(int neoMoveset, Hand hand, ObjectId id, int priority, int bank);

    [MemberFunction("48 83 EC 28 E8 ?? ?? ?? ?? 41 B9 ?? ?? ?? ??")]
    public static partial void QueueSoraFormLoad(Enum32<ObjectForm> form);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 33 D2")]
    public static partial int GetPriority(Enum32<ObjectType> type);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 74 0D 45 33 C0")]
    public partial ObjectId GetWeaponId(Hand hand);

    [MemberFunction("E8 ?? ?? ?? ?? 8B D0 EB 61")]
    public static partial ObjectId GetWeaponIdByMoveset(int neoMoveset, Enum32<Item.Item> weapon);

    /// <summary>
    /// Gets the path to the <see cref="ObjectEntry"/>'s MDLX file.
    /// </summary>
    /// <param name="outBuf">A buffer to store the result or null.</param>
    /// <returns>A pointer to the path with a length of at most 40 bytes. If <paramref name="outBuf"/> was null this
    /// will be a temporary view of the path and it should be copied to store long term.</returns>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 85 D2")]
    public partial Utf8StringView GetMdlxPath(byte* outBuf);

    /// <summary>
    /// Gets the path to the <see cref="ObjectEntry"/>'s localization file.
    /// </summary>
    /// <param name="outBuf">A buffer to store the result or null.</param>
    /// <returns>A pointer to the path with a length of at most 40 bytes. If <paramref name="outBuf"/> was null this
    /// will be a temporary view of the path and it should be copied to store long term.</returns>
    [MemberFunction("40 57 48 83 EC 20 0F B6 41 48")]
    public partial Utf8StringView GetLocalizationPath(byte* outBuf);

    /// <summary>
    /// Gets the path to the <see cref="ObjectEntry"/>'s MSET file.
    /// </summary>
    /// <param name="id">The id of the object.</param>
    /// <param name="outBuf">A buffer to store the result or null.</param>
    /// <returns>A pointer to the path with a length of at most 40 bytes. If <paramref name="outBuf"/> was null this
    /// will be a temporary view of the path and it should be copied to store long term.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 11 BA ?? ?? ?? ??")]
    public partial Utf8StringView GetMsetPath(ObjectId id, byte* outBuf);

    /// <summary>
    /// Gets the path to the <see cref="ObjectEntry"/>'s MSET file.
    /// </summary>
    /// <param name="moveset">The moveset id of the character.</param>
    /// <param name="hand">The hand the weapon will be held in.</param>
    /// <param name="outBuf">A buffer to store the result or null.</param>
    /// <returns>A pointer to the path with a length of at most 40 bytes. If <paramref name="outBuf"/> was null this
    /// will be a temporary view of the path and it should be copied to store long term.</returns>
    [MemberFunction("48 83 EC 28 48 63 C2 4C 63 C9")]
    public static partial Utf8StringView GetWeaponMsetPath(int moveset, Hand hand, byte* outBuf);

    [MemberFunction("E8 ?? ?? ?? ?? A8 08 75 3E")]
    public static partial uint GetBarTableStatus(ObjectId id, ObjectEntry* entry);
}
