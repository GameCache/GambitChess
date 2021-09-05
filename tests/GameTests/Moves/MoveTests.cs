using System.Linq;
using CreateAndFake;
using CreateAndFake.Fluent;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
using GambitChess.Game.Pieces;
using Xunit;

namespace GambitChess.GameTests.Moves
{
    public static class MoveTests
    {
        [Theory, RandomData]
        internal static void Make_MovesContent(Square start, Square end)
        {
            IPiece? piece = start.Content;

            Move instance = new(start, end);
            instance.Make();

            start.Content.Assert().Is(null);
            end.Content.Assert().Is(piece);
        }

        [Theory, RandomData]
        internal static void Undo_FullyResets(Square start, Square end)
        {
            Square startCopy = start.CreateDeepClone();
            Square endCopy = end.CreateDeepClone();

            Move instance = new(start, end);
            instance.Make();
            instance.Undo();

            start.Assert().Is(startCopy);
            end.Assert().Is(endCopy);
        }

        [Theory, RandomData]
        internal static void Changes_GivesAllSquares(Square start, Square end)
        {
            new Move(start, end).Changes().ToArray().Assert().Is(new[] { start, end });
        }

        [Theory, RandomData]
        internal static void IsCapture_MatchesEndContent(Square start, Square end)
        {
            new Move(start, end).IsCapture.Assert().Is(true);
            end.Content = null;
            new Move(start, end).IsCapture.Assert().Is(false);
        }

        [Theory, RandomData]
        internal static void ToString_Detailed(Move move)
        {
            move.ToString().Assert().ContainsNot(nameof(Move));
        }
    }
}
