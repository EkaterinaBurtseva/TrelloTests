using System;
using HtmlElements;
using HtmlElements.Elements;
using OpenQA.Selenium.Support.UI;
using TrelloBasicApiTests.Helpers;
using TrelloBasicApiTests.Properties;

namespace TrelloBasicApiTests.Page
{
    public abstract class BasePage :HtmlPage, IPage
    {
        private readonly bool waitTillLoaded = Convert.ToBoolean(RunGlobalSettingHelper.UiSettings.GetSection("waitpagesloaded").Value);

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
            WebDriverWait wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(20));
            wait.Until(d => ReadyState == DocumentReadyState.Complete);
        }
    }
}
