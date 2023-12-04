namespace KhStructs.Kh2.Mode;

[Flags]
public enum GlobalFlags {
    // TODO: This may have to do with loading as well.
    Paused = 1 << 0,
    Flag1 = 1 << 1,
    Cutscene = 1 << 2,
    // TODO: See if this is used when tutorial popups are active.
    TutorialWindow = 1 << 3,
    Flag4 = 1 << 4,
}
