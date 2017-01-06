using Cake.Core;
using Cake.Core.IO;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Cake.Storyteller.Tests
{
    public class StorytellerRunnerTests
    {
        private readonly ICakeContext _context;
        private readonly StorytellerRunner _runner;

        public StorytellerRunnerTests()
        {
            _context = Substitute.For<ICakeContext>();
            _runner = new StorytellerRunner(_context);
        }

        [Fact]
        public void ThrowsIfStExeIsNotFound()
        {
            Should.Throw<CakeException>(() => _runner.RunCommand("src/test", new StorytellerSettings()));
        }

        [Fact]
        public void ThrowsExceptionWhenTestFails()
        {
            Substitute.For<IProcess>().GetExitCode().Returns(1);
            Should.Throw<StorytellerException>(() => _runner.RunCommand("src/test", new StorytellerSettings
            {
                ToolPath = "./tools/Storyteller/tools/ST.exe"
            }));
        }
    }
}