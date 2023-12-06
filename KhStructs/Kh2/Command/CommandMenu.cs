namespace KhStructs.Kh2.Command;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CommandMenu {
    public int Id;
    // TODO: Might be FieldCommand.
    public PlayerCommand* Command;
    public int NumEntries;
    [FixedSizeArray<CommandMenuEntry>(9)]
    public fixed byte Entries[9 * 0xC];
}
