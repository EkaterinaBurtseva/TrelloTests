using System;
using System.Collections.Generic;
using HtmlElements.Elements;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloAssignment.Helpers;
using TrelloAssignment.UI.Base;

namespace TrelloAssignment.UI.Pages
{
    public class MainLoggedPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public MainLoggedPage()
            {
            Logger.Info("Main logged page is opened");
        }
        public HtmlElement HomeContainerLoggedUser => new HtmlElement(FindElement(By.CssSelector("div.home-container")));
        public HtmlElement AddNewDashboardTile => new HtmlElement(FindElement(By.CssSelector("li[data-test-id='create-board-tile'] div")));
        public HtmlElement AddNewItemFromHeader => new HtmlElement(FindElement(By.CssSelector("button[data-test-id='header-create-menu-button']")));
        public HtmlElement AddNewTeamFromHeader => new HtmlElement(FindElement(By.CssSelector("button[data-test-id='header-create-team-button']")));
        public HtmlElement NewDashboardTitleForTile => new HtmlElement(FindElement(By.CssSelector("input[data-test-id='create-board-title-input']")));
        public HtmlElement CreateDashboardButton => new HtmlElement(FindElement(By.CssSelector("button[data-test-id='create-board-submit-button']")));
        public List<HtmlElement> BoardList => new List<HtmlElement>(FindElements<HtmlElement>(By.CssSelector("div.board-tile-details-name")));
        public HtmlElement TrelloLogoHome => new HtmlElement(FindElement(By.CssSelector("div[data-desktop-id='header'] a[href='/']")));

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
