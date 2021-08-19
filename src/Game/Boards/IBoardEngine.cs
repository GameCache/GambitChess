using System.Collections.Generic;
using GambitChess.Game.Moves;

namespace GambitChess.Game.Boards
{
    internal interface IBoardEngine
    {
        IEnumerable<IMove> GenerateMoves();

        void Make(IMove move);

        void Undo(int count = 1);
    }
}