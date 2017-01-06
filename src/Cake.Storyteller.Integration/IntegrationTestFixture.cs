using StoryTeller;

namespace Cake.Storyteller.Integration
{
    public class IntegrationTestFixture : Fixture
    {
        [FormatAs("Add {value1} + {value2} should be {value}")]
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }

    }
}
