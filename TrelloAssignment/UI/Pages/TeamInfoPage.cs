using System;
using System.Collections.Generic;
using HtmlElements.Elements;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloAssignment.UI.Base;

namespace TrelloAssignment.UI.Pages
{
    public class TeamInfoPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TeamInfoPage()
        {
            Logger.Info("Team info page is opened");
        }
        public HtmlElement TeamNameInfo => new HtmlElement(FindElement(By.CssSelector("div.tabbed-pane-header-details h1")));
        public HtmlElement MembersTab => new HtmlElement(FindElement(By.CssSelector("a[data-tab='members']")));
        public List<HtmlElement> MembersName => new List<HtmlElement>(FindElements<HtmlElement>(By.CssSelector("a[data-tab='members']")));

        public bool IsTeamInfoDisplayed()
        {
            return TeamNameInfo.Displayed;
        }

        public String GetTeamNameInfo()
        {
            return TeamNameInfo.Text;
        }

        public TeamInfoPage ClickMembersTab()
        {
            MembersTab.Click();
            return this;
        }

        public List<string> GetAllMembersName()
        {
            List<string> names = new List<string>();
            MembersName.ForEach(x => names.Add(x.Text));
            return names;
        }
    }
}
