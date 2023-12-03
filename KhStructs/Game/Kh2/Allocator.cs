namespace KhStructs.Game.Kh2;

// ALLOCATOR

// size=0x8
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Allocator {
    public void* vtbl;

    [VirtualFunction(0)]
    public static partial void Dtor(char flag);

    [VirtualFunction(1)]
    public static partial void* Alloc(nuint size);

    [VirtualFunction(2)]
    public static partial void Free(void* ptr);
}
