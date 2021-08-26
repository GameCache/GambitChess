using System.Collections.Generic;
using System.Linq;
using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a castling move.</summary>
    internal sealed class Castle : IMove
    {
        /// <summary>King reposition.</summary>
        private readonly Move _kingMove;

        /// <summary>Rook reposition.</summary>
        private readonly Move _rookMove;

        /// <inheritdoc/>
        public bool IsCapture { get; } = false;

        /// <summary>Initializes a new instance of the <see cref="Castle"/> class.</summary>
        /// <param name="kingMove">King reposition.</param>
        /// <param name="rookMove">Rook reposition.</param>
        public Castle(Move kingMove, Move rookMove)
        {
            _kingMove = kingMove;
            _rookMove = rookMove;
        }

        /// <inheritdoc/>
        public void Make()
        {
            _kingMove.Make();
            _rookMove.Make();
        }

        /// <inheritdoc/>
        public void Undo()
        {
            _rookMove.Undo();
            _kingMove.Undo();
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            return _kingMove.Changes().Concat(_rookMove.Changes());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _kingMove.ToString();
        }
    }
}