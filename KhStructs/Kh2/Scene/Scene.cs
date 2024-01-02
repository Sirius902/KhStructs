using KhStructs.Kh2.Mode;
using KhStructs.Util;

namespace KhStructs.Kh2.Scene;

// size=0xA
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Scene {
    public World.World World;
    public byte Room;
    public byte Entrance;
    public Params Params;

    public const int WorldMax = (int)Kh2.Scene.World.World.TheWorldThatNeverWas + 1;

    [StaticAddress("F3 0F 11 05 ?? ?? ?? ?? F3 0F 11 0D ?? ?? ?? ?? 48 8B F9", 4, isPointer: false)]
    public static partial float* MaxLoad();

    [StaticAddress("F3 0F 11 05 ?? ?? ?? ?? F3 0F 11 0D ?? ?? ?? ?? 48 8B F9", 12, isPointer: false)]
    public static partial float* CurrentLoad();

    /// <summary>
    /// Returns the current game scene. When starting the game but before a save file is loaded on the title screen,
    /// this structure will be set to all 0xFF bytes. Do not use functions that expect valid scene values when this is true.
    /// </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 19", 3, isPointer: false)]
    public static partial Scene* Current();

    [StaticAddress("74 05 E8 ?? ?? ?? ?? C6 05 ?? ?? ?? ?? ??", 9, isPointer: false, 5)]
    public static partial Bool8* IsLoaded();

    /// <summary>
    /// This is not safe to call unless the Field <see cref="GameMode"/> is active.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 09 73 04")]
    public static partial void Change(Scene* newScene, TransitionType transition, int a3, byte a4, int a5);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 40 8B 41 18")]
    public static partial void ChangeTask(Task.Task* task);

    [MemberFunction(
        "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B D9")]
    public static partial void InitThread(Task.Task* thread);

    [MemberFunction("40 53 48 83 EC 20 80 3D ?? ?? ?? ?? ?? 48 8B D9 75 05")]
    public static partial void StartTask(Task.Task* task);

    /// <summary>
    /// Returns the two byte ASCII character code for the world.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 EB 19")]
    public static partial Utf8StringView WorldCode(World.World world);

    [MemberFunction("E8 ?? ?? ?? ?? 89 58 10")]
    public static partial void* Alloc(nuint size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? 40 84 F6")]
    public static partial void Free(void* ptr);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4D 18")]
    public static partial Allocator* AllocatorInstance();

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 F3 0F 10 05 ?? ?? ?? ?? 33 DB")]
    public static partial void InitParams(Params* sceneParams);
}
