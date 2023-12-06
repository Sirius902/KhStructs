namespace KhStructs.Kh2.Object.Entry;

[Flags]
public enum ObjectFlags : ushort {
    NoLocalization = 1 << 0,
    Before = 1 << 1,
    FixColor = 1 << 2,
    Fly = 1 << 3,
    Scissoring = 1 << 4,
    Pirate = 1 << 5,
    OccWall = 1 << 6,
    Hift = 1 << 7,
}
