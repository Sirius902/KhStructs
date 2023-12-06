using KhStructs.Kh2.Object;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Save;
using KhStructs.Util;

namespace KhStructs.Kh2.Status;

// size=0x278
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe partial struct Status {
    [FieldOffset(0x00)] public int Hp;
    [FieldOffset(0x04)] public int MaxHp;
    [FieldOffset(0x08)] public int MinHp;

    [FieldOffset(0x180)] public int Mp;
    [FieldOffset(0x184)] public int MaxMp;
    [FieldOffset(0x188)] public short Strength;
    [FieldOffset(0x18A)] public short Magic;
    [FieldOffset(0x18C)] public short Defense;
    [FieldOffset(0x18E)] public short MaxAp;
    [FieldOffset(0x190)] public short BaseStrength;
    [FieldOffset(0x192)] public short BaseMagic;
    [FieldOffset(0x194)] public short BaseDefense;
    [FieldOffset(0x196)] public short BaseMaxAp;

    [FieldOffset(0x1AF)] public DriveMode DriveMode;

    [FieldOffset(0x1B3)] public byte DriveDisplayNumBars;

    [FieldOffset(0x1B4)] public float DriveGaugeTimer;
    [FieldOffset(0x1B8)] public float DriveGaugeMaxTimer;
    [FieldOffset(0x1BC)] public float MpChargeTimer;
    [FieldOffset(0x1C0)] public float MpChargeMaxTimer;

    [FieldOffset(0x1D0)] public Ability Ability;
    [FieldOffset(0x250)] public Hash<PartyData> PartyDataHash;
    [FieldOffset(0x254)] public Hash<FormData> FormDataHash;

    [FieldOffset(0x268)] public Hash<GameObject> ObjectHash;
    [FieldOffset(0x26C)] public Hash<BattleData> SaveBattleDataHash;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? 48 8B D8 48 85 C0")]
    public static partial Status* AllocPlayer(int partyIndex, Enum32<ObjectForm> form);

    [MemberFunction("E8 ?? ?? ?? ?? 33 ED 48 89 44 24 ??")]
    public static partial Status* AllocMenu(int partyIndex, Enum32<ObjectForm> form);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 53 04 45 33 C9")]
    public partial Status* Load(int partyIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 89 66 20")]
    public partial void Free();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 45 0F B6 C1")]
    public partial void AddHp(int delta, byte a3, Bool8 a4);
}
