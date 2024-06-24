using KhStructs.Util;

namespace KhStructs.Kh2.Sound;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Sound {
    [StaticAddress("48 8D 1D ?? ?? ?? ?? 4C 8D 74 24 ?? 66 90", 3)]
    public static partial int* FieldBgmId();

    [StaticAddress("89 2D ?? ?? ?? ?? EB 5A", 2)]
    public static partial int* BattleBgmId();

    [MemberFunction("48 83 EC 38 45 33 C0 C6 05 ?? ?? ?? ?? ??")]
    public static partial void StartHpAlert();

    [MemberFunction("E8 ?? ?? ?? ?? EB 52 49 8B 4E 40")]
    public static partial void StopHpAlert();

    [MemberFunction("83 79 24 01 74 09")]
    public static partial Bool8 IsShouldStartHpAlert();

    [MemberFunction("83 79 24 01 75 09")]
    public static partial Bool8 IsShouldStopHpAlert();

    [MemberFunction("E8 ?? ?? ?? ?? 84 DB 0F B6 F0")]
    public static partial Bool8 IsHpAlertStarted();

    [MemberFunction("E8 ?? ?? ?? ?? EB 8F 33 D2")]
    public static partial void StartBgm(uint bank, int startVolume, int endVolume, int count, int delay);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BF 4F 08")]
    public static partial void StopBgm(uint bank);

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 47 18 33 D2")]
    public static partial Utf8StringView GetBgmFilePath(uint bgmId);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 43 0C 39 43 08")]
    public static partial void ReadBgmThread(Task.Task* thread);
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct ReadBgmThreadUserData {
    [FieldOffset(0x00)] public Utf8StringView FilePath;
    [FieldOffset(0x08)] public uint BgmId;
    [FieldOffset(0x10)] public uint Bank;
    [FieldOffset(0x18)] public MemoryAllocator* Allocator;
}
