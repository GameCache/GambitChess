namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Bishop : Piece
    {
        /// <summary>Initializes a new instance of the <see cref="Bishop"/> class.</summary>
        /// <param name="side">Which side this piece is on.</param>
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