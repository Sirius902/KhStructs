using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Magic;

// size=???
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct Magic {
    [FieldOffset(0x00)] public Hash<Script.Script> ScriptHash;
    [FieldOffset(0x04)] public Hash<GameObject> CasterHash;

    [FieldOffset(0x0C)] public Hash NextHash;

    public Script.Script* Script => this.ScriptHash.Lookup();
    public GameObject* Caster => this.CasterHash.Lookup();
    public Magic* Next => (Magic*)Hash.Lookup(this.NextHash);

    [StaticAddress("48 89 1D ?? ?? ?? ?? 66 90", 3, isPointer: false)]
    public static partial NativeList<Magic>* List();

    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 8B 05 ?? ?? ?? ?? 8B C8")]
    public static partial void QueueLoad();

    [MemberFunction(
        "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC 20 4C 8D 05 ?? ?? ?? ??")]
    public static partial void Init();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 15 ?? ?? ?? ?? 41 8B CF")]
    public static partial void Reset();

    [MemberFunction("48 83 EC 48 8B 05 ?? ?? ?? ?? C1 E8 05")]
    public static partial void UpdateTask(Task.Task* task);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 40 48 8B 05 ?? ?? ?? ?? 48 89 74 24 ??")]
    public static partial void UpdateTaskFinish(Task.Task* task);
}
