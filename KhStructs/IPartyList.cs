using KhStructs.Game.Kh2;
using KhStructs.Internal;

namespace KhStructs;

public interface IPartyList {
    public IObject? Player { get; }
    public IObject? Slot1 { get; }
    public IObject? Slot2 { get; }

    public IEnumerable<IObject> PartyMembers { get; }

    public static IPartyList Instance(SupportedGame game) => game switch {
        SupportedGame.Kh2 => new PartyList(),
        SupportedGame.Kh1 or SupportedGame.ReCom or SupportedGame.Bbs or SupportedGame.Ddd => new DummyPartyList(),
        _ => throw Util.EnumArgumentException(nameof(game), game),
    };

    // TODO: Remove once other games have implementations.
    private class DummyPartyList : IPartyList {
        public IObject? Player => null;
        public IObject? Slot1 => null;
        public IObject? Slot2 => null;
        public IEnumerable<IObject> PartyMembers => Array.Empty<IObject>();
    }
}
