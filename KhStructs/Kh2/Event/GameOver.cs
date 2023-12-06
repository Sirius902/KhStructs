using KhStructs.Kh2.Object;

namespace KhStructs.Kh2.Event;

// size=0x88
[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public unsafe partial struct GameOver {
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 F6 44 89 01")]
    public static partial void Init(GameOver* gameOver, GameObject* gameObject, int a3);

    [MemberFunction("40 53 48 83 EC 20 48 83 3D ?? ?? ?? ?? ?? 48 8B D9 75 22")]
    public static partial void Start(Player* player);

    [MemberFunction("E9 ?? ?? ?? ?? CC 48 8B 05 ?? ?? ?? ?? 48 85 C0 74 09")]
    public static partial void StartMiniGame(Player* player);

    [MemberFunction("48 83 EC 28 48 83 3D ?? ?? ?? ?? ?? 75 21")]
    public static partial void StartMission(Player* player);
}
