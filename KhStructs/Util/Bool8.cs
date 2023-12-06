namespace KhStructs.Util;

/// <summary>
/// Represents a bool that occupies one byte.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Bool8(bool b) {
    private byte Value = (byte)(b ? 1 : 0);

    public static implicit operator bool(Bool8 b) {
        return b.Value != 0;
    }

    public static implicit operator Bool8(bool b) {
        return new Bool8(b);
    }

    public override string ToString() {
        return ((bool)this).ToString();
    }
}
