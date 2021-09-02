using System.Collections.Generic;

namespace GambitChess.Game.Boards
{
    /// <summary>Provides queries over board state.</summary>
    internal interface IBoardState
    {
        /// <summary>Translates coordinates to a square.</summary>
        /// <param name="x">Horizontal row rank.</param>
        /// <param name="y">Vertical column file.</param>
        /// <returns>Found square for the coordinates.</returns>
        Square CheckSpace(int x, int y);

        /// <summary>Calculates which squares are currently threatened by opposing pieces.</summary>
        /// <returns>All squares under threat by opponent pieces.</returns>
        ISet<Square> FindThreatenedSquares();

        /// <summary>Finds the en passant target square potentially generated from the last move.</summary>
        /// <returns>The square if it exists; null otherwise.</returns>
        Square? GetEnPassantTarget();

        /// <summary>Determines if the <paramref name="location"/> is not in its original state.</summary>
        /// <param name="location">Square to check state of.</param>
        /// <returns>True if changed; false otherwise.</returns>
        bool HasChanged(Square location);
    }
}