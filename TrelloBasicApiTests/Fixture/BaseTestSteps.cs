using TrelloBasicApiTests.Properties;
using Xunit;
using TestContext = TrelloBasicApiTests.Properties.TestContext;

namespace TrelloTests.Fixture
{
    public abstract class BaseTestSteps
    {

        public BaseTestSteps()
        {

        }

        public void Dispose()
        {
            CheckTestResult();
            BrowserContext.Instance.Dispose();
            TestContext.Instance.Dispose();
        }

        private void CheckTestResult()
        {
            if (TestContext.Instance.CurrentTestResult)
            {
                TestContext.Instance.Logger.BreakLine().WriteLine("Test Passed.");
            }
            else
            {
                TestContext.Instance.Logger.BreakLine().WriteLine("Test Failed. Check logs for details.");
                Assert.True(false, "Test Failed. Check logs for details.");
            }
        }

    }
}
