namespace KhStructs.Kh2.Bar;

// size=0xB0
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct LoadedBarEntry {
    [FieldOffset(0x00)] public short Word0;
    [FieldOffset(0x2)] public short ReferenceCount;
    [FixedString("FileName")]
    [FieldOffset(0x4)] public fixed byte FileNameBytes[0x20];

    [FieldOffset(0x48)] public int Int48;
    [FieldOffset(0x4C)] public int Int4C;

    [FieldOffset(0x58)] public BarFile* BarFile;

    [FieldOffset(0x70)] public int NextHash;

    public static LoadedBarEntry* ListLast() => ListHead() + 1;

    [StaticAddress("48 8B 1D ?? ?? ?? ?? 8B F1 48 85 DB 74 74", 3, isPointer: true)]
    public static partial LoadedBarEntry* ListHead();
}
