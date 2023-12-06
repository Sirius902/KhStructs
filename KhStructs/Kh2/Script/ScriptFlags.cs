namespace KhStructs.Kh2.Script;

[Flags]
public enum ScriptFlags {
    Child = 1 << 0,
    Terminated = 1 << 1,
    Flag2 = 1 << 2,
}
