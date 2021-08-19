namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Bishop : Piece
    {
        /// <inheritdoc/>
        internal Bishop(Side side) : base((side == Side.White) ? 'B' : 'b', new Movement[]
        {
            new Movement(-1, -1, true, true, false),
            new Movement(-1, 1, true, true, false),
            new Movement(1, 1, true, true, false),
            new Movement(1, -1, true, true, false)
        }, side)
        { }
    }
}