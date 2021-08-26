using System.Linq;
using CreateAndFake;
using CreateAndFake.Fluent;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
using GambitChess.Game.Pieces;
using Xunit;

namespace GambitChess.GameTests.Moves
{
    public static class CastleTests
    {
        [Theory, RandomData]
        internal static void Make_MovesContent(Square kingStart, Square kingEnd, Square rookStart, Square rookEnd)
        {
            IPiece? king = kingStart.Content;
            IPiece? rook = rookStart.Content;

            Castle instance = new(kingStart, kingEnd, rookStart, rookEnd);
            instance.Make();

            kingEnd.Content.Assert().Is(king);
            rookEnd.Content.Assert().Is(rook);
        }

        [Theory, RandomData]
        internal static void Undo_FullyResets(Square kingStart, Square kingEnd, Square rookStart, Square rookEnd)
        {
            kingEnd.Content = null;
            rookEnd.Content = null;

            Square kingStartCopy = kingStart.CreateDeepClone();
            Square kingEndCopy = kingEnd.CreateDeepClone();
            Square rookStartCopy = rookStart.CreateDeepClone();
            Square rookEndCopy = rookEnd.CreateDeepClone();

            Castle move = new(kingStart, kingEnd, rookStart, rookEnd);
            move.Make();
            move.Undo();

            kingStart.Assert().Is(kingStartCopy);
            kingEnd.Assert().Is(kingEndCopy);
            rookStart.Assert().Is(rookStartCopy);
            rookEnd.Assert().Is(rookEndCopy);
        }

        [Theory, RandomData]
        internal static void Changes_GivesAllSquares(Square kingStart, Square kingEnd, Square rookStart, Square rookEnd)
        {
            new Castle(kingStart, kingEnd, rookStart, rookEnd)
                .Changes()
                .ToArray()
                .Assert()
                .Is(new[] { kingStart, kingEnd, rookStart, rookEnd });
        }

        internal static void IsCapture_False(Castle move)
        {
            move.IsCapture.Assert().Is(false);
        }
    }
}