using System.Text;

namespace KhStructs.Util;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Utf8StringView(byte* data) {
    public byte* Data = data;

    public static implicit operator Utf8StringView(byte* data) {
        return new Utf8StringView { Data = data };
    }

    public readonly override string ToString() =>
        Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(this.Data));
}
