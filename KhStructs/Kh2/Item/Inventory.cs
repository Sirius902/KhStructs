using KhStructs.Util;

namespace KhStructs.Kh2.Item;

public partial struct Inventory {
    public const int DefaultPartyDataIndex = 100;

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 2B")]
    public static partial Bool8 GiveItem(Enum32<Item> item, int partyIndex, Bool8 isEquip);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B CD")]
    public static partial Bool8 RemoveItem(Enum32<Item> item, int partyIndex);

    [MemberFunction("E9 ?? ?? ?? ?? 4C 8D 46 56")]
    public static partial int GetItemQuantity(Enum32<Item> item);
}
