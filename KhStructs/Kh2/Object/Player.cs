using System.Runtime.CompilerServices;
using KhStructs.Kh2.Object.Entry;

namespace KhStructs.Kh2.Object;

// YS::PLAYER
//   YS::PARTY
//     YS::BTLOBJ
//       YS::STDOBJ
//         YS::OBJ

// size=0xE18
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Player {
    public Party Party;

    public BattleObject* BattleObject => (BattleObject*)Unsafe.AsPointer(ref this.Party.BattleObject);
    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this.BattleObject->StandardObject);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this.StandardObject->Object);

    [StaticAddress("48 89 47 18 48 8B 1D ?? ?? ?? ??", 7, isPointer: true)]
    public static partial Player* Instance();

    [StaticAddress("33 C0 89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? C3", 4, isPointer: false)]
    public static partial ObjectId* ObjectIdOverride();
}
