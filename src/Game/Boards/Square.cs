using GambitChess.Game.Pieces;

namespace GambitChess.Game.Boards
{
    internal sealed class Square
    {
        public static Square Invalid { get; } = new Square();

        public bool Exists { get; }

        public bool Promotes { get; }

        public bool PawnBoost { get; }

        public IPiece? Content { get; set; }

        private readonly string _id;

        private Square()
        {
            _id = "--";
            Exists = false;
            PawnBoost = false;
            Promotes = false;
        }

        public Square(string id, bool pawnBoost, bool promotes)
        {
            _id = id;
            Exists = true;
            PawnBoost = pawnBoost;
            Promotes = promotes;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _id;
        }

        public string DebugPrint()
        {
            return (Content?.ToString() ?? "-") + ToString();
        }
    }
}