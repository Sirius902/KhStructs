namespace KhStructs.Axa;

// Axa::AppInterface
// Axa.AppInterface

// size=0x1498
// ctor E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 89 84 24 ?? ?? ?? ??
[StructLayout(LayoutKind.Explicit, Size = 0x1498)]
public unsafe partial struct AppInterface {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public void* SettingMenu;
    [FieldOffset(0x10)] public int OpenSettingMenu;
    [FieldOffset(0x14)] public int NumGamepadsToRead;
    [FixedSizeArray<PadData>(8)]
    [FieldOffset(0x18)] public fixed byte PadData[8 * 0x40];
    [FieldOffset(0x218)] public int MousePlugged;

    [FieldOffset(0x254)] public int Language;

    [FieldOffset(0x25C)] public int GameStatus;
    [FixedString("AxaBasePath")]
    [FieldOffset(0x260)] public fixed byte AxaBasePathBytes[512];
    [FixedString("WebdavBasePath")]
    [FieldOffset(0x460)] public fixed byte WebdavBasePathBytes[512];
    [FixedString("GameResourceBasePath")]
    [FieldOffset(0x660)] public fixed byte GameResourceBasePathBytes[512];
    [FixedString("GameResourceWebdavBasePath")]
    [FieldOffset(0x860)] public fixed byte GameResourceWebdavBasePathBytes[512];

    [FieldOffset(0x1268)] public int MainProcResult;

    [FieldOffset(0x1270)] public int MainProcResultOverride;

    /// <summary>
    /// Two DirectInput8 keyboard state buffers. To obtain the the correct key states, index with <see cref="KeyboardBufferIndex"/>
    /// multiplied by 256.
    /// </summary>
    [FieldOffset(0x1278)] public fixed byte DirectInputKeyboardBuffers[2 * 256];
    [FieldOffset(0x1478)] public int KeyboardBufferIndex;

    [StaticAddress("48 89 35 ?? ?? ?? ?? 48 8B C6", 3, isPointer: true)]
    public static partial AppInterface* Instance();

    [MemberFunction("40 56 41 56 48 83 EC 48 45 33 D2")]
    public static partial void UpdateKeyboardInput(AppInterface* app, nint a2, nint a3);

    [VirtualFunction(4)]
    public partial int Tick();
}
