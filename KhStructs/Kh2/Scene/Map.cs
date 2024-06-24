namespace KhStructs.Kh2.Scene;

[StructLayout(LayoutKind.Sequential)]
public partial struct Map {
    [MemberFunction("E8 ?? ?? ?? ?? C6 04 33 01")]
    public static partial void HideCollisionGroup(uint id);

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 FB 40")]
    public static partial void ShowCollisionGroup(uint id);
}
