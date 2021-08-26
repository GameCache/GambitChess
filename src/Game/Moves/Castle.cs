using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a castling move.</summary>
    internal sealed class Castle : IMove
    {
        /// <summary>King origin.</summary>
        private readonly Square _kingStart;

        /// <summary>King destination.</summary>
        private readonly Square _kingEnd;

        /// <summary>Rook origin.</summary>
        private readonly Square _rookStart;

        /// <summary>Rook destination.</summary>
        private readonly Square _rookEnd;

        /// <inheritdoc/>
        public bool IsCapture { get; } = false;

        /// <summary>Initializes a new instance of the <see cref="Castle"/> class.</summary>
        /// <param name="kingStart">King origin.</param>
        /// <param name="kingEnd">King destination.</param>
        /// <param name="rookStart">Rook origin.</param>
        /// <param name="rookEnd">Rook destination.</param>
        public Castle(Square kingStart, Square kingEnd, Square rookStart, Square rookEnd)
        {
            _kingStart = kingStart;
            _kingEnd = kingEnd;
            _rookStart = rookStart;
            _rookEnd = rookEnd;
        }

        /// <inheritdoc/>
        public void Make()
        {
            IPiece? kingTemp = _kingStart.Content;
            IPiece? rookTemp = _rookStart.Content;

            _kingStart.Content = null;
            _rookStart.Content = null;

            _kingEnd.Content = kingTemp;
            _rookEnd.Content = rookTemp;
        }

        /// <inheritdoc/>
        public void Undo()
        {
            IPiece? kingTemp = _kingEnd.Content;
            IPiece? rookTemp = _rookEnd.Content;

            _kingEnd.Content = null;
            _rookEnd.Content = null;

            _kingStart.Content = kingTemp;
            _rookStart.Content = rookTemp;
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            yield return _kingStart;
            yield return _kingEnd;
            yield return _rookStart;
            yield return _rookEnd;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _kingStart.ToString() + '-' + _kingEnd.ToString();
        }
    }
}