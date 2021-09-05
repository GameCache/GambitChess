using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class BishopTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2B2/5/5"),
                "B4/5/5/5/5",
                "4B/5/5/5/5",
                "5/1B3/5/5/5",
                "5/3B1/5/5/5",
                "5/5/5/1B3/5",
                "5/5/5/3B1/5",
                "5/5/5/5/B4",
                "5/5/5/5/4B");
        }

        [Fact]
        internal static void GenerateMoves_WithCaptures()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("BB1/1bb/3"),
                "1B1/1Bb/3",
                "B2/1bB/3",
                "B2/Bbb/3");
        }

        [Fact]
        internal static void GenerateMoves_Blocked()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("B2/1B1/3"),
                "B2/3/B2",
                "B2/3/2B",
                "B1B/3/3");
        }
    }
}