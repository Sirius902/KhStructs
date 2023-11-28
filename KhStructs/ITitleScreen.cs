using KhStructs.Game.Kh2;
using KhStructs.Internal;

namespace KhStructs;

public interface ITitleScreen {
    public bool IsOnTitleScreen { get; }

    public void SoftReset();

    public static ITitleScreen Instance(SupportedGame game) => game switch {
        SupportedGame.Kh2 => new TitleScreen(),
        SupportedGame.Kh1 or SupportedGame.ReCom or SupportedGame.Bbs or SupportedGame.Ddd => new DummyTitleScreen(),
        _ => throw Util.EnumArgumentException(nameof(game), game),
    };

    // TODO: Remove once other games have implementations.
    private class DummyTitleScreen : ITitleScreen {
        public bool IsOnTitleScreen => true;

        public void SoftReset() {
        }
    }
}
