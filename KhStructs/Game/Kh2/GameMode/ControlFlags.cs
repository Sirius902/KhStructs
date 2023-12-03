namespace KhStructs.Game.Kh2.GameMode;

// TODO: There's probably more than this.
[Flags]
public enum ControlFlags {
    NoPlayerControl = 1 << 0,
    NoPartyControl = 1 << 1,
}
