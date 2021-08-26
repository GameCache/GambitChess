using System;
using GambitChess.Game.Pieces;

namespace GambitChess.Game.Boards
{
    /// <summary>Controls turn order.</summary>
    internal sealed class TurnKeeper
    {
        /// <summary>Index identifying the current turn.</summary>
        private int _current;

        /// <summary>Order in which pieces move.</summary>
        private readonly Side[] _turnOrder;

        /// <summary>Which <see cref="Side"/> can make a move.</summary>
        internal Side CurrentTurn => _turnOrder[_current];

        /// <summary>Initializes a new instance of the <see cref="TurnKeeper"/> class.</summary>
        /// <param name="currentTurnIndex">Index identifying the current turn.</param>
        /// <param name="turnOrder">Order in which pieces move.</param>
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

        /// <summary>Changes turn forward.</summary>
        internal void SetToNextTurn()
        {
            _current = (_current + 1) % _turnOrder.Length;
        }

        /// <summary>Changes turn backward.</summary>
        internal void SetToPreviousTurn()
        {
            _current = (_current == 0) ? _turnOrder.Length - 1 : _current - 1;
        }
    }
}