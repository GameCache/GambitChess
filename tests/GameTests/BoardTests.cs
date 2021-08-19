using CreateAndFake.Fluent;
using GambitChess.Game;
using GambitChess.Game.Boards;
using Xunit;

namespace GambitChess.GameTests
{
    public static class BoardTests
    {
        [Fact]
        internal static void Test()
        {
            ((PlayerBoard)Variant.Standard.SetupBoard()).DebugPrint().Assert().Fail();
        }

        [Fact]
        internal static void Test2()
        {
            Variant.Standard.SetupBoard().ToString().Assert().Fail();
        }
    }
}
