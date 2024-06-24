using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Command;

// size=???
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Target {
    [FieldOffset(0x00)] public Hash<GameObject> ObjectHash;
    [FieldOffset(0x04)] public int Int4;
    [FieldOffset(0x08)] public Hash AttackHash;
    [FieldOffset(0x0C)] public int Type;
    [FieldOffset(0x10)] public int Int10;

    public GameObject* Object => this.ObjectHash.Lookup();
}
