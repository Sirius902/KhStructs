using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Command;

// size=???
[StructLayout(LayoutKind.Explicit, Size = 0xBE8)]
public unsafe struct FieldCommand {
    [FieldOffset(0x00)] public PlayerCommand PlayerCommand;

    [FieldOffset(0xB68)] public fixed ushort MagicCommandIds[7];

    [FieldOffset(0xBD8)] public nint QWordBD8;

    public Command* Command => (Command*)Unsafe.AsPointer(ref this.PlayerCommand.Command);
}
