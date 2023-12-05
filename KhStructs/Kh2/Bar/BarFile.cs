using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Bar;

// size=variable
/// <summary>
/// Represents a Bar file in memory. This struct assumes it is followed by the Bar entries and remains of the file data
/// afterwards. This means that copying this structure is invalid. Do not use this if those preconditions are not met.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BarFile {
    public BarHeader Header;

    public Span<BarEntry> Entries => new((BarFile*)Unsafe.AsPointer(ref this) + 1, (int)this.Header.SubfileCount);
}
