using KhStructs.Util;

namespace KhStructs.Kh2.Bar;

public unsafe partial struct BarTable {
    [StaticAddress("48 8B 1D ?? ?? ?? ?? 8B F1 48 85 DB 74 74", 3, isPointer: false)]
    public static partial NativeList<BarTableEntry>* List();

    [StaticAddress("4C 89 25 ?? ?? ?? ?? 41 8B F4", 3, isPointer: false)]
    public static partial NativeList<BarTableEntry>* ClearList();

    [StaticAddress("48 89 05 ?? ?? ?? ?? 33 C0 89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ??", 3, isPointer: false)]
    public static partial MemoryAllocator** Allocator();

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 33 C0", 3, isPointer: false)]
    public static partial byte* AllocatorBuffer();

    // TODO: Find out length. Possibly 7.
    [StaticAddress("89 05 ?? ?? ?? ?? 48 89 05 ?? ?? ?? ?? 89 05 ?? ?? ?? ?? C7 05 ?? ?? ?? ?? ?? ?? ?? ??", 2, isPointer: false)]
    public static partial int* GroupSizeTable();

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 4C 89 75 C0", 3, isPointer: false)]
    public static partial byte* StorageBegin();

    [StaticAddress("48 8B 35 ?? ?? ?? ?? 4C 8D 35 ?? ?? ?? ??", 3, isPointer: false)]
    public static partial byte** UngroupedFlushBegin();

    [StaticAddress("48 89 35 ?? ?? ?? ?? 48 8B 4D F8", 3, isPointer: false)]
    public static partial byte** UngroupedFlushEnd();

    // TODO: I don't believe this should return a value but hooking it causes the inner function to be hooked so to be safe it should probably be typed with a return value.
    [MemberFunction("E8 ?? ?? ?? ?? 8B 4B 50 85 C9")]
    public static partial BarTableEntry* QueueLoad(Utf8StringView filePath, int priority, nuint size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 44 DF ??")]
    public static partial BarTableEntry* QueueLoadInner(Utf8StringView filePath, int priority, nuint size);

    [MemberFunction("E8 ?? ?? ?? ?? 45 85 E4 74 1C")]
    public static partial void QueueLocalizationLoad(Utf8StringView filePath, int priority, short bank, nuint size);

    [MemberFunction("E8 ?? ?? ?? ?? 0F 57 FF 0F 1F 00")]
    public static partial void Flush(Task.Task* thread);

    [MemberFunction("E8 ?? ?? ?? ?? 80 7E 74 00")]
    public static partial void WaitForFlush(Task.Task* thread);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 E5")]
    public static partial Bool8 IsFlushing();

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 12 8B 05 ?? ?? ?? ??")]
    public static partial Bool8 IsFlushNeeded();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 63 0D ?? ?? ?? ??")]
    public static partial BarFile* Acquire(Utf8StringView fileName, int priority);

    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 89 3B")]
    public static partial void Release(BarFile* bar);

    [MemberFunction("40 57 48 83 EC 50 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 44 24 ?? 48 8B F9")]
    public static partial void* Alloc(nuint size);

    [MemberFunction("40 53 48 83 EC 20 80 39 42")]
    public static partial void Free(void* ptr);

    [MemberFunction("E8 ?? ?? ?? ?? 83 0F 01")]
    public static partial void Clean(int priority);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 05 ?? ?? ?? ?? 89 05 ?? ?? ?? ??")]
    public static partial void UnloadAll();

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 09 C6 40 01 00")]
    public static partial BarTableEntry* GetEntryByName(Utf8StringView fileName, int priority);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 4E 02")]
    public static partial void UnloadPriority(int priority);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 33 FF 48 8B D9 8B C7 48 85 C0 75 09 48 8B 05 ?? ?? ?? ?? EB 08 8B 48 70 E8 ?? ?? ?? ?? 48 85 C0 74 3C")]
    public static partial int GetPriority(Utf8StringView fileName);

    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ??")]
    public static partial void SetGroupSize(int group, int size);

    [MemberFunction("E9 ?? ?? ?? ?? 83 E9 01 74 27")]
    public static partial void SetPartyGroupSize(int playerSize, int friendSize);

    [MemberFunction("E8 ?? ?? ?? ?? 49 83 C6 08 41 FF C7")]
    public static partial void InsertEntry(BarTableEntry* entry);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 43 48 89 43 68")]
    public static partial void RemoveEntry(BarTableEntry* entry);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B 1D ?? ?? ?? ?? 48 8D 3D ?? ?? ?? ??")]
    public static partial nuint RemainingCapacity();

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 02 7C 2F")]
    public static partial Enum32<BarTableEntryStatus> GetStatus(Utf8StringView fileName);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 1D ?? ?? ?? ?? 48 8B 2D ?? ?? ?? ??")]
    public static partial void Commit();
}
