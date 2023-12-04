namespace KhStructs.Kh2.Bar;

// size=variable
/// <summary>
/// Represents a Bar file in memory. This struct assumes it is followed by the Bar entries and remains of the file data
/// afterwards. This means that copying this structure is invalid. Do not use this if those preconditions are not met.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BarFile {
    public BarHeader Header;

    public Span<BarEntry> Entries {
        get {
            fixed (BarFile* bar = &this)
                return new Span<BarEntry>(bar + 1, (int)this.Header.SubfileCount);
        }
    }
}
