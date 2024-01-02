namespace KhStructs.Axa;

// Axa::CThread

// size=???
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct Thread {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public void* PVoid8;

    // HANDLE
    [FieldOffset(0x18)] public nint Semaphore;

    [FieldOffset(0x30)] public int Dword30;

    [VirtualFunction(0)]
    public partial void Destructor(byte flag);

    public void Dispose(bool isHeap = false) => this.Destructor((byte)(isHeap ? 1 : 0));
}
