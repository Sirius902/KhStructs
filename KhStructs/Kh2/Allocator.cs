namespace KhStructs.Kh2;

// ALLOCATOR

// size=0x8
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct Allocator {
    [FieldOffset(0x00)] public void* vtbl;

    [VirtualFunction(0)]
    public partial void Destructor(byte flag);

    [VirtualFunction(1)]
    public partial void* Alloc(nuint size);

    [VirtualFunction(2)]
    public partial void Free(void* ptr);

    [VirtualFunction(3)]
    public partial nuint Capacity();

    [VirtualFunction(4)]
    public partial nuint UsedCapacity();

    [VirtualFunction(5)]
    public partial void Reset();

    public void Dispose(bool isHeap = false) => this.Destructor((byte)(isHeap ? 1 : 0));
}
