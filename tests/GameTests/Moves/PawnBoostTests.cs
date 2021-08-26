using System.Linq;
using CreateAndFake;
using CreateAndFake.Fluent;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;
using GambitChess.Game.Pieces;
using Xunit;

namespace GambitChess.GameTests.Moves
{
    public static class PawnBoostTests
    {
        [Theory, RandomData]
        internal static void Make_MovesContent(Square start, Square end, Square skipped)
        {
            IPiece? piece = start.Content;

            PawnBoost instance = new(start, end, skipped);
            instance.Make();

            start.Content.Assert().Is(null);
            end.Content.Assert().Is(piece);
        }

        [Theory, RandomData]
        internal static void Undo_FullyResets(Square start, Square end, Square skipped)
        {
            Square startCopy = start.CreateDeepClone();
            Square endCopy = end.CreateDeepClone();

            PawnBoost instance = new(start, end, skipped);
            instance.Make();
            instance.Undo();

            start.Assert().Is(startCopy);
            end.Assert().Is(endCopy);
        }

        [Theory, RandomData]
        internal static void Changes_GivesAllSquares(Square start, Square end, Square skipped)
        {
            new PawnBoost(start, end, skipped).Changes().ToArray().Assert().Is(new[] { start, end });
        }

        [Theory, RandomData]
        internal static void Skipped_MatchesGiven(Square start, Square end, Square skipped)
        {
            new PawnBoost(start, end, skipped).Skipped.Assert().Is(skipped);
        }
    }
}
