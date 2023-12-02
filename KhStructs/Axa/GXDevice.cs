namespace KhStructs.Axa;

// Axa::GX::GXDevice::GXDeviceImpl
//   Axa::GX::GXDevice::GXDeviceImpl0
//     Axa::GX::GXDevice::GXDeviceBase
// Axa.GX.GXDevice

// size=???
// ctor E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 90 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? CC
// calls ctor E8 ?? ?? ?? ?? 8B 40 2C
[StructLayout(LayoutKind.Explicit, Size = 0xE550)]
public unsafe partial struct GXDevice {
    [FieldOffset(0x00)] public void* vtbl;

    /// <summary>
    /// ID3D12Device*
    /// </summary>
    [FieldOffset(0x2E0)] public void* D3D12Device;

    [FieldOffset(0x32C)] public uint VSyncEnabled;

    [FieldOffset(0x3E8)] public AppInterface* App;
    [FieldOffset(0x3F0)] public nint AxaSimpleWindowHwnd;
    [FieldOffset(0x3F8)] public nint Hwnd3F8;

    /// <summary>
    /// IDXGISwapChain3*
    /// </summary>
    [FieldOffset(0x468)] public void* DXGISwapChain;
    /// <summary>
    /// ID3D12CommandQueue*
    /// </summary>
    [FieldOffset(0x470)] public void* D3D12MainCommandQueue;
    /// <summary>
    /// ID3D12RootSignature*
    /// </summary>
    [FieldOffset(0x478)] public void* D3D12RootSignature;

    /// <summary>
    /// ID3D12CommandQueue*
    /// </summary>
    [FieldOffset(0x488)] public void* D3D12CommandQueue488;

    /// <summary>
    /// ID3D12GraphicsCommandList*
    /// </summary>
    [FieldOffset(0x498)] public void* D3D12GraphicsCommandList;
    /// <summary>
    /// ID3D12CommandAllocator*
    /// </summary>
    [FieldOffset(0x4A0)] public void* D3D12CommandAllocator;
    /// <summary>
    /// IDXGIOutput*
    /// </summary>
    [FieldOffset(0x4A8)] public void* DXGIOutput;
    /// <summary>
    /// IDXGIAdapter3*
    /// </summary>
    [FieldOffset(0x4B0)] public void* DXGIAdapter;
    /// <summary>
    /// ID3D12DescriptorHeap*
    /// </summary>
    [FieldOffset(0x4B8)] public void* D3D12RtvDescriptorHeap;
    /// <summary>
    /// ID3D12DescriptorHeap*
    /// </summary>
    [FieldOffset(0x4C0)] public void* D3D12DsvDescriptorHeap;
    [FieldOffset(0x4C8)] public void* PStruct4C8;
    /// <summary>
    /// ID3D12DescriptorHeap*
    /// </summary>
    [FieldOffset(0x4D0)] public void* D3D12SamplerDescriptorHeap;

    [StaticAddress("75 99 48 8D 0D ?? ?? ?? ??", 5, isPointer: false)]
    public static partial GXDevice* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 89 AF ?? ?? ?? ?? F3 0F 10 47 ??")]
    public static partial void InitSwapchain(GXDevice* device);
}
