namespace KhStructs.Game.Kh2.GameObject.VTable;

// YS::OBJ::VTABLE<T>
//   YS::OBJ::IVTABLE

// size=0x8?
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct GameObjectVTable {
    [FieldOffset(0x00)] public void* vtbl;

    [VirtualFunction(22)]
    public partial void Kill(GameObject* gameObject);
}
