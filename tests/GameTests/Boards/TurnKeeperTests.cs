using System;
using CreateAndFake;
using GambitChess.Game.Boards;
using Xunit;

namespace GambitChess.GameTests.Boards
{
    public static class TurnKeeperTests
    {
        [Fact]
        internal static void TurnKeeper_InvalidCurrentThrows()
        {
            Tools.Asserter.Throws<ArgumentOutOfRangeException>(() => new TurnKeeper(-1));
            Tools.Asserter.Throws<ArgumentOutOfRangeException>(() => new TurnKeeper(1));
        }
    }
}
