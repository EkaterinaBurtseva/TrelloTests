using System;
using Allure.Commons;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using TechTalk.SpecFlow;

namespace TrelloAssignment.Features
{
    [Binding]
    public class AllureHelpers
    {
        private static readonly AllureLifecycle allure = AllureLifecycle.Instance;

        private FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;

        [StepDefinition(@"Step is '(.*)'")]
        public void StepResultIs(TestOutcome outcome)
        {
            switch (outcome)
            {
                case TestOutcome.Passed:
                    break;
                case TestOutcome.Failed:
                    throw new Exception("This test is failed",
                        new InvalidOperationException("Internal message",
                            new ArgumentException("One more message")));
                default:
                    throw new ArgumentException("value is not supported");
            }
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }
    }
}
