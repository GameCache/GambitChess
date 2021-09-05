using GambitChess.Game;
using GambitChess.Game.Boards;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class PawnTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2P2/5/5"),
                "5/2P2/5/5/5");

            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2p2/5/5 b"),
                "5/5/5/2p2/5");
        }

        [Fact]
        internal static void GenerateMoves_WithCaptures()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/1pp2/2P2/5/5"),
                "5/1Pp2/5/5");

            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/2p2/2PP1/5 b"),
                "5/5/5/2Pp1/5");
        }

        [Fact]
        internal static void GenerateMoves_Blocked()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/2p2/2P2/5/5"));
        }

        [Fact]
        internal static void GenerateMoves_InitialPawnBoost()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/5/2P2/5"),
                "5/2P2/5/5/5",
                "5/5/2P2/5/5");

            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/2p2/5/5/5 b"),
                "5/5/5/2p2/5",
                "5/5/2p2/5/5");
        }

        [Fact]
        internal static void GenerateMoves_EnPassant()
        {
            IPlayerBoard board = Variant.Standard.SetupBoard("5/1p3/5/2P2/5");
            board.Make("c2-c4");

            PieceTests.VerifyMoves(
                board,
                "5/5/2p2/5/5",
                "5/2P2/1p3/5/5",
                "5/2P2/5/1p3/5");

            board = Variant.Standard.SetupBoard("5/1p3/5/2P2/5 b");
            board.Make("b4-b2");

            PieceTests.VerifyMoves(
                board,
                "5/5/1P3/5/5",
                "5/5/2P2/1p3/5",
                "5/2P2/5/1p3/5");
        }

        [Fact]
        internal static void GenerateMoves_PawnPromotions()
        {
            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/2P2/5/5/5"),
                "2N2/5/5/5/5",
                "2Q2/5/5/5/5",
                "2R2/5/5/5/5",
                "2B2/5/5/5/5");

            PieceTests.VerifyMoves(
                Variant.Standard.SetupBoard("5/5/5/2p2/2BR1 b"),
                "5/5/5/5/2Bn1",
                "5/5/5/5/2Bq1",
                "5/5/5/5/2Br1",
                "5/5/5/5/2Bb1");
        }
    }
}