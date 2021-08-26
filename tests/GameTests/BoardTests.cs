using CreateAndFake.Fluent;
using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests
{
    public static class BoardTests
    {
        [Fact]
        internal static void Test()
        {
            Variant.Standard.SetupBoard().DebugPrint().Assert().IsNot(null);
        }

        [Fact]
        internal static void Test2()
        {
            Variant.Standard.SetupBoard().ToString().Assert().IsNot(null);
        }
    }
}
