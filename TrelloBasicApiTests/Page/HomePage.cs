using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloBasicApiTests.Helpers;

namespace TrelloBasicApiTests.Page
{
    public class HomePage : BasePage
    {

        public HomePage() : base()
        {
            LogName = "Home Page";
            Browser.GoTo(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);
            Browser.TakeScreenshot();
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/home']")]
        private IWebElement HomeLogo;

        [FindsBy(How = How.CssSelector, Using = "a[href='/login']")]
        private IWebElement LoginLink;


        public bool IsHomePageOpened()
        {
            return HomeLogo.Displayed;
        }

        public void ClickLoginLink()
        {
            LoginLink.Click();
        }

    }
}

