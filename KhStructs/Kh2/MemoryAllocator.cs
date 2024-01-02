namespace KhStructs.Kh2;

// kn::MemoryAllocator
//   ALLOCATOR
//   Axa::CThread

// size=0x80
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct MemoryAllocator {
    [FieldOffset(0x00)] public Allocator Allocator;
    [FieldOffset(0x08)] public Axa.Thread Thread;

    public void* Alloc(nuint size) => this.Allocator.Alloc(size);

    public void Free(void* ptr) => this.Allocator.Free(ptr);

    public nuint Capacity() => this.Allocator.Capacity();

    public nuint UsedCapacity() => this.Allocator.UsedCapacity();

    public void Reset() => this.Allocator.Reset();

    public void Dispose(bool isHeap = false) => this.Allocator.Destructor((byte)(isHeap ? 1 : 0));

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 03 E8 ?? ?? ?? ??")]
    public static partial MemoryAllocator* Create(byte* buffer, nuint bufferSize);
}
