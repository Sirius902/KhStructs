namespace KhStructs.Kh2.Menu;

// size=0x4B0
[StructLayout(LayoutKind.Explicit, Size = 0x4B0)]
public unsafe partial struct InformationWindow {
    [FieldOffset(0x4A0)] public float ScrollDelay;

    [StaticAddress("48 89 1D ?? ?? ?? ?? 48 8B 48 28 48 8B 01 FF 50 08 4C 8B F0", 3, isPointer: true)]
    public static partial InformationWindow* Instance();

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 0F B6 81 ?? ?? ?? ??")]
    public static partial void Create(InformationWindow* window, void* message);

    [MemberFunction("40 53 48 83 EC 20 83 89 ?? ?? ?? ?? ?? 48 8B D9")]
    public partial void Close();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B C3 75 21")]
    public partial void* GetMessage();
}
