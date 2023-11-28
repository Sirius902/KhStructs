namespace KhStructs.Internal;

internal static class Util {
    public static Exception EnumArgumentException<T>(string name, T value) where T : Enum =>
        new ArgumentOutOfRangeException(name, value,
            $"Expected valid {value.GetType().Name} but got: {(int)(object)value}");
}
