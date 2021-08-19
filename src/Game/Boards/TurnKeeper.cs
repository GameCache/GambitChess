using System;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Boards
{
    internal sealed class TurnKeeper
    {
        private int _current;

        private readonly Side[] _turnOrder;

        internal Side CurrentTurn => _turnOrder[_current];

        internal TurnKeeper(int currentTurnIndex, params Side[] turnOrder)
        {
            if (currentTurnIndex < 0 || currentTurnIndex >= turnOrder.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(currentTurnIndex), currentTurnIndex,
                    $"Must represent position within size of [{string.Join(',', turnOrder)}].");
            }

            _current = currentTurnIndex;
            _turnOrder = turnOrder;
        }

        internal void SetToNextTurn()
        {
            _current = (_current + 1) % _turnOrder.Length;
        }

        internal void SetToPreviousTurn()
        {
            _current = (_current == 0) ? _turnOrder.Length - 1 : _current - 1;
        }
    }
}