using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Command;

[StructLayout(LayoutKind.Explicit, Size = 0xB10)]
public unsafe partial struct PlayerCommand {
    [FieldOffset(0x00)] public Command Command;

    [FieldOffset(0x08)] public ushort CurrentCommand;
    [FieldOffset(0x0A)] public ushort PreviousCommand;

    [FieldOffset(0x10)] public Hash Hash10;

    [FixedSizeArray<CommandMenu>(19)]
    [FieldOffset(0x28)] public fixed byte CommandMenus[19 * 0x80];
    [FieldOffset(0x9A8)] public CommandMenu** CommandMenuStackTop;

    [FieldOffset(0xAE0)] public Player* Player;
    [FieldOffset(0xAE8)] public void* Input;
    [FixedSizeArray<Pointer<CommandMenu>>(4)]
    [FieldOffset(0xAF0)] public fixed byte CommandMenuStack[4 * 8];
}
