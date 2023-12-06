namespace KhStructs.Kh2.Script;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct ScriptProcess {
    public ScriptFile* Script;
    public int Pc;
    public ScriptValue* Fp;
    public ScriptValue* Sp;
    public ScriptValue* Hp;

    [StaticAddress("48 8D 15 ?? ?? ?? ?? 45 33 C0 48 8B CE", 3, isPointer: false)]
    public static partial void* SyscallTableInstance();

    [MemberFunction("0F 8F ?? ?? ?? ?? 48 8B 51 60")]
    public partial void SetupExecution(int pc, ScriptValue* args, int argc);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5E 48")]
    public partial ScriptStatus Execute(void* syscallTable,
        delegate* unmanaged<ScriptProcess*, ScriptStatus, void*, void> debugCallback, void* debugUserData);

    [MemberFunction("4C 8B 01 41 83 78 ?? ??")]
    public partial int GetEntrypointPc(int entrypointId);
}
