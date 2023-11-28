namespace KhStructs.Game.Kh2;

public sealed class PartyList : IPartyList {
    private ISigScanner scanner;

    public PartyList(ISigScanner scanner) {
        this.scanner = scanner;
    }

    public PartyList() : this(ISigScanner.Instance!) {
    }

    public IObject? Player => throw new NotImplementedException();
    public IObject? Slot1 => throw new NotImplementedException();
    public IObject? Slot2 => throw new NotImplementedException();
    public IEnumerable<IObject> PartyMembers => throw new NotImplementedException();
}
