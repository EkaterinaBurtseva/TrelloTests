using System;
using TrelloBasicApiTests.Logger;
using TrelloBasicApiTests.Properties;

namespace TrelloBasicApiTests.Assert
{
    public static class Check
    {
        private static ILogger Logger => TestContext.Instance.Logger;

        public static void Equal(string expected, string actual, string passedMessage = "Assert passed", string failedMessage = "Assert failed")
        {
            if (!expected.Equals(actual))
            {
                TestContext.Instance.CurrentTestResult = false;
                string screenshotName = BrowserContext.Instance.Browser.TakeScreenshot();
                Logger.WriteLine($"{failedMessage}. Actual '{actual}' is different from expected '{expected}'.");
                Logger.WriteLine($"Screenshot saved to {screenshotName.Replace(@"\\", @"\")}");
            }
            else
            {
                Logger.WriteLine($"{passedMessage}. Actual equals to expected '{expected}'.");
            }
        }

        public static void EqualBoolean(bool expected, bool actual, string passedMessage = "Assert passed", string failedMessage = "Assert failed")
        {
            if (expected!=actual)
            {
                TestContext.Instance.CurrentTestResult = false;
                string screenshotName = BrowserContext.Instance.Browser.TakeScreenshot();
                Logger.WriteLine($"{failedMessage}. Actual '{actual}' is different from expected '{expected}'.");
                Logger.WriteLine($"Screenshot saved to {screenshotName.Replace(@"\\", @"\")}");
            }
            else
            {
                Logger.WriteLine($"{passedMessage}. Actual equals to expected '{expected}'.");
            }
        }



    }
}
