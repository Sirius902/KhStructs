using KhStructs.Util;

namespace KhStructs.Axa;

// Axa::AppInterface
// Axa.AppInterface

// size=0x14C0
// ctor is not safely siggable
[StructLayout(LayoutKind.Explicit, Size = 0x14C0)]
public unsafe partial struct AppInterface {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public void* SettingMenu;
    [FieldOffset(0x10)] public int OpenSettingMenu;
    [FieldOffset(0x14)] public int NumGamepadsToRead;

    [FixedSizeArray<PadData>(8)] [FieldOffset(0x18)]
    public fixed byte PadData[8 * 0x44];

    [FieldOffset(0x238)] public int MousePlugged;

    [FieldOffset(0x274)] public int Language;

    [FieldOffset(0x27C)] public int GameStatus;

    [FixedString("AxaBasePath")] [FieldOffset(0x280)]
    public fixed byte AxaBasePathBytes[512];

    [FixedString("WebdavBasePath")] [FieldOffset(0x480)]
    public fixed byte WebdavBasePathBytes[512];

    [FixedString("GameResourceBasePath")] [FieldOffset(0x680)]
    public fixed byte GameResourceBasePathBytes[1024];

    [FixedString("GameResourceWebdavBasePath")] [FieldOffset(0xA80)]
    public fixed byte GameResourceWebdavBasePathBytes[1024];

    [FixedString("GameReplacePath")] [FieldOffset(0xE80)]
    public fixed byte GameReplacePathBytes[1024];

    [FieldOffset(0x1290)] public int MainProcResult;

    [FieldOffset(0x1298)] public int MainProcResultOverride;

    /// <summary>
    /// Two DirectInput8 keyboard state buffers. To obtain the correct key states, index with <see cref="KeyboardBufferIndex"/>
    /// multiplied by 256.
    /// </summary>
    [FieldOffset(0x12A0)] public fixed byte DirectInputKeyboardBuffers[2 * 256];

    [FieldOffset(0x14A0)] public int KeyboardBufferIndex;

    [StaticAddress("48 89 35 ?? ?? ?? ?? 48 8B C6", 3, isPointer: true)]
    public static partial AppInterface* Instance();

    [StaticAddress("0F 84 ?? ?? ?? ?? 44 38 25 ?? ?? ?? ??", 9, isPointer: false)]
    public static partial Bool8* MouseActive();

    [StaticAddress("89 05 ?? ?? ?? ?? B8 ?? ?? ?? ?? 48 83 C4 20", 2, isPointer: false)]
    public static partial int* IsUsingKeyboardInput();

    [MemberFunction("48 89 51 08 48 89 4A 08")]
    public static partial void LinkAppAndSettingMenu(AppInterface* app, void* settingMenu);

    [VirtualFunction(4)]
    public partial int Tick();
}
