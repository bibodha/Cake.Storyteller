using Cake.Core;
using Cake.Core.IO;
using NSubstitute;
using Shouldly;
using Xunit;

namespace Cake.Storyteller.Tests
{
    public class StorytellerRunnerTests
    {
        [Fact]
        public void ThrowsIfStExeIsNotFound()
        {
            var fixture = new StorytellerFixture();
            fixture.GivenDefaultToolDoNotExist();
            Should.Throw<CakeException>(() => fixture.Run());
        }

        [Fact]
        public void ThrowsExceptionWhenTestFails()
        {
            var fixture = new StorytellerFixture();
            fixture.GivenProcessExitsWithCode(1);
            Should.Throw<StorytellerException>(() => fixture.Run());
        }

        [Fact]
        public void FindsStRunner()
        {
            var fixture = new StorytellerFixture();
            fixture.Run();
            fixture.ProcessRunner.Received(1).Start(Arg.Is<FilePath>(
                    fp => fp.FullPath == "/Working/tools/ST.exe"),
                    Arg.Any<ProcessSettings>());
        }
    }
}