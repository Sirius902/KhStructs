using KhStructs.Kh2.Scene.World;

namespace KhStructs.Kh2.Save;

// TODO: Fill out.
// size=0x10FC0
[StructLayout(LayoutKind.Explicit, Size = 0x10FC0)]
public unsafe partial struct SaveData {
    [FixedString("FileMagic")] [FieldOffset(0x00)]
    public fixed byte FileMagicBytes[4];

    [FieldOffset(0x0C)] public World World;
    [FieldOffset(0x0D)] public byte Room;
    [FieldOffset(0x0E)] public byte Entrance;

    [FixedSizeArray<WorldSceneParams>(Scene.Scene.WorldMax)] [FieldOffset(0x10)]
    public fixed byte WorldSceneParams[Scene.Scene.WorldMax * 0x40 * 6];

    [FieldOffset(0x24F0)] public BattleData Battle;

    [FieldOffset(0x36C0)] public byte FormsAndSummonsUnlockedFlags1;
    [FieldOffset(0x36CA)] public byte FormsAndSummonsUnlockedFlags2;

    [FieldOffset(0x1CE5)] public byte DriveGaugeUnlockedFlags;

    public bool DriveGaugeUnlocked {
        get => (this.DriveGaugeUnlockedFlags & (1 << 2)) != 0;
        set {
            this.DriveGaugeUnlockedFlags &= 1 << 2;
            this.DriveGaugeUnlockedFlags |= (byte)(value ? 1 << 2 : 0);
        }
    }

    // Data for number of enemies defeated and RCs used seems to follow here.

    public ref Scene.Params SceneParams(World world, byte room) =>
        ref this.WorldSceneParamsSpan[(int)world].RoomParamsSpan[room];

    [MemberFunction("E8 ?? ?? ?? ?? B1 0A")]
    public static partial SaveData* Instance();
}
