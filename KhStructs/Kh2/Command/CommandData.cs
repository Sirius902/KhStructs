namespace KhStructs.Kh2.Command;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct CommandData {
    [MemberFunction("E8 ?? ?? ?? ?? 8B 4D D7")]
    public static partial CommandData* Get(int commandId);
}
