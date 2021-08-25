using System.Collections.Generic;

namespace GambitChess.Game.Boards
{
    /// <summary>Chess board for player interaction.</summary>
    public interface IPlayerBoard
    {
        /// <summary>Finds all possible moves for the current position.</summary>
        /// <returns>Found moves.</returns>
        IEnumerable<string> GenerateMoves();

        string Make(string move);

        string Undo(int count = 1);

        string DebugPrint();
    }
}