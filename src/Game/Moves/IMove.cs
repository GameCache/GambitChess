using System.Collections.Generic;
using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a chess move on a board.</summary>
    internal interface IMove
    {
        /// <summary>If the move captures a piece.</summary>
        bool IsCapture { get; }

        /// <summary>Makes the move on the board.</summary>
        void Make();

        /// <summary>Unmakes the move on the board.</summary>
        void Undo();

        /// <summary>Finds the squares the move touches.</summary>
        /// <returns>The found squares.</returns>
        IEnumerable<Square> Changes();
    }
}