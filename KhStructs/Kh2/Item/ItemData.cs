using KhStructs.Util;

namespace KhStructs.Kh2.Item;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ItemData {
    [FieldOffset(0x00)] public Item Item;
    [FieldOffset(0x02)] public ItemType Type;
    [FieldOffset(0x03)] public ItemFlags Flags;
    [FieldOffset(0x04)] public ItemInfo Info;
    [FieldOffset(0x08)] public ushort MessageId;
    [FieldOffset(0x0A)] public ushort TutorialMessageId;

    [FieldOffset(0x10)] public ushort CommandId;
    [FieldOffset(0x12)] public ushort InventoryId;
    [FieldOffset(0x14)] public ushort Picture;
    [FieldOffset(0x16)] public byte PrizeBox;
    [FieldOffset(0x17)] public byte Icon;

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4F F1")]
    public static partial ItemData* Get(Enum32<Item> item);
}

public enum ItemType : byte {
    Equip = 0,
    Magic = 1,
    Weapon = 2,
    Ability = 3,
    Battle = 4,
    Report = 5,
    Type6 = 6,
}

[Flags]
public enum ItemFlags : byte {
    Flag0 = 1 << 0,
    BaseFormOnly = 1 << 1,
}

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct ItemInfo {
    [FieldOffset(0x00)] public AbilityItemInfo Ability;
}

[StructLayout(LayoutKind.Sequential)]
public struct AbilityItemInfo {
    public ushort Id;
    public byte Ap;
    public AbilityItemType Type;
}

public enum AbilityItemType : byte {
    Support = 0,
    Limit = 1,
    Action = 2,
    Growth = 3,
}
