using System.Runtime.CompilerServices;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Util;

namespace KhStructs.Kh2.Object;

// YS::PARTY
//   YS::BTLOBJ
//     YS::STDOBJ
//       YS::OBJ

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Party {
    public BattleObject BattleObject;

    public StandardObject* StandardObject => (StandardObject*)Unsafe.AsPointer(ref this.BattleObject.StandardObject);
    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this.StandardObject->Object);

    [MemberFunction("E8 ?? ?? ?? ?? FF C3 83 FB 02 7C DE")]
    public partial void SetWeapon(ObjectId weaponId, Hand hand);

    [MemberFunction("44 89 4C 24 ?? 48 89 4C 24 ?? 53")]
    public partial void ChangeWeapon(Task.Task* task, int partyIndex, Hand hand, Enum32<Item.Item> item);
}
