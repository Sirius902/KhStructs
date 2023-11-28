using KhStructs.Game.Kh2;
using KhStructs.Internal;

namespace KhStructs;

public interface IObjectList {
    public IEnumerable<IObject> Objects { get; }

    public static IObjectList Instance(SupportedGame game) => game switch {
        SupportedGame.Kh2 => new ObjectList(),
        SupportedGame.Kh1 or SupportedGame.ReCom or SupportedGame.Bbs or SupportedGame.Ddd => new DummyObjectList(),
        _ => throw Util.EnumArgumentException(nameof(game), game),
    };

    // TODO: Remove once other games have implementations.
    private class DummyObjectList : IObjectList {
        public IEnumerable<IObject> Objects => Array.Empty<IObject>();
    }
}
