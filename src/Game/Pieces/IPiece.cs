using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Pieces
{
    /// <summary>Represents a chess piece.</summary>
    internal interface IPiece
    {
        int MaxStepX { get; }

        int MaxStepY { get; }

        Side Side { get; }

        char Id { get; }

        IEnumerable<IMove> GenerateMoves(IBoardState board, Square container, int x, int y);

        IEnumerable<Square> FindThreats(IBoardState board, int x, int y);
    }
}