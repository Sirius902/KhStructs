namespace KhStructs.Game.Kh2.GameObject.VTable;

// YS::OBJ::VTABLE<T>
//   YS::OBJ::IVTABLE

// size=0x8?
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct GameObjectVTable {
    public void* vtbl;
}
