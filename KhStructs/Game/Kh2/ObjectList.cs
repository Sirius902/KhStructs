namespace KhStructs.Game.Kh2;

public class ObjectList : IObjectList {
    private ISigScanner scanner;

    public ObjectList(ISigScanner scanner) {
        this.scanner = scanner;
    }

    public ObjectList() : this(ISigScanner.Instance!) {
    }

    public IEnumerable<IObject> Objects => throw new NotImplementedException();
}
