using System.Runtime.CompilerServices;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.VTable;

namespace KhStructs.Kh2.Object;

// YS::WEAPON
//   YS::STDOBJ
//     YS::OBJ

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Weapon {
    public StandardObject StandardObject;

    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this.StandardObject.Object);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E8 4E 89 AC FF ?? ?? ?? ??")]
    public partial Weapon* Create(ObjectEntry* entry, Party* wielder, int neoMoveset, Hand hand, int priority);

    [MemberFunction("E8 ?? ?? ?? ?? 4E 89 AC FF ?? ?? ?? ??")]
    public partial void ForceDispose();

    [MemberFunction("40 53 48 83 EC 20 48 8D 8A ?? ?? ?? ?? 48 8B DA E8 ?? ?? ?? ?? 48 8B CB")]
    public static partial void VTableDestroy(GameObjectVTable* vtable, Weapon* self);
}
