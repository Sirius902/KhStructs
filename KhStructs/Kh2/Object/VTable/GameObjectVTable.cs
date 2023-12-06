using KhStructs.Util;

namespace KhStructs.Kh2.Object.VTable;

// YS::OBJ::VTABLE<T>
//   YS::OBJ::IVTABLE

// size=0x8
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct GameObjectVTable {
    [FieldOffset(0x00)] public void* vtbl;

    [VirtualFunction(0)]
    public partial void Dispose(GameObject* self);

    [VirtualFunction(1)]
    public partial void Init(GameObject* self);

    [VirtualFunction(6)]
    public partial void Destroy(GameObject* self);

    [VirtualFunction(7)]
    public partial void RequestRemoval(GameObject* self);

    [VirtualFunction(7)]
    public partial Bool8 IsSafeToRemove(GameObject* self);

    [VirtualFunction(8)]
    public partial void Remove(GameObject* self);

    [VirtualFunction(14)]
    public partial int GetDataPriority(GameObject* self);

    [VirtualFunction(15)]
    public partial Bool8 HasControl(GameObject* self);

    [VirtualFunction(16)]
    public partial void Hide(GameObject* self);

    [VirtualFunction(17)]
    public partial void Show(GameObject* self);

    [VirtualFunction(22)]
    public partial void UpdateDead(BattleObject* self);

    [VirtualFunction(29)]
    public partial int AdjustStat(BattleObject* self, int delta, int statIndex, Bool8 a4);
}
