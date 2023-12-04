using KhStructs.Game.Kh2.Task;

namespace KhStructs.Game.Kh2.GameMode;

// GAME_MODE

// size=0x30
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct GameMode {
    public void* vtbl;
    public TaskManager* TaskManager;
    public int DWord10;
    public int NextHash;
    public int DWord18;
    public int DWord1C;
    public int DWord20;
    public Status Status;
    public void* PVoid28;

    public static GameMode* ListTail() => ListHead() + 1;

    [StaticAddress("C6 05 ?? ?? ?? ?? ?? 33 D2 48 8B CF", 2, isPointer: false, 5)]
    public static partial bool* SoftResetFlag();

    [StaticAddress("BA ?? ?? ?? ?? 89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 8D 48 01", 7, isPointer: false)]
    public static partial ControlFlags* ControlFlags();

    [StaticAddress("48 89 1D ?? ?? ?? ?? E8 ?? ?? ?? ?? 89 43 14 EB 0F", 3, isPointer: true)]
    public static partial GameMode* ListHead();

    [StaticAddress("8B 05 ?? ?? ?? ?? 85 C0 0F 85 ?? ?? ?? ?? 8B 05 ?? ?? ?? ??", 2, isPointer: false)]
    public static partial GlobalFlags* GlobalFlags();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8D 05 ?? ?? ?? ?? 48 8B CF")]
    public static partial GameMode* GameplayInstance();

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
    public static partial Task.Task* QueueGameplayTask(int a1, int priority, delegate* unmanaged<Task.Task*, void> run);
}
