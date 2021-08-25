using System.Collections.Generic;
using System.Linq;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Pawn : Piece
    {
        private readonly IPiece[] _promotions;

        private readonly int _changeY;

        /// <summary>Initializes a new instance of the <see cref="Pawn"/> class.</summary>
        /// <param name="side"></param>
        /// <param name="promotions"></param>
        internal Pawn(Side side, IEnumerable<IPiece> promotions)
         : this(side, promotions, (side == Side.White) ? -1 : 1) { }

        /// <summary>Initializes a new instance of the <see cref="Pawn"/> class.</summary>
        /// <param name="side"></param>
        /// <param name="promotions"></param>
        /// <param name="changeY"></param>
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
            if (container.PawnBoost)
            {
                Square skipped = board.CheckSpace(x, y + _changeY);
                if (skipped.Content == null)
                {
                    Square target = board.CheckSpace(x, y + _changeY * 2);
                    if (target.Content == null)
                    {
                        yield return new PawnBoost(container, target, skipped);
                    }
                }
            }
        }
    }
}