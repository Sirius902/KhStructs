namespace KhStructs.Kh2.Menu;

public unsafe partial struct Information {
    [MemberFunction("E9 ?? ?? ?? ?? 48 85 C9 74 14")]
    public static partial void OpenWindow(void* message);

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 37")]
    public static partial void CloseWindow(void* message);
}
