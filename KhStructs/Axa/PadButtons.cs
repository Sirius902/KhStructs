namespace KhStructs.Axa;

[Flags]
public enum PadButtons : ushort {
    Select = 1 << 0,
    LeftStick = 1 << 1,
    RightStick = 1 << 2,
    Start = 1 << 3,
    DPadUp = 1 << 4,
    DPadRight = 1 << 5,
    DPadDown = 1 << 6,
    DPadLeft = 1 << 7,
    LeftTrigger = 1 << 8,
    RightTrigger = 1 << 9,
    LeftBumper = 1 << 10,
    RightBumper = 1 << 11,
    Triangle = 1 << 12,
    Circle = 1 << 13,
    Cross = 1 << 14,
    Square = 1 << 15,
}
