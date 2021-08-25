using System.Collections.Generic;
using System.Linq;
using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    internal sealed class Castle : IMove
    {
        public bool IsCapture { get; } = false;

        private readonly Move _kingMove;

        private readonly Move _rookMove;

        public Castle(Move kingMove, Move rookMove)
        {
            _kingMove = kingMove;
            _rookMove = rookMove;
        }

        /// <inheritdoc/>
        public void Make()
        {
            _kingMove.Make();
            _rookMove.Make();
        }

        /// <inheritdoc/>
        public void Undo()
        {
            _rookMove.Undo();
            _kingMove.Undo();
        }

        /// <inheritdoc/>
        public IEnumerable<Square> Changes()
        {
            return _kingMove.Changes().Concat(_rookMove.Changes());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _kingMove.ToString();
        }
    }
}