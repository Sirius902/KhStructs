using System.Runtime.CompilerServices;
using KhStructs.Kh2.Object.Entry;
using KhStructs.Kh2.Object.Util;
using KhStructs.Math;
using KhStructs.Util;

namespace KhStructs.Kh2.Object;

// YS::BTLOBJ
//   YS::STDOBJ
//     YS::OBJ

// size=???
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct BattleObject {
    public StandardObject StandardObject;

    public static IEnumerable<Pointer<BattleObject>> All() => new ObjectEnumerator<BattleObject>(&Iterate);

    public GameObject* Object => (GameObject*)Unsafe.AsPointer(ref this);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 4B 08 33 F6")]
    public partial BattleObject* Create(ObjectEntry* entry, byte priority, Vector4* pos, float rot);

    [MemberFunction("E9 ?? ?? ?? ?? CC CC 40 53 48 83 EC 20 8B 8A ?? ?? ?? ??")]
    public partial void Dispose();

    /// <summary>
    /// <see cref="GameObject.Iterate"/>
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 DD")]
    public static partial BattleObject* Iterate(BattleObject* battleObject);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 46 01 3C 01")]
    public partial void AddMp(int delta, Bool8 a2);
}
