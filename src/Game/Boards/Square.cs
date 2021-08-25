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

        /// <summary>Initializes a new instance of the <see cref="Square"/> class.</summary>
        /// <param name="id"></param>
        /// <param name="pawnBoost"></param>
        /// <param name="promotes"></param>
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