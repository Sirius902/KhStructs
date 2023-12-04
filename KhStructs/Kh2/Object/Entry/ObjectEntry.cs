namespace KhStructs.Kh2.Object.Entry;

// size=0x60
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ObjectEntry {
    public ObjectId Id;
    public ObjectType Type;
    public byte Subtype;
    public byte DrawPriority;
    public byte WeaponJoin;

    [FixedString("ModelName")]
    public fixed byte ModelNameBytes[32];

    [FixedString("AnimationName")]
    public fixed byte AnimationNameBytes[32];

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

    [MemberFunction("E9 ?? ?? ?? ?? 6D D7")]
    public static partial ObjectEntry* LookupEntry(ObjectId id);
}
