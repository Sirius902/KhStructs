namespace KhStructs.Axa;

// Axa.DXInput

public unsafe partial struct DXInput {
    // TODO: Sig does not work on pre-Steam and EGS update versions.
    [MemberFunction(
        "E8 ?? ?? ?? ?? 4C 8B BC 24 ?? ?? ?? ?? 4C 8B B4 24 ?? ?? ?? ?? 4C 8B A4 24 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ?? 48 8B AC 24 ?? ?? ?? ??")]
    public static partial void* GetDirectInputDevice(int userIndex);

    [MemberFunction("40 56 41 56 48 83 EC 48 45 33 D2")]
    public static partial void UpdateKeyboardInput(AppInterface* app, nint a2, nint a3);
}
