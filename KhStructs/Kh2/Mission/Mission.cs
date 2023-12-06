using KhStructs.Util;

namespace KhStructs.Kh2.Mission;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Mission {
    [MemberFunction("E8 ?? ?? ?? ?? 48 03 D8")]
    public static partial Mission* Current();

    [MemberFunction("48 8B 05 ?? ?? ?? ?? 48 85 C0 74 0D 8B 40 04 C1 E8 04")]
    public static partial Bool8 HasControl();

    [MemberFunction("48 8B 05 ?? ?? ?? ?? 48 85 C0 74 23")]
    public static partial Bool8 IsMiniGame();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 89 6C 24 ?? 8B DE")]
    public static partial Bool8 IsMickeyCanRescue();

    [MemberFunction("48 83 EC 28 85 C9 75 16")]
    public static partial void DisplayInformation(uint messageId);
}
