using System;
using System.IO;
using CreateAndFake.Fluent;
using GambitChess.Terminal;
using Xunit;

namespace GambitChess.TerminalTests
{
    public static class ProgramTests
    {
        [Fact]
        internal static void Main_Runs()
        {
            using StringReader input = new(string.Join(Environment.NewLine,
                "a2-a8",
                null,
                "e2-e4",
                "e7-e5",
                "undo",
                "d7-d5",
                "quit"));
            Console.SetIn(input);

            using StringWriter output = new();
            Console.SetOut(output);
            Program.Main();

            string result = output.ToString();
            result.Assert().Contains("rnbqkbnr/pppp1ppp/8/4p3/4P3/8/PPPP1PPP/RNBQKBNR w KQkq e6 0 2");
            result.Assert().Contains("rnbqkbnr/ppp1pppp/8/3p4/4P3/8/PPPP1PPP/RNBQKBNR w KQkq d6 0 2");
        }
    }
}
