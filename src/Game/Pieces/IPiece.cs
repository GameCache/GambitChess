using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Pieces
{
    /// <summary>Represents a chess piece.</summary>
    internal interface IPiece
    {
        /// <summary>Max increment for rank movement.</summary>
        int MaxStepX { get; }

        /// <summary>Max increment for file movement.</summary>
        int MaxStepY { get; }

        /// <summary>Which side this piece is on.</summary>
        Side Side { get; }

        /// <summary>Textual representation of this piece.</summary>
        char Id { get; }

        /// <summary>Generates all possible moves for this piece on the board.</summary>
        /// <param name="board">Current board state.</param>
        /// <param name="container"><see cref="Square"/> containing this piece.</param>
        /// <param name="x">This piece's current rank position.</param>
        /// <param name="y">This piece's current file position.</param>
        /// <returns>All generated moves.</returns>
        IEnumerable<IMove> GenerateMoves(IBoardState board, Square container, int x, int y);

        /// <summary>Generates all <see cref="Square"/>s this piece can capture on.</summary>
        /// <param name="board">Current board state.</param>
        /// <param name="x">This piece's current rank position.</param>
        /// <param name="y">This piece's current file position.</param>
        /// <returns>All generated threats.</returns>
        IEnumerable<Square> FindThreats(IBoardState board, int x, int y);
    }
}