using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a special Pawn capture on a board.</summary>
    internal class EnPassant : IMove
    {
        /// <summary>Piece origin.</summary>
        private readonly Square _start;

        /// <summary>Target destination.</summary>
        private readonly Square _end;

        /// <summary>Location for the piece being captured.</summary>
        private readonly Square _captureLocation;

        /// <summary>Piece being captured.</summary>
        private readonly IPiece? _capture;

        /// <inheritdoc/>
        public bool IsCapture { get; } = true;

        /// <summary>Initializes a new instance of the <see cref="Move"/> class.</summary>
        /// <param name="start">Piece origin.</param>
        /// <param name="end">Target destination.</param>
        /// <param name="captureLocation">Location for the piece being captured.</param>
        public EnPassant(Square start, Square end, Square captureLocation)
        {
            _start = start;
            _end = end;
            _captureLocation = captureLocation;
            _capture = _captureLocation.Content;
        }

        /// <inheritdoc/>
        public void Make()
        {
            _end.Content = _start.Content;
            _start.Content = null;
            _captureLocation.Content = null;
        }

        /// <inheritdoc/>
        public void Undo()
        {
            _start.Content = _end.Content;
            _end.Content = null;
            _captureLocation.Content = _capture;
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            yield return _start;
            yield return _end;
            yield return _captureLocation;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _start.ToString() + 'x' + _end.ToString();
        }
    }
}