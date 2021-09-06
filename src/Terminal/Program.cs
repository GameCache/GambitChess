using System;
using GambitChess.Game;
using GambitChess.Game.Boards;

namespace GambitChess.Terminal
{
    /// <summary>Handles running chess on the console.</summary>
    public static class Program
    {
        /// <summary>Application entry point.</summary>
        public static void Main()
        {
            IPlayerBoard game = Variant.Standard.SetupBoard();
            while (true)
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }
                Console.WriteLine(game);
                Console.WriteLine(game.DebugPrint());
                Console.WriteLine(string.Join(',', game.GenerateMoves()));

                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    default:
                        try
                        {
                            game.Make(input);
                        }
                        catch (InvalidOperationException) { }
                        break;
                    case "undo":
                        game.Undo();
                        break;
                    case "quit":
                        return;
                }
            }
        }
    }
}
