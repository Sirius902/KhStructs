namespace KhStructs.Kh2.Save;

[StructLayout(LayoutKind.Explicit, Size = 0x114)]
public unsafe partial struct PartyData {
    [FieldOffset(0x00)] public Item.Item Weapon;

    [FixedSizeArray<Item.Item>(80)] [FieldOffset(0x54)]
    public fixed byte Abilities[80 * 2];
}
