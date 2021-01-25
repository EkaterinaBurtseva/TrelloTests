using System;
using Allure.Commons;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NLog;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.Assert
{
    public class Check
    {
        private static readonly AllureLifecycle allure = AllureLifecycle.Instance;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Equal(string expected, string actual, string passedMessage = "Assert passed", string failedMessage = "Assert failed")
        {
            if (!expected.Equals(actual))
            {
                string screenshotName = BrowserContext.Instance.Browser.TakeScreenshot();
                Logger.Error($"{failedMessage}. Actual '{actual}' is different from expected '{expected}'.");
                Logger.Info($"Screenshot saved to {screenshotName.Replace(@"\\", @"\")}");
                allure.AddAttachment(screenshotName);
            }
            else
            {
                Logger.Info($"{passedMessage}. Actual equals to expected '{expected}'.");
            }
        }

        public static void EqualBoolean(bool expected, bool actual, string passedMessage = "Assert passed", string failedMessage = "Assert failed")
        {
            if (expected != actual)
            {
                string screenshotName = BrowserContext.Instance.Browser.TakeScreenshot();
                Logger.Error($"{failedMessage}. Actual '{actual}' is different from expected '{expected}'.");
                Logger.Info($"Screenshot saved to {screenshotName.Replace(@"\\", @"\")}");
                allure.AddAttachment(screenshotName);
            }
            else
            {
                Logger.Info($"{passedMessage}. Actual equals to expected '{expected}'.");
            }
        }
    }
}
