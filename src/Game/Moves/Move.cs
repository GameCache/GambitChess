using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a standard chess move on a board.</summary>
    internal class Move : IMove
    {
        /// <summary>Piece origin.</summary>
        private readonly Square _start;

        /// <summary>Target destination.</summary>
        private readonly Square _end;

        /// <summary>Piece originally at the destination.</summary>
        private readonly IPiece? _capture;

        /// <inheritdoc/>
        public bool IsCapture => _capture != null;

        /// <summary>Initializes a new instance of the <see cref="Move"/> class.</summary>
        /// <param name="start">Piece origin.</param>
        /// <param name="end">Target destination.</param>
        public Move(Square start, Square end)
        {
            _start = start;
            _end = end;
            _capture = _end.Content;
        }

        /// <inheritdoc/>
        public void Make()
        {
            _end.Content = _start.Content;
            _start.Content = null;
        }

        /// <inheritdoc/>
        public void Undo()
        {
            _start.Content = _end.Content;
            _end.Content = _capture;
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            yield return _start;
            yield return _end;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _start.ToString() + (_capture == null ? '-' : 'x') + _end.ToString();
        }
    }
}