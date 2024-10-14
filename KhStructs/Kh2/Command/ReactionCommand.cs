using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Command;

// size=???
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct ReactionCommand {
    [FieldOffset(0x00)] public PlayerCommand* PlayerCommand;

    [FieldOffset(0x18)] public Hash<GameObject> TargetObjectHash;

    [FieldOffset(0x30)] public CommandMenuEntry Command;

    public GameObject* TargetObject => this.TargetObjectHash.Lookup();

    [MemberFunction("E8 ?? ?? ?? ?? 8B 47 24 C1 E8 06")]
    public partial void Update();
}
