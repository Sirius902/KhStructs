using KhStructs.Util;

namespace KhStructs.Kh2.Object;

// size=0x80
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Ability {
    public fixed uint Equipped[8];
    public byte HighJumpLevel;
    public byte QuickRunLevel;
    public byte AerialDodgeLevel;
    public byte GlideLevel;
    public byte DodgeRollLevel;
    public Status.Status* Status;
    public byte ComboCount;
    public byte AirComboCount;
    public byte FinisherCount;
    public byte ExperienceBoost;
    public byte Defender;
    public float Draw;
    public float MpHaste;
    public float DriveBoost;
    public float FormBoost;
    public short FireBoost;
    public short BlizzardBoost;
    public short ThunderBoost;
    public short ComboBoost;
    public short AirComboBoost;
    public short ReactionBoost;
    public short ItemBoost;
    public short BerserkCharge;
    public float DamageDrive;
    public float MpRage;
    public float HyperHealing;
    public float CombinationBoost;
    public float Jackpot;
    public float LuckyLucky;
    public float SummonBoost;
    public float DriveConverter;
    public float DamageControl;

    [MemberFunction("48 89 51 28 33 D2")]
    public partial void Init(Kh2.Status.Status* status);

    [MemberFunction("40 53 48 83 EC 20 48 8B 41 28 48 8B D9")]
    public partial void ComputeEquipped();

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 81 FA ?? ?? ?? ??")]
    public partial void EquipAbility(Enum32<Item.Item> item);

    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 7E 21")]
    public partial int GetGrowthAbilityLevel(int growthAbility);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 B8 ?? ?? ?? ?? 75 05")]
    public static partial Bool8 IsFreeMovement();
}
