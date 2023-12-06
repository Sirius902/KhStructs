using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Command;

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct UnkCommandStruct {
    public FieldCommand FieldCommand;

    public PlayerCommand* PlayerCommand => (PlayerCommand*)Unsafe.AsPointer(ref this.FieldCommand.PlayerCommand);

    [StaticAddress("48 89 0D ?? ?? ?? ?? 48 81 C1 ?? ?? ?? ??", 3, isPointer: true)]
    public static partial UnkCommandStruct* Instance();
}
