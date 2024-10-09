using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Object;

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Boss {
    public Enemy Enemy;

    public BattleObject* BattleObject => (BattleObject*)Unsafe.AsPointer(ref this);
    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this);
}
