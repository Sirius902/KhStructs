using System.Runtime.CompilerServices;
using KhStructs.Kh2.Attack;

namespace KhStructs.Kh2.Object;

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Enemy {
    public BattleObject BattleObject;

    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 48 8B DA 8B 4A 20 E8 ?? ?? ?? ??")]
    public partial void HandleDamage(Damage* damage);
}
