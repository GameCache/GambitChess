using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a standard chess move on a board.</summary>
    internal class Move : IMove
    {
        /// <inheritdoc/>
        public bool IsCapture => Capture != null;

        /// <summary>Piece origin.</summary>
        public Square Start { get; }

        /// <summary>Target destination.</summary>
        public Square End { get; }

        /// <summary>Piece originally at the destination.</summary>
        private IPiece? Capture { get; }

        /// <summary>Initializes a new instance of the <see cref="Move"/> class.</summary>
        /// <param name="start">Piece origin.</param>
        /// <param name="end">Target destination.</param>
        public Move(Square start, Square end)
        {
            Start = start;
            End = end;
            Capture = End.Content;
        }

        /// <inheritdoc/>
        public void Make()
        {
            End.Content = Start.Content;
            Start.Content = null;
        }

        /// <inheritdoc/>
        public void Undo()
        {
            Start.Content = End.Content;
            End.Content = Capture;
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            yield return Start;
            yield return End;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Start.ToString() + (Capture == null ? '-' : 'x') + End.ToString();
        }
    }
}