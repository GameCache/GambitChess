using System.Collections.Generic;
using System.Linq;

namespace GambitChess.Game.Boards
{
    /// <inheritdoc cref="IPlayerBoard"/>
    internal sealed class PlayerBoard : IPlayerBoard
    {
        /// <summary>Engine running the actual game.</summary>
        internal readonly IBoardEngine _board;

        /// <summary>Initializes a new instance of the <see cref="PlayerBoard"/> class.</summary>
        /// <param name="board">Engine running the actual game.</param>
        internal PlayerBoard(IBoardEngine board)
        {
            _board = board;
        }

        /// <inheritdoc/>
        public IEnumerable<string> GenerateMoves()
        {
            return _board.GenerateMoves().Select(m => $"{m}");
        }

        /// <inheritdoc/>
        public void Make(string move)
        {
            _board.Make(_board.GenerateMoves().First(m => m.ToString() == move));
        }

        /// <inheritdoc/>
        public void Undo(int count = 1)
        {
            _board.Undo(count);
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return _board.ToString();
        }

        /// <inheritdoc/>
        public string DebugPrint()
        {
            return _board.DebugPrint();
        }
    }
}