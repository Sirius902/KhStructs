namespace KhStructs.Kh2;

// ALLOCATOR

// size=0x8
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct Allocator {
    [FieldOffset(0x00)] public void* vtbl;

    [VirtualFunction(0)]
    public partial void Dtor(char flag);

    [VirtualFunction(1)]
    public partial void* Alloc(nuint size);

    [VirtualFunction(2)]
    public partial void Free(void* ptr);
}
