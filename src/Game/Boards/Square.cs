using GambitChess.Game.Pieces;
using GambitChess.Game.Pieces.Types;

namespace GambitChess.Game.Boards
{
    /// <summary>Current state of a chess board square.</summary>
    internal sealed class Square
    {
        /// <summary>Square that pieces can't move to.</summary>
        /// <remarks>Performance tweak to allow move generation without bounds checks.</remarks>
        public static Square Invalid { get; } = new Square();

        /// <summary>If pieces can move to this <see cref="Square"/>.</summary>
        public bool Exists { get; }

        /// <summary>If promotable pieces promote when reaching this <see cref="Square"/>.</summary>
        public bool Promotes { get; }

        /// <summary>If <see cref="Pawn"/>s double move when moving from this <see cref="Square"/>.</summary>
        public bool PawnBoost { get; }

        /// <summary>Current piece occupying this <see cref="Square"/>; null if empty.</summary>
        public IPiece? Content { get; set; }

        /// <summary>Identifier for this <see cref="Square"/>.</summary>
        private readonly string _id;

        /// <summary>Initializes a new instance of the <see cref="Square"/> class.</summary>
        private Square()
        {
            _id = "--";
            Exists = false;
            PawnBoost = false;
            Promotes = false;
        }

        /// <summary>Initializes a new instance of the <see cref="Square"/> class.</summary>
        /// <param name="id"><see cref="Square"/> identifier.</param>
        /// <param name="pawnBoost">If <see cref="Pawn"/>s double move when moving from this <see cref="Square"/>.</param>
        /// <param name="promotes">If promotable pieces promote when reaching this <see cref="Square"/>.</param>
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

        /// <summary>Temporary full detailed print of the square.</summary>
        /// <returns>Representation of the square.</returns>
        public string DebugPrint()
        {
            return (Content?.ToString() ?? "-") + ToString();
        }
    }
}