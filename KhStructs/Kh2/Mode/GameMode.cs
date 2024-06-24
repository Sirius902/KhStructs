using KhStructs.Kh2.Task;
using KhStructs.Util;

namespace KhStructs.Kh2.Mode;

// GAME_MODE

// size=0x30
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct GameMode {
    public void* vtbl;
    public TaskManager* TaskManager;

    public int DWord10;

    // TypedHash<GameMode>
    public Hash NextHash;
    public int DWord18;
    public int DWord1C;
    public int DWord20;
    public Status Status;
    public void* PVoid28;

    public GameMode* Next => (GameMode*)Hash.Lookup(this.NextHash);

    [StaticAddress("BA ?? ?? ?? ?? 89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 8D 48 01", 7, isPointer: false)]
    public static partial ControlFlags* ControlFlags();

    [StaticAddress("48 89 1D ?? ?? ?? ?? E8 ?? ?? ?? ?? 89 43 14 EB 0F", 3, isPointer: false)]
    public static partial NativeList<GameMode>* List();

    [StaticAddress("8B 05 ?? ?? ?? ?? 85 C0 0F 85 ?? ?? ?? ?? 8B 05 ?? ?? ?? ??", 2, isPointer: false)]
    public static partial GlobalFlags* GlobalFlags();

    [MemberFunction("40 57 48 83 EC 40 83 79 24 03")]
    public partial void Start();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 74 24 ?? 48 8B 5C 24 ?? 48 8B 7C 24 ?? 32 C0")]
    public static partial void StartSoftReset();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? E8 ?? ?? ?? ?? 32 C0")]
    public static partial Bool8 IsSoftResetDisabled();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? 48 8B CF")]
    public static partial GameMode* FieldInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 E8 ?? ?? ?? ?? 48 8B F8")]
    public static partial GameMode* TitleInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? C7 44 24 ?? ?? ?? ?? ??")]
    public static partial GameMode* MenuInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 48 8B E8")]
    public static partial GameMode* ShopInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 39 85 ?? ?? ?? ??")]
    public static partial GameMode* GummiMissionInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 4C 8B F0")]
    public static partial GameMode* GummiMenuInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 89 58 30")]
    public static partial Task.Task* QueueFieldTask(int a1, int priority,
        delegate* unmanaged[Stdcall]<Task.Task*, void> run);
}
