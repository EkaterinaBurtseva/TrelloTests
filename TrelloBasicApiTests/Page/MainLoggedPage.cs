using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloBasicApiTests.Properties;

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

        [FindsBy(How = How.CssSelector, Using = "input[data-test-id='create-board-title-input']")]
        private IWebElement NewDashboardTitleForTile;

        [FindsBy(How = How.CssSelector, Using = "button[data-test-id='create-board-submit-button']")]
        private IWebElement CreateDashboardButton;

        [FindsBy(How = How.CssSelector, Using = "div.board-tile-details-name")]
        private List<IWebElement> BoardList;

        [FindsBy(How = How.CssSelector, Using = "div[data-desktop-id='header'] a[href='/']")]
        private IWebElement TrelloLogoHome;

        public bool IsMainLoggedPageOpened()
        {
            return HomeContainerLoggedUser.Displayed;
        }

        public MainLoggedPage ClickAddNewDashboardTile()
        {
            AddNewDashboardTile.Click();
            return this;
        }

        public MainLoggedPage ClickAddNewItemBtnFromHeader()
        {
            AddNewItemFromHeader.Click();
            return this;
        }

        public bool IsAddNewTeamItemDisplayed()
        {
           return AddNewTeamFromHeader.Displayed;
        }

        public MainLoggedPage ClickAddNewTeamOptionFromHeader()
        {
            AddNewTeamFromHeader.Click();
            return this;
        }

        public MainLoggedPage WaitAndFillNewDashboardTitle(String dashboardTitle)
        {
            WaitForElement.FindAndWaitForElement(Browser.Driver, NewDashboardTitleForTile, 5);
            NewDashboardTitleForTile.SendKeys(dashboardTitle);
            return this;

        }

        public MainLoggedPage ClickAddNewDashboardButton()
        {
            CreateDashboardButton.Click();
            return this;
        }

        public MainLoggedPage ClickTrelloLogo()
        {
            TrelloLogoHome.Click();
            return this;
        }

        public List<string> GetAllBoards()
        {
            List<string> boardsName = new List<string>();
            BoardList.ForEach(it => boardsName.Add(it.Text));
            return boardsName;
        }


    }
}
