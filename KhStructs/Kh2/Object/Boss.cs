using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Object;

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Boss {
    public Enemy Enemy;

    public BattleObject* BattleObject => (BattleObject*)Unsafe.AsPointer(ref this.Enemy.BattleObject);
    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this.BattleObject->StandardObject);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this.StandardObject->Object);
}
