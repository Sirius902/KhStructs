namespace KhStructs.Game.Kh2;

using Iced.Intel;

public sealed unsafe class TitleScreen : ITitleScreen {
    private ISigScanner scanner;

    public TitleScreen(ISigScanner scanner) {
        this.scanner = scanner;
        var cmpSoftResetAddress = scanner.ScanText("80 3D ?? ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0");
        var cmpPtr = (byte*)cmpSoftResetAddress;
        var decoder = Decoder.Create(64, new PointerCodeReader(cmpPtr, 7), (ulong)cmpSoftResetAddress);
        var cmp = decoder.Decode();
        if (cmp.Op0Kind != OpKind.Memory) {
            throw new Exception($"cmp had invalid OpKind: {cmp.Op0Kind}");
        }

        this.DoSoftReset = (bool*)cmp.MemoryDisplacement64;
    }

    public TitleScreen() : this(ISigScanner.Instance!) {
    }

    public bool* DoSoftReset { get; }

    // TODO: Implement.
    public bool IsOnTitleScreen => true;

    public void SoftReset() {
        *this.DoSoftReset = true;
    }

    private class PointerCodeReader : CodeReader {
        private readonly byte* end;
        private byte* pos;

        public PointerCodeReader(byte* start, int len) {
            this.pos = start;
            this.end = start + len;
        }

        public override int ReadByte() {
            if (this.pos == this.end) {
                return -1;
            }

            return *this.pos++;
        }
    }
}
