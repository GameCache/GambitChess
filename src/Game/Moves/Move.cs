using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    internal class Move : IMove
    {
        public bool IsCapture => Capture != null;

        public Square Start { get; }

        public Square End { get; }

        public IPiece? Capture { get; }

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