namespace KhStructs.Axa;

// GamePad

// size=0x140
[StructLayout(LayoutKind.Explicit, Size = 0x140)]
public unsafe partial struct GamePad {
    [FieldOffset(0x10)] public int UserIndex;

    [FieldOffset(0x18)] public nuint Buttons;
    [FieldOffset(0x20)] public float RightStickX;
    [FieldOffset(0x24)] public float RightStickY;
    [FieldOffset(0x28)] public float LeftStickX;
    [FieldOffset(0x2C)] public float LeftStickY;

    /// <summary>
    /// An array of <see cref="GamePad"/> states read from physical controllers.
    /// </summary>
    [StaticAddress("41 B8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 DB", 9, isPointer: false)]
    public static partial StateArray* States();

    [StructLayout(LayoutKind.Sequential)]
    public partial struct StateArray {
        [FixedSizeArray<GamePad>(8)]
        public fixed byte Pads[8 * 0x140];
    }
}
