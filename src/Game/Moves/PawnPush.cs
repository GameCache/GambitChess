using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    /// <summary>Represents a Pawn's regular move.</summary>
    internal sealed class PawnPush : Move
    {
        /// <summary>Initializes a new instance of the <see cref="PawnPush"/> class.</summary>
        /// <inheritdoc/>
        public PawnPush(Square start, Square end) : base(start, end) { }
    }
}