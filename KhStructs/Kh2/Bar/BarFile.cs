using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Bar;

// size=variable
/// <summary>
/// Represents a Bar file in memory. This struct assumes it is followed by the Bar entries and remains of the file data
/// afterwards. This means that copying this structure is invalid. Do not use this if those preconditions are not met.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BarFile {
    public BarHeader Header;

    public Span<BarSubFileInfo> Infos => new((BarFile*)Unsafe.AsPointer(ref this) + 1, (int)this.Header.SubFileCount);

    [MemberFunction("E8 ?? ?? ?? ?? 48 63 DF")]
    public partial BarSubFileInfo* GetInfo(int type, int indexOfDesiredType);

    [MemberFunction("E8 ?? ?? ?? ?? 49 63 DE")]
    public partial BarSubFileInfo* GetInfoByName(int type, uint name, int indexOfDesiredType);

    [MemberFunction("E8 ?? ?? ?? ?? F3 0F 10 44 3E ??")]
    public partial void* GetSubFileAtIndex(int index);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 0F B6 46 ??")]
    public partial void Init();

    [MemberFunction("40 55 48 83 EC 20 48 8B E9")]
    public partial void Setup();

    [MemberFunction("E8 ?? ?? ?? ?? EB 51 49 8B D6")]
    public partial void Move();

    [MemberFunction("E8 ?? ?? ?? ?? 81 7B ?? ?? ?? ?? ??")]
    public partial void Dispose(bool a1);
}
