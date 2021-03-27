using CreateAndFake.Fluent;
using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests
{
    public static class DummyGameTests
    {
        [Fact]
        internal static void Exists_IsTrue()
        {
            DummyGame.Exists.Assert().Is(true);
        }
    }
}
