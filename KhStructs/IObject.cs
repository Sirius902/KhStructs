using KhStructs.Internal;
using Object = KhStructs.Game.Kh2.Object;

namespace KhStructs;

public interface IObject {
    public uint Id { get; }
    public string Name { get; }

    public static IObject Instance(SupportedGame game) => game switch {
        SupportedGame.Kh2 => new Object(),
        SupportedGame.Kh1 or SupportedGame.ReCom or SupportedGame.Bbs or SupportedGame.Ddd => new DummyObject(),
        _ => throw Util.EnumArgumentException(nameof(game), game),
    };

    // TODO: Remove once other games have implementations.
    private class DummyObject : IObject {
        public uint Id => 0u;
        public string Name => "Not Implemented";
    }
}
