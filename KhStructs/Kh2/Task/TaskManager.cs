using KhStructs.Util;

namespace KhStructs.Kh2.Task;

// TASK_MANAGER
//   ALLOCATOR

// size=0x48
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct TaskManager {
    [FieldOffset(0x00)] public Allocator Allocator;
    [FieldOffset(0x08)] public Allocator* BackingAllocator;
    [FieldOffset(0x10)] public NativeList<Task> Tasks;
    [FieldOffset(0x20)] public void* PVoid20;
    [FieldOffset(0x28)] public void* PVoid28;

    // TODO: This may also be a NativeList.
    [FieldOffset(0x40)] public Task* TaskQueueHead;

    [StaticAddress("4C 8D 0D ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? C7 44 24 ?? ?? ?? ?? ??", 10, isPointer: true)]
    public static partial TaskManager* SystemInstance();

    [MemberFunction("E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? EB 69")]
    public static partial TaskManager* Create(Allocator* allocator);

    [MemberFunction("E8 ?? ?? ?? ?? 89 58 18 48 83 C4 20")]
    public partial Task* CreateTask(int mask, int priority, delegate* unmanaged<Task*, void> run);

    [MemberFunction("E8 ?? ?? ?? ?? 88 58 18")]
    public partial Task* CreateThread(int mask, int priority, delegate* unmanaged<Task*, void> run);

    [MemberFunction("33 C0 48 85 C0 75 06")]
    public partial Bool8 TaskExists(delegate* unmanaged<Task*, void> run);

    /// <summary>
    /// Finishes and frees a task.
    /// </summary>
    /// <param name="task">The task.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C9 48 89 1D ?? ?? ?? ??")]
    public partial void FinishTask(Task* task);
}
