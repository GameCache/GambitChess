using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    internal sealed class PawnPush : Move
    {
        /// <summary>Initializes a new instance of the <see cref="PawnPush"/> class.</summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public PawnPush(Square start, Square end) : base(start, end) { }
    }
}