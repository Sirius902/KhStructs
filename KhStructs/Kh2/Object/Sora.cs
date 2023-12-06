using System.Runtime.CompilerServices;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.VTable;
using KhStructs.Math;
using KhStructs.Util;

namespace KhStructs.Kh2.Object;

// YS::SORA
//   YS::PLAYER
//     YS::PARTY
//       YS::BTLOBJ
//         YS::STDOBJ
//           YS::OBJ

// size=0xE18
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Sora {
    public Player Player;

    public Party* Party => (Party*)Unsafe.AsPointer(ref this.Player.Party);
    public BattleObject* BattleObject => (BattleObject*)Unsafe.AsPointer(ref this.Party->BattleObject);
    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this.BattleObject->StandardObject);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this.StandardObject->Object);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B B4 24 ?? ?? ?? ?? 48 8B F8")]
    public partial Sora* Create(ObjectEntry* entry, Enum32<ObjectForm> form, void* input, Vector4* pos, float rot);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 40 48 8B F9 48 C7 44 24 ?? ?? ?? ?? ??")]
    public partial void Init();

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B C7 48 8B 5C 24 ??")]
    public static partial Sora* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 89 47 50")]
    public static partial ObjectId GetObjectId(Enum32<ObjectForm> form);

    [MemberFunction("40 53 48 83 EC 20 48 8B CA 48 8B DA E8 ?? ?? ?? ?? 8B 83 ?? ?? ?? ?? 85 C0")]
    public static partial void VTableDestroy(GameObjectVTable* vtable, Sora* self);

    [MemberFunction("40 53 48 83 EC 20 8B 05 ?? ?? ?? ?? 48 8B DA")]
    public static partial void VTableUpdateDead(GameObjectVTable* vtable, Sora* self);
}
