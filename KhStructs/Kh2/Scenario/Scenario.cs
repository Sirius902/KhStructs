using KhStructs.Kh2.Mode;

namespace KhStructs.Kh2.Scenario;

// size=0xA?
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Scenario {
    public World.World World;
    public byte Room;
    public byte Door;
    public short Map;
    public short Battle;
    public short Event;

    /// <summary>
    /// Returns the current game scenario. When starting the game but before a save file is loaded on the title screen,
    /// this structure will be set to all 0xFF bytes. Do not use functions that expect valid scenario values when this is true.
    /// </summary>
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 19", 3, isPointer: false)]
    public static partial Scenario* Current();

    [StaticAddress("44 88 15 ?? ?? ?? ?? 44 88 1D ?? ?? ?? ??", 3, isPointer: false)]
    public static partial Scenario* Saved();

    /// <summary>
    /// This is not safe to call unless the Gameplay <see cref="GameMode"/> is active.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 09 73 04")]
    public static partial void Change(Scenario* newScenario, TransitionType transition, int a3, byte a4, int a5);

    /// <summary>
    /// Returns the two byte ASCII character code for the world.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 EB 19")]
    public static partial byte* WorldCode(World.World world);
}
