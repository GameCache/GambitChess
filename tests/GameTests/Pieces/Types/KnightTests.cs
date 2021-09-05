using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class KnightTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("9/9/9/9/4N4/9/9/9/9"),
                "9/9/3N5/9/9/9/9/9/9",
                "9/9/5N3/9/9/9/9/9/9",
                "9/9/9/2N6/9/9/9/9/9",
                "9/9/9/6N2/9/9/9/9/9",
                "9/9/9/9/9/2N6/9/9/9",
                "9/9/9/9/9/6N2/9/9/9",
                "9/9/9/9/9/9/3N5/9/9",
                "9/9/9/9/9/9/5N3/9/9");
        }

        [Fact]
        internal static void GenerateMoves_WithCaptures()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("N2/2n/1n1"),
                "3/2N/1n1",
                "3/2n/1N1");
        }

        [Fact]
        internal static void GenerateMoves_Blocked()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("N2/2N/1N1"),
                "N2/3/NN1",
                "N1N/2N/3");
        }
    }
}