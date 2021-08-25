using System.Collections.Generic;
using System.Linq;

namespace GambitChess.Game.Boards
{
    internal sealed class PlayerBoard : IPlayerBoard
    {
        private readonly IBoardEngine _board;

        /// <summary>Initializes a new instance of the <see cref="PlayerBoard"/> class.</summary>
        /// <param name="board"></param>
        internal PlayerBoard(IBoardEngine board)
        {
            _board = board;
        }

        public IEnumerable<string> GenerateMoves()
        {
            return _board.GenerateMoves().Select(m => $"{m}");
        }

        public string Make(string move)
        {
            _board.Make(_board.GenerateMoves().First(m => m.ToString() == move));
            return $"{_board}";
        }

        public string Undo(int count = 1)
        {
            _board.Undo(count);
            return $"{_board}";
        }

        public override string? ToString()
        {
            return _board.ToString();
        }

        public string DebugPrint()
        {
            return ((BoardEngine)_board).DebugPrint();
        }
    }
}