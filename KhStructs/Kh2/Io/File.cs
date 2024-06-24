using KhStructs.Util;

namespace KhStructs.Kh2.Io;

public unsafe partial struct File {
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 47 78")]
    public static partial nuint Read(Utf8StringView filePath, void* buffer);

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C0 0F")]
    public static partial nuint GetSize(Utf8StringView filePath);

    [MemberFunction("E8 ?? ?? ?? ?? 8B C8 89 5F FC")]
    public static partial nuint ReadBar(Utf8StringView filePath, void* buffer);

    [MemberFunction("E8 ?? ?? ?? ?? EB 0C 4C 8D 05 ?? ?? ?? ??")]
    public static partial void ReadBarAsync(Utf8StringView filePath, void* buffer,
        delegate* unmanaged[Stdcall]<void*, nuint, void*, void> callback, void* arg);
}
