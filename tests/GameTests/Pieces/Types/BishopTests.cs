using GambitChess.Game;
using Xunit;

namespace GambitChess.GameTests.Pieces.Types
{
    public static class BishopTests
    {
        [Fact]
        internal static void GenerateMoves_ThroughEmpty()
        {
            PieceTests.VerifyMoves(Variant.Standard.SetupBoard("5/5/2B2/5/5"),
                "B4/5/5/5/5",
                "4B/5/5/5/5",
                "5/1B3/5/5/5",
                "5/3B1/5/5/5",
                "5/5/5/1B3/5",
                "5/5/5/3B1/5",
                "5/5/5/5/B4",
                "5/5/5/5/4B"
            );
        }
    }
}