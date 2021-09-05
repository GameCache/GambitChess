using System.Collections.Generic;
using System.Linq;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Pawn : Piece
    {
        /// <summary>Which pieces this piece can change to when reaching a promoteable <see cref="Square"/>.</summary>
        private readonly IPiece[] _promotions;

        /// <summary>Direction of the file movement for this piece.</summary>
        private readonly int _changeY;

        /// <inheritdoc cref="Pawn(Side,IEnumerable{IPiece},int)"/>
        internal Pawn(Side side, IEnumerable<IPiece> promotions)
         : this(side, promotions, (side == Side.White) ? -1 : 1) { }

        /// <summary>Initializes a new instance of the <see cref="Pawn"/> class.</summary>
        /// <param name="side">Which side this piece is on.</param>
        /// <param name="promotions">
        ///     Which pieces this piece can change to when reaching a promoteable <see cref="Square"/>.
        /// </param>
        /// <param name="changeY">Direction of the file movement for this piece.</param>
        private Pawn(Side side, IEnumerable<IPiece> promotions, int changeY)
            : base((side == Side.White) ? 'P' : 'p', new Movement[]
        {
            new Movement(0, changeY, false, false, false),
            new Movement(1, changeY, false, true, true),
            new Movement(-1, changeY, false, true, true)
        }, side)
        {
            _promotions = promotions.ToArray();
            _changeY = changeY;
        }

        /// <inheritdoc/>
        public override IEnumerable<IMove> GenerateMoves(IBoardState board, Square container, int x, int y)
        {
            foreach (Square target in FindMoves(false, board, x, y))
            {
                if (target.Promotes)
                {
                    foreach (IPiece promote in _promotions)
                    {
                        yield return new Promote(container, target, promote);
                    }
                }
                else
                {
                    yield return new PawnPush(container, target);
                }
            }

            if (container.PawnBoost && !board.HasChanged(container))
            {
                Square skipped = board.CheckSpace(x, y + _changeY);
                if (skipped.Content == null)
                {
                    Square target = board.CheckSpace(x, y + _changeY * 2);
                    if (target.Exists && target.Content == null)
                    {
                        yield return new PawnBoost(container, target, skipped);
                    }
                }
            }

            Square? potentialTarget = board.GetEnPassantTarget();
            if (potentialTarget != null)
            {
                if (board.CheckSpace(x + 1, y + _changeY) == potentialTarget)
                {
                    yield return new EnPassant(container, potentialTarget, board.CheckSpace(x + 1, y));
                }
                else if (board.CheckSpace(x - 1, y + _changeY) == potentialTarget)
                {
                    yield return new EnPassant(container, potentialTarget, board.CheckSpace(x - 1, y));
                }
            }
        }
    }
}