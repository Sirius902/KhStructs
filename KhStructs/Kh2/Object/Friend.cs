using System.Runtime.CompilerServices;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.VTable;
using KhStructs.Math;

namespace KhStructs.Kh2.Object;

// YS::FRIEND
//   YS::PARTY
//     YS::BTLOBJ
//       YS::STDOBJ
//         YS::OBJ

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Friend {
    public Party Party;

    public BattleObject* BattleObject => (BattleObject*)Unsafe.AsPointer(ref this.Party.BattleObject);
    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this.BattleObject->StandardObject);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this.StandardObject->Object);

    public static Span<ObjectId> ObjectIdsSpan => new(ObjectIds(), 2);

    [StaticAddress("33 C0 89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? C3", 11, isPointer: false)]
    public static partial ObjectId* ObjectIds();

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 30 4D 8B C8")]
    public partial Friend* Create(ObjectEntry* entry, Vector4* pos, float rot);

    [MemberFunction("48 63 82 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ??")]
    public partial void VTableDestroy(GameObjectVTable* vtable, Friend* self);
}
