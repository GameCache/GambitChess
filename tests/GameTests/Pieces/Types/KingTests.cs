using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class KingTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2K2/5/5"),
                "5/2K2/5/5/5",
                "5/5/5/2K2/5",
                "5/5/3K1/5/5",
                "5/5/1K3/5/5",
                "5/1K3/5/5/5",
                "5/3K1/5/5/5",
                "5/5/5/1K3/5",
                "5/5/5/3K1/5");
        }

        [Fact]
        internal static void GenerateMoves_WithCaptures()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("K1k/kk1/3"),
                "1Kk/kk1/3",
                "2k/Kk1/3",
                "2k/kK1/3");
        }

        [Fact]
        internal static void GenerateMoves_Blocked()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("KK1/3/3"),
                "1K1/K2/3",
                "1K1/1K1/3",
                "K1K/3/3",
                "K2/K2/3",
                "K2/1K1/3",
                "K2/2K/3");
        }

        [Fact]
        internal static void GenerateMoves_Castles()
        {
            PieceTests.VerifySomeMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/8/R3K2R"),
                "8/8/8/8/8/8/8/R4RK1",
                "8/8/8/8/8/8/8/2KR3R");
        }

        [Fact]
        internal static void GenerateMoves_AbnormalCastles()
        {
            PieceTests.VerifySomeMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/8/3RKR2"),
                "8/8/8/8/8/8/8/2KR1R2",
                "8/8/8/8/8/8/8/3R1RK1");

            PieceTests.VerifySomeMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/8/4K1R1"),
                "8/8/8/8/8/8/8/5RK1");
        }

        [Fact]
        internal static void GenerateMoves_CastlesWithCloseThreat()
        {
            PieceTests.VerifySomeMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/rr5r/R3K2R"),
                "8/8/8/8/8/8/rr5r/R4RK1",
                "8/8/8/8/8/8/rr5r/2KR3R");
        }

        [Fact]
        internal static void GenerateMoves_BlockedCastle()
        {
            PieceTests.VerifyExcludesMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/8/Rp2KB1R"),
                "8/8/8/8/8/8/8/Rp3RK1",
                "8/8/8/8/8/8/8/1pKRB1R");
        }

        [Fact]
        internal static void GenerateMoves_ThreatPreventsCastle()
        {
            PieceTests.VerifyExcludesMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/1b5p/R3K2R"),
                "8/8/8/8/8/8/1b5p/R4RK1",
                "8/8/8/8/8/8/1b5p/2KR3R");

            PieceTests.VerifyExcludesMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/4r3/R3KR2"),
                "8/8/8/8/8/8/4r3/R4RK1",
                "8/8/8/8/8/8/4r3/2KR1R2");

            PieceTests.VerifyExcludesMoves(
                Variant.Standard.SetupBoard("8/8/8/8/8/8/6r1/2bRKR2"),
                "8/8/8/8/8/8/6r1/2bR1RK1",
                "8/8/8/8/8/8/6r1/2KR1R2");
        }
    }
}