using KhStructs.Kh2.Object.Entry;
using KhStructs.Util;

namespace KhStructs.Kh2.Save;

// TODO: Fill out.
// size=0x1AFC
[StructLayout(LayoutKind.Explicit, Size = 0x1AFC)]
public unsafe partial struct BattleData {
    [FixedSizeArray<PartyData>(13)] [FieldOffset(0x00)]
    public fixed byte PartyData[13 * 0x114];

    [FixedSizeArray<FormData>(10)] [FieldOffset(0xE04)]
    public fixed byte FormData[10 * 0x38];

    [FieldOffset(0x1034)] public ObjectForm Form;

    [FieldOffset(0x103C)] public float FormGauge;
    [FieldOffset(0x1040)] public float MaxFormGauge;

    [MemberFunction("FF CA 83 FA 09")]
    public partial FormData* GetFormData(Enum32<ObjectForm> form);
}
