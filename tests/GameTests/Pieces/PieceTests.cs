using System.Collections.Generic;
using System.Linq;
using CreateAndFake.Fluent;
using GambitChess.Game.Boards;

namespace GambitChess.GameTests.Pieces
{
    public static class PieceTests
    {
        internal static void VerifyMoves(IPlayerBoard board, params string[] testPositions)
        {
            HashSet<string> remaining = testPositions.ToHashSet();
            foreach (string move in board.GenerateMoves())
            {
                board.Make(move);
                remaining.RemoveWhere(r => (board.ToString() ?? "").Contains(r));
                board.Undo();
            }
            remaining.Assert().IsEmpty();
        }
    }
}