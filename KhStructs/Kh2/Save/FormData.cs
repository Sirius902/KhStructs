namespace KhStructs.Kh2.Save;

// size=0x38
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct FormData {
    [FieldOffset(0x00)] public Item.Item Weapon;
    [FieldOffset(0x02)] public byte Level;
    [FieldOffset(0x03)] public byte GrowthAbilityLevel;
    [FieldOffset(0x04)] public int Exp;

    [FixedSizeArray<Item.Item>(24)] [FieldOffset(0x08)]
    public fixed byte Abilities[24 * 2];
}
