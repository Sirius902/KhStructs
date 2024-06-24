using KhStructs.Kh2.Object.Entry;
using KhStructs.Util;

namespace KhStructs.Kh2.Item;

public unsafe partial struct Inventory {
    public const int DefaultPartyDataIndex = 100;

    [MemberFunction("E8 ?? ?? ?? ?? 66 89 2B")]
    public static partial Bool8 GiveItem(Enum32<Item> item, int partyIndex, Bool8 isEquip);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B CD")]
    public static partial Bool8 RemoveItem(Enum32<Item> item, int partyIndex);

    [MemberFunction("E9 ?? ?? ?? ?? 4C 8D 46 56")]
    public static partial int GetItemQuantity(Enum32<Item> item);

    [MemberFunction("E8 ?? ?? ?? ?? 8B C8 E8 ?? ?? ?? ?? 0F B7 48 10")]
    public static partial Enum32<Item> GetFormItem(Enum32<ObjectForm> form);
}
