namespace KhStructs.Kh2;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct NativeList<T> where T : unmanaged {
    public T* Head;
    public T* Last;
}
