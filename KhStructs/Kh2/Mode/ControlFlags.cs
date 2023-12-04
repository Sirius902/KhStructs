namespace KhStructs.Kh2.Mode;

// TODO: There's probably more than this.
[Flags]
public enum ControlFlags {
    NoPlayerControl = 1 << 0,
    NoPartyControl = 1 << 1,
}
