using System.Linq;
using Cake.Core;
using Shouldly;
using Xunit;
using NSubstitute;

namespace Cake.Storyteller.Tests
{
    public class StorytellerArgumentBuilderTests
    {
        private readonly ICakeContext _context;
        private readonly StorytellerArgumentBuilder _argBuilder;

        public StorytellerArgumentBuilderTests()
        {
            _context = Substitute.For<ICakeContext>();
            _argBuilder = new StorytellerArgumentBuilder();
        }

        [Fact]
        public void BuildsWithNoCustomArguments()
        {
            var builder = _argBuilder.BuildArguments(_context.Arguments);
            builder.ShouldBeEmpty();
        }

        [Fact]
        public void BuildsWithTwoArgumentsFromCmd()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");
            _context.Arguments.HasArgument("timeout").Returns(true);
            _context.Arguments.GetArgument("timeout").Returns("500");

            var builder = _argBuilder.BuildArguments(_context.Arguments);
            var list = builder.ToList();
            list.First().Render().Trim().ShouldBe("--profile Chrome");
            list.Last().Render().Trim().ShouldBe("--timeout 500");
        }

        [Fact]
        public void BuildsWithStorytellerSettings()
        {
            var builder = _argBuilder.BuildArguments(new StorytellerSettings
            {
                Profile = "Chrome",
                Timeout = 700
            });

            var list = builder.ToList();
            list.First().Render().Trim().ShouldBe("--profile Chrome");
            list.Last().Render().Trim().ShouldBe("--timeout 700");
        }

        [Fact]
        public void ArugmentListOverridesSettings()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");
            _context.Arguments.HasArgument("timeout").Returns(true);
            _context.Arguments.GetArgument("timeout").Returns("500");

            var builder = _argBuilder.BuildArguments(_context.Arguments, new StorytellerSettings
            {
                Profile = "Phantom",
                Timeout = 300
            });

            var list = builder.ToList();
            list.First().Render().Trim().ShouldBe("--profile Chrome");
            list.Last().Render().Trim().ShouldBe("--timeout 500");
        }

        [Fact]
        public void ReplacesArgumetOnlyFromSettings()
        {
            _context.Arguments.HasArgument("profile").Returns(true);
            _context.Arguments.GetArgument("profile").Returns("Chrome");

            var builder = _argBuilder.BuildArguments(_context.Arguments, new StorytellerSettings
            {
                Profile = "Phantom",
                Timeout = 300
            });

            var list = builder.ToList();
            list.First().Render().Trim().ShouldBe("--profile Chrome");
            list.Last().Render().Trim().ShouldBe("--timeout 300");
        }
    }
}
