namespace KhStructs.Kh2.Scenario.World;

// TODO: Add way to get the entries out, after NumEntries is WorldEventEntry[this.NumEntries].
// size=0x8
[StructLayout(LayoutKind.Sequential)]
public struct WorldEventsHeader {
    public int Dword0;
    public uint NumEntries;
}
