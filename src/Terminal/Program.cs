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
        public static void Main(string[] args)
        {
            IPlayerBoard game = Variant.Standard.SetupBoard();
            while (true)
            {
                Console.WriteLine(game);
                Console.WriteLine(game.DebugPrint());
                Console.WriteLine(string.Join(',', game.GenerateMoves()));

                string? input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                game.Make(input);
            }
        }
    }
}
