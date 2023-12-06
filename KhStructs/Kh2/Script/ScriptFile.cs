using System.Runtime.CompilerServices;

namespace KhStructs.Kh2.Script;

// size=variable due to code
/// <summary>
/// This struct expects the entrypoint table and code to follow in memory, do not use if that is not the case.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ScriptFile {
    public ScriptFileHeader Header;

    public Span<EntrypointData> Entrypoints {
        get {
            var start = (EntrypointData*)((ScriptFile*)Unsafe.AsPointer(ref this) + 1);
            var len = 0;
            for (var end = start; end->Offset != 0; end++, len++) {
            }

            return new Span<EntrypointData>(start, len);
        }
    }

    public ushort* Code {
        get {
            var entrypoints = this.Entrypoints;
            return (ushort*)(entrypoints.GetPointer(entrypoints.Length - 1) + 2);
        }
    }
}
