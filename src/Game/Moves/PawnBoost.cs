using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    internal sealed class PawnBoost : Move
    {
        public Square Skipped { get; }

        /// <summary>Initializes a new instance of the <see cref="PawnBoost"/> class.</summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="skipped"></param>
        public PawnBoost(Square start, Square end, Square skipped) : base(start, end)
        {
            Skipped = skipped;
        }
    }
}