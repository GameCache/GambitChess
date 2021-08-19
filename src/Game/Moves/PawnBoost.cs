using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    internal sealed class PawnBoost : Move
    {
        public Square Skipped { get; }

        /// <inheritdoc/>
        public PawnBoost(Square start, Square end, Square skipped) : base(start, end)
        {
            Skipped = skipped;
        }
    }
}