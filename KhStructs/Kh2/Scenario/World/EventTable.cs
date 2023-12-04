namespace KhStructs.Kh2.Scenario.World;

// size=0x98
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct EventTable {
    [FixedSizeArray<Pointer<WorldEventsHeader>>(TableSize)]
    public fixed byte WorldEvents[0x8 * TableSize];

    public const int TableSize = (int)World.TheWorldThatNeverWas + 1;

    [StaticAddress("48 8B E8 48 8D 3D ?? ?? ?? ?? 33 DB", 6, isPointer: false)]
    public static partial EventTable* Instance();
}
