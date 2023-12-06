namespace KhStructs.Kh2.Save;

[StructLayout(LayoutKind.Explicit, Size = 0x114)]
public struct PartyData {
    [FieldOffset(0x00)] public Item.Item Weapon;
}
