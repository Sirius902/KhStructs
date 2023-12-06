using KhStructs.Kh2.Magic;
using KhStructs.Kh2.Object;
using KhStructs.Util;

namespace KhStructs.Kh2.Command;

// size=???
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct Command {
    [FieldOffset(0x00)] public void* vtbl;

    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 40 10")]
    public static partial ushort GetMagicCommandId(Element element);

    [VirtualFunction(0)]
    public partial void Destruct(Bool8 isHeap);

    [VirtualFunction(1)]
    public partial void Init(Command* self, Player* player, void* input);
}
