using CreateAndFake.Fluent;
using GambitChess.Game;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
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

        [Fact]
        internal static void BenchTest()
        {
            IBoardEngine board = ((PlayerBoard)Variant.Standard.SetupBoard())._board;
            GameLoop(0, board, 5).Assert().Fail();
        }

        private static int GameLoop(int current, IBoardEngine board, int max)
        {
            int count = 0;
            if (current < max)
            {
                foreach (IMove move in board.GenerateMoves())
                {
                    board.Make(move);
                    count += GameLoop(current + 1, board, max);
                    board.Undo();
                }
            }
            return count + 1;
        }
    }
}
