namespace KhStructs.Kh2.Save;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct WorldSceneParams {
    [FixedSizeArray<Scene.Params>(64)]
    public fixed byte RoomParams[64 * 6];
}
