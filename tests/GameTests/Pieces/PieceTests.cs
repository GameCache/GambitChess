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
            VerifyMoves(board, true, testPositions);
        }

        internal static void VerifySomeMoves(IPlayerBoard board, params string[] testPositions)
        {
            VerifyMoves(board, false, testPositions);
        }

        internal static void VerifyExcludesMoves(IPlayerBoard board, params string[] testPositions)
        {
            foreach (string move in board.GenerateMoves())
            {
                board.Make(move);
                testPositions.Where(p => (board.ToString() ?? "").Contains(p)).Assert().IsEmpty("Invalid position found.");
                board.Undo();
            }
        }

        private static void VerifyMoves(IPlayerBoard board, bool noExtras, string[] testPositions)
        {
            HashSet<string> remaining = testPositions.ToHashSet();
            IList<string> extras = new List<string>();

            foreach (string move in board.GenerateMoves())
            {
                board.Make(move);
                if (1 != remaining.RemoveWhere(r => (board.ToString() ?? "").Contains(r)))
                {
                    extras.Add(board.ToString() ?? "");
                }
                board.Undo();
            }

            if (noExtras)
            {
                extras.Assert().IsEmpty("Unexpected positions reached.");
            }

            remaining.Assert().IsEmpty("Expected positions missing.");
        }
    }
}