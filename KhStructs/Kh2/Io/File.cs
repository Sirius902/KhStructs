using KhStructs.Util;

namespace KhStructs.Kh2.Io;

public unsafe partial struct File {
    [MemberFunction("E8 ?? ?? ?? ?? EB 0C 4C 8D 05 ?? ?? ?? ??")]
    public static partial void ReadBar(Utf8StringView filePath, void* buffer,
        delegate* unmanaged[Stdcall]<void*, nuint, void*, void> callback, void* arg);

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C0 0F")]
    public static partial nuint GetSize(Utf8StringView filePath);
}
