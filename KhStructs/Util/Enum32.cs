namespace KhStructs.Util;

/// <summary>
/// Represents an enumeration that is stored with 32 bits regardless of the enum's backing size.
/// </summary>
/// <typeparam name="T">An enum that must be backed by no more than 4 bytes.</typeparam>
[StructLayout(LayoutKind.Sequential)]
public struct Enum32<T>(T t) where T : Enum {
    private int Integer = Convert.ToInt32(t);

    public T Value => (T)Enum.ToObject(typeof(T), this.Integer);

    public static implicit operator T(Enum32<T> e) {
        return e.Value;
    }

    public static implicit operator Enum32<T>(T t) {
        return new Enum32<T>(t);
    }

    public override string ToString() {
        return this.Value.ToString();
    }
}
