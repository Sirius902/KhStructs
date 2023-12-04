namespace KhStructs.Kh2.Save;

// TODO: Fill out.
// size=???
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct SaveData {
    [StaticAddress("48 8D 04 52 48 8D 15 ?? ?? ?? ??", 7, isPointer: true)]
    public static partial SaveData* Instance();
}
