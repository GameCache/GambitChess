using System.Collections.Generic;
using GambitChess.Game.Boards;

namespace GambitChess.Game.Moves
{
    internal interface IMove
    {
        bool IsCapture { get; }

        void Make();

        void Undo();

        IEnumerable<Square> Changes();
    }
}