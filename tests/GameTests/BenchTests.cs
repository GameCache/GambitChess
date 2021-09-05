using GambitChess.Game;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
using Xunit;

namespace GambitChess.GameTests.Boards
{
    public static class BenchTests
    {
        [Fact]
        internal static void SimpleBenchmark()
        {
            IBoardEngine board = ((PlayerBoard)Variant.Standard.SetupBoard())._board;
            GameLoop(0, board, 4);//.Assert().Fail();
        }

        private static int GameLoop(int current, IBoardEngine board, int max)
        {
            int count = 0;
            if (current < max)
            {
                foreach (IMove move in board.GenerateMoves())
                {
                    count += 1;
                    board.Make(move);
                    count += GameLoop(current + 1, board, max);
                    board.Undo();
                }
            }
            return count;
        }
    }
}
