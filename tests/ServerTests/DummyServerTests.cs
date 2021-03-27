using CreateAndFake.Fluent;
using GambitChess.Server;
using Xunit;

namespace GambitChess.ServerTests
{
    public static class DummyServerTests
    {
        [Fact]
        internal static void Exists_IsTrue()
        {
            DummyServer.Exists.Assert().Is(true);
        }
    }
}
