using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class King : Piece
    {
        /// <summary>Initializes a new instance of the <see cref="King"/> class.</summary>
        /// <param name="side">Which side this piece is on.</param>
        internal King(Side side) : base((side == Side.White) ? 'K' : 'k', new Movement[]
        {
            new Movement(-1, -1, false, true, false),
            new Movement(-1, 0, false, true, false),
            new Movement(-1, 1, false, true, false),
            new Movement(0, -1, false, true, false),
            new Movement(0, 1, false, true, false),
            new Movement(1, -1, false, true, false),
            new Movement(1, 0, false, true, false),
            new Movement(1, 1, false, true, false)
        }, side)
        { }

        /// <inheritdoc/>
        public override IEnumerable<IMove> GenerateMoves(IBoardState board, Square container, int x, int y)
        {
            if (!board.HasChanged(container))
            {
                ISet<Square> threats = board.FindThreatenedSquares();

                Square? kingsideCastle = FindCastlingTarget(threats, board, x, y, 1);
                if (kingsideCastle != null)
                {
                    yield return new Castle(
                        container, board.CheckSpace(x + 2, y),
                        kingsideCastle, board.CheckSpace(x + 1, y));
                }

                Square? queensideCastle = FindCastlingTarget(threats, board, x, y, -1);
                if (queensideCastle != null)
                {
                    yield return new Castle(
                        container, board.CheckSpace(x - 2, y),
                        queensideCastle, board.CheckSpace(x - 1, y));
                }
            }

            foreach (IMove move in base.GenerateMoves(board, container, x, y))
            {
                yield return move;
            }
        }

        /// <summary>Finds the possible <see cref="Square"/> of the <see cref="Rook"/> to castle with.</summary>
        /// <param name="threats">All <see cref="Square"/>s under threat by opposing pieces.</param>
        /// <param name="board">Current board state.</param>
        /// <param name="x">This piece's current rank position.</param>
        /// <param name="y">This piece's current file position.</param>
        /// <param name="xLook">Rank direction to search for the <see cref="Rook"/>.</param>
        /// <returns>Found <see cref="Square"/> if castling possible; null otherwise.</returns>
        private Square? FindCastlingTarget(ISet<Square> threats, IBoardState board, int x, int y, int xLook)
        {
            int xTarget = x;
            for (int i = 0; true; i++)
            {
                xTarget += xLook;
                Square target = board.CheckSpace(xTarget, y);

                if (i < 2 && threats.Contains(target))
                {
                    return null;
                }
                else if (!target.Exists)
                {
                    return null;
                }
                else if (target.Content == null)
                {
                    continue;
                }
                else if (target.Content is Rook && target.Content.Side == Side)
                {
                    if (i == 0)
                    {
                        Square destination = board.CheckSpace(xTarget + xLook, y);
                        if (destination.Content != null || threats.Contains(destination))
                        {
                            return null;
                        }
                    }
                    return target;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}