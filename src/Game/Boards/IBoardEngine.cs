using System.Collections.Generic;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Boards
{
    /// <summary>Engine for running chess boards.</summary>
    internal interface IBoardEngine
    {
        /// <summary>Finds all possible moves for the current position.</summary>
        /// <returns>Found moves.</returns>
        IEnumerable<IMove> GenerateMoves();

        /// <summary>Makes the move on the board.</summary>
        /// <param name="move">Move to make.</param>
        void Make(IMove move);

        /// <summary>Unmakes <paramref name="count"/> moves on the board.</summary>
        /// <param name="count">Number of moves to undo.</param>
        void Undo(int count = 1);

        /// <summary>Temporary full detailed print of the board.</summary>
        /// <returns>Representation of the board.</returns>
        string DebugPrint();
    }
}