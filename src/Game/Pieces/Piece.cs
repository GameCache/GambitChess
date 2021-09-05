using System;
using System.Collections.Generic;
using System.Linq;
using GambitChess.Game.Boards;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Pieces
{
    /// <inheritdoc cref="IPiece"/>
    internal abstract class Piece : IPiece
    {
        /// <inheritdoc/>
        public char Id { get; }

        /// <inheritdoc/>
        public int MaxStepX { get; }

        /// <inheritdoc/>
        public int MaxStepY { get; }

        /// <inheritdoc/>
        public Side Side { get; }

        /// <summary>Movement patterns for the piece.</summary>
        private readonly Movement[] _moves;

        /// <summary>Initializes a new instance of the <see cref="Piece"/> class.</summary>
        /// <param name="id">Identifier to use.</param>
        /// <param name="moves">Movement patterns for the piece.</param>
        /// <param name="side">Owner of the piece.</param>
        protected Piece(char id, IEnumerable<Movement> moves, Side side)
        {
            Id = id;

            _moves = moves.ToArray();
            Side = side;

            MaxStepX = _moves.Max(m => Math.Abs(m.ChangeX));
            MaxStepY = _moves.Max(m => Math.Abs(m.ChangeY));
        }

        /// <inheritdoc/>
        public virtual IEnumerable<IMove> GenerateMoves(IBoardState board, Square container, int x, int y)
        {
            return FindMoves(false, board, x, y).Select(target => new Move(container, target));
        }

        /// <inheritdoc/>
        public IEnumerable<Square> FindThreats(IBoardState board, int x, int y)
        {
            return FindMoves(true, board, x, y);
        }

        /// <summary>Generates all possible moves or captures for this piece on the board.</summary>
        /// <param name="onlyThreats">If only potential captures are returned.</param>
        /// <param name="board">Current board state.</param>
        /// <param name="x">This piece's current rank position.</param>
        /// <param name="y">This piece's current file position.</param>
        /// <returns>All generated moves or captures.</returns>
        protected IEnumerable<Square> FindMoves(bool onlyThreats, IBoardState board, int x, int y)
        {
            foreach (Movement next in _moves)
            {
                int currentX = x;
                int currentY = y;
                IPiece? content;
                do
                {
                    currentX += next.ChangeX;
                    currentY += next.ChangeY;

                    Square target = board.CheckSpace(currentX, currentY);
                    if (!target.Exists)
                    {
                        break;
                    }
                    content = target.Content;

                    if (content == null)
                    {
                        if (!next.MustCapture || (next.CanCapture && onlyThreats))
                        {
                            yield return target;
                        }
                    }
                    else
                    {
                        if (content.Side != Side && next.CanCapture)
                        {
                            yield return target;
                        }
                    }
                } while (next.RepeatWhileEmpty && content == null);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Id}";
        }
    }
}