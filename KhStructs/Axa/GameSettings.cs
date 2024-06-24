namespace KhStructs.Axa;

// TODO: Probably larger.
[StructLayout(LayoutKind.Explicit, Size = 0x105)]
public unsafe partial struct GameSettings {
    [FieldOffset(0x00)] public short ScreenMode;
    [FieldOffset(0x02)] public short ScreenWidth;
    [FieldOffset(0x04)] public short ScreenHeight;
    [FieldOffset(0x06)] public short FrameRateOption;
    [FieldOffset(0x08)] public short DisplayBrightness;
    [FieldOffset(0x0A)] public short VsyncEnabled;
    [FieldOffset(0x0C)] public short ColorBlindFilterType;
    [FieldOffset(0x0E)] public short ColorBlindFilterStrength;
    [FieldOffset(0x10)] public short MasterVolume;
    [FieldOffset(0x12)] public short BgmVolume;
    [FieldOffset(0x14)] public short SfxVolume;
    [FieldOffset(0x16)] public short VoicesVolume;
    [FieldOffset(0x18)] public short ButtonIconType;
    [FieldOffset(0x1A)] public short CircleConfirm;

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? BB ?? ?? ?? ??")]
    public static partial GameSettings* Instance();
}
