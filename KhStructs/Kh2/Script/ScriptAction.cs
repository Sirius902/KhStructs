using KhStructs.Kh2.Object;
using KhStructs.Util;

namespace KhStructs.Kh2.Script;

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct ScriptAction {
    [FieldOffset(0x00)] public void* PVoid0;

    [FieldOffset(0x108)] public ActionStruct108* Struct108;

    [FieldOffset(0x110)] public ScriptActionEntry* EntriesPointer;

    // TODO: Not sure what actions set this.
    [FieldOffset(0x118)] public ScriptActionEntry* CurrentEntry;

    public Span<ScriptActionEntry> Entries => new(this.EntriesPointer, 128);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4B 04 3B 0B")]
    public partial void Start(Utf8StringView name);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 80 79 03 01")]
    public partial void Request(Utf8StringView name);
}

[StructLayout(LayoutKind.Explicit)]
public struct ActionStruct108 {
    [FieldOffset(0x04)] public Hash<GameObject> ObjectHash;
}
