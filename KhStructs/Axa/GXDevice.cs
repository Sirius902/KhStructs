using TerraFX.Interop.DirectX;
using TerraFX.Interop.Windows;

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

    [FieldOffset(0x2E0)] public ID3D12Device* Device;

    [FieldOffset(0x32C)] public uint VSyncEnabled;

    [FieldOffset(0x3E8)] public AppInterface* App;
    [FieldOffset(0x3F0)] public HWND AxaSimpleWindowHwnd;
    [FieldOffset(0x3F8)] public HWND Hwnd3F8;

    [FieldOffset(0x468)] public IDXGISwapChain3* SwapChain;
    [FieldOffset(0x470)] public ID3D12CommandQueue* MainCommandQueue;
    [FieldOffset(0x478)] public ID3D12RootSignature* RootSignature;

    [FieldOffset(0x488)] public ID3D12CommandQueue* CommandQueue488;

    [FieldOffset(0x498)] public ID3D12GraphicsCommandList* GraphicsCommandList;
    [FieldOffset(0x4A0)] public ID3D12CommandAllocator* CommandAllocator;
    [FieldOffset(0x4A8)] public IDXGIOutput* Output;
    [FieldOffset(0x4B0)] public IDXGIAdapter3* Adapter;
    [FieldOffset(0x4B8)] public ID3D12DescriptorHeap* RtvDescriptorHeap;
    [FieldOffset(0x4C0)] public ID3D12DescriptorHeap* DsvDescriptorHeap;
    [FieldOffset(0x4C8)] public void* PStruct4C8;
    [FieldOffset(0x4D0)] public ID3D12DescriptorHeap* SamplerDescriptorHeap;

    [StaticAddress("75 99 48 8D 0D ?? ?? ?? ??", 5, isPointer: false)]
    public static partial GXDevice* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 89 AF ?? ?? ?? ?? F3 0F 10 47 ??")]
    public static partial HRESULT InitSwapchain(GXDevice* device);
}
