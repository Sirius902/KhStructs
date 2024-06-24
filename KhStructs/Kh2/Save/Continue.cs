namespace KhStructs.Kh2.Save;

// size=0x12030
[StructLayout(LayoutKind.Sequential, Size = 0x12030)]
public unsafe partial struct Continue {
    public SaveData SaveData;
    public Scene.Scene Scene;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? F2 0F 10 05 ?? ?? ?? ??", 3)]
    public static partial Continue* Instance();

    [MemberFunction("48 83 EC 28 E8 ?? ?? ?? ?? 84 C0 75 1B")]
    public partial void Save();
}
