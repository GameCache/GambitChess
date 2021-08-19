using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    internal sealed class PawnPush : Move
    {
        /// <inheritdoc/>
        public PawnPush(Square start, Square end) : base(start, end) { }
    }
}