using System.Collections.Generic;

namespace GambitChess.Game.Boards
{
    /// <summary>Chess board for player interaction.</summary>
    public interface IPlayerBoard
    {
        /// <summary>Finds all possible moves for the current position.</summary>
        /// <returns>Found moves.</returns>
        IEnumerable<string> GenerateMoves();

        /// <summary>Finds and makes the move on the board.</summary>
        /// <param name="move">Move to make.</param>
        void Make(string move);

        /// <summary>Unmakes <paramref name="count"/> moves on the board.</summary>
        /// <param name="count">Number of moves to undo.</param>
        void Undo(int count = 1);

        /// <summary>Temporary full detailed print of the board.</summary>
        /// <returns>Representation of the board.</returns>
        string DebugPrint();
    }
}