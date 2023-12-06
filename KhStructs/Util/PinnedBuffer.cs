namespace KhStructs.Util;

public unsafe class PinnedBuffer : IDisposable {
    public byte* Data => (byte*)this.DataHandle.AddrOfPinnedObject();

    public int Length => this.ManagedData.Length;

    public Span<byte> AsSpan() => new(this.Data, this.Length);

    protected readonly byte[] ManagedData;
    protected GCHandle DataHandle { get; }

    public PinnedBuffer(ReadOnlySpan<byte> data) {
        this.ManagedData = data.ToArray();
        this.DataHandle = GCHandle.Alloc(this.ManagedData, GCHandleType.Pinned);
    }

    protected PinnedBuffer(byte[] data) {
        this.ManagedData = data;
        this.DataHandle = GCHandle.Alloc(this.ManagedData, GCHandleType.Pinned);
    }

    public void Dispose() {
        this.DataHandle.Free();
        GC.SuppressFinalize(this);
    }
}
