using KhStructs.Kh2.Object;
using KhStructs.Math;
using KhStructs.Util;

namespace KhStructs.Kh2.Attack;

// size=???
[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct Attack {
    [FieldOffset(0x00)] public void* vtbl;
    [FieldOffset(0x08)] public int Flags8;
    [FieldOffset(0x0C)] public Hash<GameObject> InitiatorHash;
    [FieldOffset(0x10)] public Hash<GameObject> AttackerHash;
    [FieldOffset(0x14)] public Hash<GameObject> ObjectHash;

    [FieldOffset(0xC4)] public Hash NextHash;

    public GameObject* Initiator => this.InitiatorHash.Lookup();
    public GameObject* Attacker => this.AttackerHash.Lookup();
    public GameObject* Object => this.ObjectHash.Lookup();

    public Attack* Next => (Attack*)Hash.Lookup(this.NextHash);

    [StaticAddress("48 89 05 ?? ?? ?? ?? 8D 48 01 E8 ?? ?? ?? ?? C6 05 ?? ?? ?? ?? ??", 3)]
    public static partial NativeList<Attack>* List();

    [MemberFunction("E8 ?? ?? ?? ?? EB 75 48 8D 8B ?? ?? ?? ??")]
    public static partial Bool8 Strike(BattleObject* attacker, int a2, BattleObject* target, Vector4* direction,
        Bool8 a5);
}
