using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TrelloBasicApiTests.Page
{
    public class TeamInfoPage : BasePage
    {
        public TeamInfoPage() : base()
        {
            LogName = "Team info page";
        }

        [FindsBy(How = How.CssSelector, Using = "div.tabbed-pane-header-details h1")]
        private IWebElement TeamNameInfo;

        [FindsBy(How = How.CssSelector, Using = "a[data-tab='members']")]
        private IWebElement MembersTab;

        [FindsBy(How = How.CssSelector, Using = "p.name-line span")]
        private List<IWebElement> MembersName;

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
