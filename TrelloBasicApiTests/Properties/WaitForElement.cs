using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TrelloBasicApiTests.Properties
{
    public static class WaitForElement
    {
        public static void FindAndWaitForElement(this IWebDriver driver, IWebElement element, int timeoutInSeconds)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(ElementIsDisplayed(element));
        }

        private static Func<IWebDriver, bool> ElementIsDisplayed(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                
                    return false;
                }
            };
        }
    }
}

