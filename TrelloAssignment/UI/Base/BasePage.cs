using System;
using HtmlElements;
using HtmlElements.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TrelloAssignment.Helpers;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Base
{
    public abstract class BasePage: HtmlPage, IPage
    {
        private readonly bool waitTillLoaded = RunGlobalSettingHelper.RunEnvironment.GetSection("waitpagesloaded").Value.As<bool>();

        public Browser Browser;
        public string LogName { get; protected set; }

        public BasePage() : base(BrowserContext.Instance.Browser.Driver)
        {
            Browser = BrowserContext.Instance.Browser;
            if (waitTillLoaded)
            {
                WaitTillLoaded();
            }

        }

        public void WaitTillLoaded()
        {
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => ReadyState == DocumentReadyState.Complete);
        }

     
    }
}
