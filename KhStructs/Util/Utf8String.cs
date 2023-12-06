using System.Text;

namespace KhStructs.Util;

public unsafe class Utf8String : PinnedBuffer {
    public Utf8StringView View => new() { Data = this.Data };

    public Utf8String(ReadOnlySpan<byte> data) : base(data) {
    }

    public Utf8String(string s) : base(Encoding.UTF8.GetBytes(s)) {
    }

    public Utf8String(Utf8StringView view) : this(view.Data) {
    }

    public Utf8String(byte* data) : this(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(data)) {
    }

    public static implicit operator Utf8StringView(Utf8String s) {
        return s.View;
    }

    public override string ToString() => this.View.ToString();
}
