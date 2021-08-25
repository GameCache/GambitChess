using System.Collections.Generic;
using GambitChess.Game.Boards;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Moves
{
    internal sealed class Promote : IMove
    {
        public bool IsCapture => Capture != null;

        public Square Start { get; }

        public Square End { get; }

        public IPiece? Origin { get; }

        public IPiece? Capture { get; }

        public IPiece Promotion { get; }

        /// <summary>Initializes a new instance of the <see cref="Promote"/> class.</summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="promotion"></param>
        public Promote(Square start, Square end, IPiece promotion)
        {
            Start = start;
            End = end;
            Promotion = promotion;

            Origin = Start.Content;
            Capture = End.Content;
        }

        /// <inheritdoc/>
        public void Make()
        {
            End.Content = Promotion;
            Start.Content = null;
        }

        /// <inheritdoc/>
        public void Undo()
        {
            Start.Content = Origin;
            End.Content = Capture;
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            yield return Start;
            yield return End;
        }
    }
}