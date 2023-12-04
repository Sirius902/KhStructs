namespace KhStructs.Kh2.Task;

// TASK_MANAGER
//   ALLOCATOR

// size=0x48
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct TaskManager {
    [FieldOffset(0x00)] public Allocator Allocator;
    [FieldOffset(0x08)] public Allocator* BackingAllocator;
    [FieldOffset(0x10)] public Task* TaskListHead;
    [FieldOffset(0x18)] public Task* TaskListLast;
    [FieldOffset(0x20)] public void* PVoid20;
    [FieldOffset(0x28)] public void* PVoid28;

    [FieldOffset(0x40)] public Task* TaskQueueHead;

    [MemberFunction("E8 ?? ?? ?? ?? 41 B8 ?? ?? ?? ?? EB 69")]
    public static partial TaskManager* Create(Allocator* allocator);

    [MemberFunction("E8 ?? ?? ?? ?? 89 58 18 48 83 C4 20")]
    public static partial Task* QueueTask(TaskManager* taskManager, int a2, int priority, delegate* unmanaged<Task*, void> run);
}
