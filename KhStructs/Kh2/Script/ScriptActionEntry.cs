using KhStructs.Util;

namespace KhStructs.Kh2.Script;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct ScriptActionEntry {
    public Hash<byte> NameHash;
    public ushort Priority;
    public ushort Flags;
    public ushort ScriptEntryOffset;
    public fixed ushort ScriptCallbackOffsets[11];

    public Utf8StringView Name => new(this.NameHash.Lookup());
}
