using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Script;

// size=???
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct Script {
    [FieldOffset(0x00)] public ScriptProcess Process;
    [FieldOffset(0x28)] public void* PVoid28;
    [FieldOffset(0x30)] public void* PVoid30;
    [FieldOffset(0x38)] public ScriptFlags Flags;

    [FieldOffset(0x40)] public int DestructorEntrypointId;
    [FieldOffset(0x44)] public Hash NextHash;
    [FieldOffset(0x48)] public Script* PScript48;

    [FieldOffset(0x58)] public void* Heap;
    [FieldOffset(0x60)] public GameObject* Owner;

    public Script* Next => (Script*)Hash.Lookup(this.NextHash);

    [MemberFunction("E8 ?? ?? ?? ?? 85 F6 48 89 03")]
    public static partial Script* Start(ScriptFile* scriptFile, GameObject* owner);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB 02 33 DB 83 4B 38 01 4C 8B C7")]
    public partial Script* Create(ScriptFile* scriptFile, void* heap, GameObject* owner);

    [MemberFunction("40 56 48 83 EC 20 8B 51 40")]
    public partial void Dispose();
}
