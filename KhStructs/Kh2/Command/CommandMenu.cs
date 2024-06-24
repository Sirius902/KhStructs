namespace KhStructs.Kh2.Command;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CommandMenu {
    public int Id;

    // TODO: Might be FieldCommand.
    public PlayerCommand* Command;
    public int NumEntries;
    [FixedSizeArray<CommandMenuEntry>(9)] public fixed byte Entries[9 * 0xC];

    // TODO: Add CommandId enum.
    [MemberFunction("E8 ?? ?? ?? ?? 66 83 3E 00")]
    public partial void* AddCommand(int commandId, void* a3, int a4);
}
