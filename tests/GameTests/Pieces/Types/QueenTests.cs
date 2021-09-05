using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class QueenTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2Q2/5/5"),
                "2Q2/5/5/5/5",
                "5/2Q2/5/5/5",
                "5/5/5/2Q2/5",
                "5/5/5/5/2Q2",
                "5/5/4Q/5/5",
                "5/5/3Q1/5/5",
                "5/5/1Q3/5/5",
                "5/5/Q4/5/5",
                "Q4/5/5/5/5",
                "4Q/5/5/5/5",
                "5/1Q3/5/5/5",
                "5/3Q1/5/5/5",
                "5/5/5/1Q3/5",
                "5/5/5/3Q1/5",
                "5/5/5/5/Q4",
                "5/5/5/5/4Q");
        }

        [Fact]
        internal static void GenerateMoves_WithCaptures()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("Q1q/qq1/3"),
                "1Qq/qq1/3",
                "2Q/qq1/3",
                "2q/Qq1/3",
                "2q/qQ1/3");
        }

        [Fact]
        internal static void GenerateMoves_Blocked()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("QQ1/QQ1/3"),
                "Q1Q/QQ1/3",
                "Q2/QQQ/3",
                "QQ1/Q1Q/3",
                "QQQ/Q2/3",
                "QQ1/1Q1/Q2",
                "QQ1/1Q1/1Q1",
                "QQ1/Q2/Q2",
                "QQ1/Q2/1Q1",
                "QQ1/Q2/2Q");
        }
    }
}