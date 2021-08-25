using CreateAndFake.Fluent;
using GambitChess.Terminal;
using Xunit;

namespace GambitChess.TerminalTests
{
    public static class ProgramTests
    {
        [Fact]
        internal static void Exists_IsTrue()
        {
            Program.Exists.Assert().Is(true);
        }

        [Fact]
        internal static void Main_Runs()
        {
            Program.Main();
        }
    }
}
