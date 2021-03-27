using CreateAndFake;
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

        [Theory, RandomData]
        internal static void Main_Runs(string[] args)
        {
            Program.Main(args);
        }
    }
}
