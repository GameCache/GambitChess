using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a Pawn's initial double move.</summary>
    internal sealed class PawnBoost : Move
    {
        /// <summary>The <see cref="Square"/> that the move skips.</summary>
        public Square Skipped { get; }

        /// <summary>Initializes a new instance of the <see cref="PawnBoost"/> class.</summary>
        /// <param name="start">Piece origin.</param>
        /// <param name="end">Target destination.</param>
        /// <param name="skipped">The <see cref="Square"/> that the move skips.</param>
        public PawnBoost(Square start, Square end, Square skipped) : base(start, end)
        {
            Skipped = skipped;
        }
    }
}