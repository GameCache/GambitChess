namespace GambitChess.Game.Pieces.Types
{
    /// <inheritdoc/>
    internal sealed class Queen : Piece
    {
        /// <summary>Initializes a new instance of the <see cref="Queen"/> class.</summary>
        /// <param name="side">Which side this piece is on.</param>
        internal Queen(Side side) : base((side == Side.White) ? 'Q' : 'q', new Movement[]
        {
            new Movement(-1, 0, true, true, false),
            new Movement(1, 0, true, true, false),
            new Movement(0, -1, true, true, false),
            new Movement(0, 1, true, true, false),
            new Movement(-1, -1, true, true, false),
            new Movement(-1, 1, true, true, false),
            new Movement(1, 1, true, true, false),
            new Movement(1, -1, true, true, false)
        }, side)
        { }
    }
}