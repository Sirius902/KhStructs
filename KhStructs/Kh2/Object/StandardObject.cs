using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.Util;
using KhStructs.Math;

namespace KhStructs.Kh2.Object;

// YS::STDOBJ
//   YS::OBJ

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct StandardObject {
    public GameObject Object;

    public static IEnumerable<Pointer<StandardObject>> All() => new ObjectEnumerator<StandardObject>(&Iterate);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 63 74 24 ??")]
    public partial StandardObject* Create(ObjectEntry* entry, byte priority, Vector4* pos, float rot);

    [MemberFunction(
        "48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 48 81 C1 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 83 BB ?? ?? ?? ?? ??")]
    public partial void Dispose();

    /// <summary>
    /// <see cref="GameObject.Iterate"/>
    /// </summary>
    [MemberFunction("48 83 EC 28 E8 ?? ?? ?? ?? 48 8B C8 48 85 C0 74 09")]
    public static partial StandardObject* Iterate(StandardObject* standardObject);
}
