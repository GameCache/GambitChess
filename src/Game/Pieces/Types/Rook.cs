namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Rook : Piece
    {
        /// <inheritdoc/>
        internal Rook(Side side) : base((side == Side.White) ? 'R' : 'r', new Movement[]
        {
            new Movement(-1, 0, true, true, false),
            new Movement(1, 0, true, true, false),
            new Movement(0, -1, true, true, false),
            new Movement(0, 1, true, true, false)
        }, side)
        { }
    }
}