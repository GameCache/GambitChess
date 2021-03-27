using CreateAndFake.Fluent;
using GambitChess.Multiplayer;
using Xunit;

namespace GambitChess.MultiplayerTests
{
    public static class DummyMultiplayerTests
    {
        [Fact]
        internal static void Exists_IsTrue()
        {
            DummyMultiplayer.Exists.Assert().Is(true);
        }
    }
}
