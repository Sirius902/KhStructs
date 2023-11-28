namespace KhStructs.Game.Kh2;

public class Object : IObject {
    private ISigScanner scanner;

    public Object(ISigScanner scanner) {
        this.scanner = scanner;
    }

    public Object() : this(ISigScanner.Instance!) {
    }

    public uint Id => throw new NotImplementedException();
    public string Name => throw new NotImplementedException();
}
