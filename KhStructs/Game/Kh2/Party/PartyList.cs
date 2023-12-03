namespace KhStructs.Game.Kh2.Party;

// TODO: Might be larger.
// size=0x28?
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct PartyList {
    [FixedSizeArray<Pointer<GameObject.GameObject>>(3)]
    public fixed byte Members[3 * 8];
    public fixed int Flags18[3];

    public GameObject.GameObject* Player => Instance()->MembersSpan[0];

    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 C7 04 C1 ?? ?? ?? ?? 83 4C 81 ?? ??", 3, isPointer: false)]
    public static partial PartyList* Instance();
}
