using System;
using HtmlElements.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloAssignment.Helpers;
using TrelloAssignment.UI.Base;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Pages
{
    public class HomePage : BasePage
    {
        public HomePage() : base()
        {
            Browser.GoTo(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);
            Browser.TakeScreenshot();
        }

        public HtmlElement HomeLogo => new HtmlElement(FindElement(By.CssSelector("a[href='/home']")));
        public HtmlElement LoginLink => new HtmlElement(FindElement(By.CssSelector("a[href='/login']")));

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
