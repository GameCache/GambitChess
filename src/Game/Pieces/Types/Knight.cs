namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Knight : Piece
    {
        /// <inheritdoc/>
        internal Knight(Side side) : base((side == Side.White) ? 'N' : 'n', new Movement[]
        {
            new Movement(-2, -1, false, true, false),
            new Movement(-2, 1, false, true, false),
            new Movement(2, -1, false, true, false),
            new Movement(2, 1, false, true, false),
            new Movement(-1, -2, false, true, false),
            new Movement(1, -2, false, true, false),
            new Movement(-1, 2, false, true, false),
            new Movement(1, 2, false, true, false)
        }, side)
        { }
    }
}