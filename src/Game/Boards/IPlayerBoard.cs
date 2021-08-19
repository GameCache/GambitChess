using System.Collections.Generic;

namespace GambitChess.Game.Boards
{
    public interface IPlayerBoard
    {
        IEnumerable<string> GenerateMoves();

        string Make(string move);

        string Undo(int count = 1);

        string DebugPrint();
    }
}