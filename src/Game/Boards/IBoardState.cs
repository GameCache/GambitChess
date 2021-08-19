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

        ISet<Square> FindThreatenedSquares();

        bool HasChanged(Square location);
    }
}