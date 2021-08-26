using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a piece promotion move.</summary>
    internal sealed class Promote : IMove
    {
        /// <summary>Piece origin.</summary>
        private readonly Square _start;

        /// <summary>Target destination.</summary>
        private readonly Square _end;

        /// <summary>Original piece to promote from.</summary>
        private readonly IPiece? _original;

        /// <summary>Piece originally at the destination.</summary>
        private readonly IPiece? _capture;

        /// <summary>New piece to promote to.</summary>
        private readonly IPiece _promotion;

        /// <inheritdoc/>
        public bool IsCapture => _capture != null;

        /// <summary>Initializes a new instance of the <see cref="Promote"/> class.</summary>
        /// <param name="start">Piece origin.</param>
        /// <param name="end">Target destination.</param>
        /// <param name="promotion">New piece to promote to.</param>
        public Promote(Square start, Square end, IPiece promotion)
        {
            _start = start;
            _end = end;
            _promotion = promotion;

            _original = _start.Content;
            _capture = _end.Content;
        }

        /// <inheritdoc/>
        public void Make()
        {
            _end.Content = _promotion;
            _start.Content = null;
        }

        /// <inheritdoc/>
        public void Undo()
        {
            _start.Content = _original;
            _end.Content = _capture;
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            yield return _start;
            yield return _end;
        }
    }
}