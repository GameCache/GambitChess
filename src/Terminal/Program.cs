using System;
using GambitChess.Game;
using GambitChess.Game.Boards;

namespace GambitChess.Terminal
{
    ///
    public static class Program
    {
        internal static bool Exists { get; } = true;

        ///
        public static void Main()
        {
            IPlayerBoard game = Variant.Standard.SetupBoard();
            while (true)
            {
                Console.Clear();
                Console.WriteLine(game);
                Console.WriteLine(game.DebugPrint());
                Console.WriteLine(string.Join(',', game.GenerateMoves()));

                string input = Console.ReadLine() ?? "";
                if (input == "quit")
                {
                    break;
                }

                try
                {
                    _ = game.Make(input);
                }
                catch (InvalidOperationException) { }
            }
        }
    }
}
