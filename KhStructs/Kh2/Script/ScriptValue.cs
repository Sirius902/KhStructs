namespace KhStructs.Kh2.Script;

[StructLayout(LayoutKind.Sequential)]
public struct ScriptValue {
    public ScriptValueData Data;
    public ScriptValueTag Tag;
}

[StructLayout(LayoutKind.Explicit, Size = 0x4)]
public struct ScriptValueData {
    [FieldOffset(0x00)] public int Int;
    [FieldOffset(0x00)] public float Float;
    [FieldOffset(0x00)] public Hash Address;
}

public enum ScriptValueTag {
    Int = 0x544E4940, // "@INT" backwards
    Float = 0x544C4640, // "@FLT" backwards
    Address = 0x52444140, // "@ADR" backwards
    UserData = 0x3F3F3F40, // "@???" backwards
}
