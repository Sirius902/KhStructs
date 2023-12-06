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
    public Kh2.Status.Status* Status;
    public byte Byte30;
    public byte Byte31;
    public byte Byte32;
    public byte Byte33;
    public byte Byte34;
    public float Float38;
    public float Float3C;
    public float Float40;
    public float Float34;
    public short Word48;
    public short Word4A;
    public short Word4C;
    public short Word4E;
    public short Word50;
    public short Word52;
    public short Word54;
    public short Word56;
    public float Float58;
    public float Float5C;
    public float Float60;
    public float Float64;
    public float Float68;
    public float Float6C;
    public float Float70;
    public float Float74;
    public float Float78;

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
