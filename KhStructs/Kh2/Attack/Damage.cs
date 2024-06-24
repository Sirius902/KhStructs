using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Attack;

// size=???
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Damage {
    [FieldOffset(0x10)] public Hash<GameObject> AttackerHash;
    [FieldOffset(0x14)] public Hash<GameObject> TargetHash;

    [FieldOffset(0x1C)] public Hash<Attack> AttackHash;
    [FieldOffset(0x20)] public Hash<AttackEntry> AttackEntryHash;

    public GameObject* Attacker => this.AttackerHash.Lookup();
    public GameObject* Target => this.TargetHash.Lookup();

    public Attack* Attack => this.AttackHash.Lookup();
    public AttackEntry* AttackEntry => this.AttackEntryHash.Lookup();
}
