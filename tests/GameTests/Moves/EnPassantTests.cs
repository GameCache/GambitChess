using System.Linq;
using CreateAndFake;
using CreateAndFake.Fluent;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
using GambitChess.Game.Pieces;
using Xunit;

namespace GambitChess.GameTests.Moves
{
    public static class EnPassantTests
    {
        [Theory, RandomData]
        internal static void Make_MovesContent(Square start, Square end, Square captureLocation)
        {
            IPiece? piece = start.Content;

            EnPassant instance = new(start, end, captureLocation);
            instance.Make();

            start.Content.Assert().Is(null);
            end.Content.Assert().Is(piece);
            captureLocation.Content.Assert().Is(null);
        }

        [Theory, RandomData]
        internal static void Undo_FullyResets(Square start, Square end, Square captureLocation)
        {
            end.Content = null;
            Square startCopy = start.CreateDeepClone();
            Square endCopy = end.CreateDeepClone();
            Square captureCopy = captureLocation.CreateDeepClone();

            EnPassant instance = new(start, end, captureLocation);
            instance.Make();
            instance.Undo();

            start.Assert().Is(startCopy);
            end.Assert().Is(endCopy);
            captureLocation.Assert().Is(captureCopy);
        }

        [Theory, RandomData]
        internal static void Changes_GivesAllSquares(Square start, Square end, Square captureLocation)
        {
            new EnPassant(start, end, captureLocation).Changes().ToArray().Assert().Is(new[] { start, end, captureLocation });
        }

        [Theory, RandomData]
        internal static void ToString_Detailed(EnPassant move)
        {
            move.ToString().Assert().ContainsNot(nameof(EnPassant));
        }
    }
}
