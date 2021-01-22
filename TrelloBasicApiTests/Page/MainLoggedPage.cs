using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TrelloBasicApiTests.Page
{
    public class MainLoggedPage: BasePage
    {
        public MainLoggedPage() :base()
        {
            LogName = "Main(logged) Page";
        }

        [FindsBy(How = How.CssSelector, Using = "div.home-container")]
        private IWebElement HomeContainerLoggedUser;

        [FindsBy(How = How.CssSelector, Using = "li[data-test-id='create-board-tile'] div")]
        private IWebElement AddNewDashboardTile;

        [FindsBy(How = How.CssSelector, Using = "button[data-test-id='header-create-menu-button']")]
        private IWebElement AddNewItemFromHeader;

        [FindsBy(How = How.CssSelector, Using = "button[data-test-id='header-create-team-button']")]
        private IWebElement AddNewTeamFromHeader;

        public bool IsMainLoggedPageOpened()
        {
            return HomeContainerLoggedUser.Displayed;
        }

        public void ClickAddNewDashboardTile()
        {
            AddNewDashboardTile.Click();
        }

        public void ClickAddNewItemBtnFromHeader()
        {
            AddNewItemFromHeader.Click();
        }

        public bool IsAddNewTeamItemDisplayed()
        {
           return AddNewTeamFromHeader.Displayed;
        }

        public void ClickAddNewTeamOptionFromHeader()
        {
            AddNewTeamFromHeader.Click();
        }


    }
}
