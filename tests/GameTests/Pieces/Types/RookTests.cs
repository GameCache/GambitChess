using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class RookTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2R2/5/5"),
                "2R2/5/5/5/5",
                "5/2R2/5/5/5",
                "5/5/5/2R2/5",
                "5/5/5/5/2R2",
                "5/5/4R/5/5",
                "5/5/3R1/5/5",
                "5/5/1R3/5/5",
                "5/5/R4/5/5");
        }

        [Fact]
        internal static void GenerateMoves_WithCaptures()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("R1r/r2/3"),
                "2R/r2/3",
                "2r/R2/3",
                "1Rr/r2/3");
        }

        [Fact]
        internal static void GenerateMoves_Blocked()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("RR1/3/R2"),
                "R1R/3/R2",
                "1R1/R2/R2",
                "RR1/R2/3",
                "R2/1R1/R2",
                "R2/3/RR1",
                "RR1/3/1R1",
                "RR1/3/2R");
        }
    }
}