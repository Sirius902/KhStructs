using KhStructs.Kh2.Bar;
using KhStructs.Kh2.Object.Entry;

namespace KhStructs.Kh2.Object;

// size=0x28
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ObjectData {
    public int Priority;
    public ObjectId Id;
    public ObjectEntry* Entry;
    public BarFile* Mdlx;
    public BarFile* Localization;
    public BarFile* Mset;

    [MemberFunction("E8 ?? ?? ?? ?? EB 46 0F 28 05 ?? ?? ?? ??")]
    public partial void Release();
}
