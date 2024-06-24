namespace KhStructs.Kh2.Object;

[StructLayout(LayoutKind.Sequential)]
public partial struct Summon {
    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 01 74 48")]
    public static partial int GetStatus();

    [MemberFunction("48 83 EC 48 83 3D ?? ?? ?? ?? ?? 74 51")]
    public static partial void End();
}
