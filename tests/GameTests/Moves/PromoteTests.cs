using System.Linq;
using CreateAndFake;
using CreateAndFake.Fluent;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
using GambitChess.Game.Pieces;
using Xunit;

namespace GambitChess.GameTests.Moves
{
    public static class PromoteTests
    {
        [Theory, RandomData]
        internal static void Make_MovesContent(Square start, Square end, IPiece promotion)
        {
            Promote instance = new(start, end, promotion);
            instance.Make();

            start.Content.Assert().Is(null);
            end.Content.Assert().Is(promotion);
        }

        [Theory, RandomData]
        internal static void Undo_FullyResets(Square start, Square end, IPiece promotion)
        {
            Square startCopy = start.CreateDeepClone();
            Square endCopy = end.CreateDeepClone();

            Promote instance = new(start, end, promotion);
            instance.Make();
            instance.Undo();

            start.Assert().Is(startCopy);
            end.Assert().Is(endCopy);
        }

        [Theory, RandomData]
        internal static void Changes_GivesAllSquares(Square start, Square end, IPiece promotion)
        {
            new Promote(start, end, promotion).Changes().ToArray().Assert().Is(new[] { start, end });
        }

        [Theory, RandomData]
        internal static void IsCapture_MatchesEndContent(Square start, Square end, IPiece promotion)
        {
            new Promote(start, end, promotion).IsCapture.Assert().Is(true);
            end.Content = null;
            new Promote(start, end, promotion).IsCapture.Assert().Is(false);
        }
    }
}
