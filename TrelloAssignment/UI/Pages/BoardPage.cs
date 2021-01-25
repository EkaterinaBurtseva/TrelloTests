using System;
using System.Collections.Generic;
using HtmlElements.Elements;
using HtmlElements.Extensions;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloAssignment.Helpers;
using TrelloAssignment.UI.Base;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Pages
{
    public class BoardPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public BoardPage() : base()
        {
            Logger.Info("Board Page");
        }

        public HtmlElement Board => new HtmlElement(FindElement(By.Id("board")));
        public HtmlElement TitleForToDoItem => new HtmlElement(FindElement(By.CssSelector("div.card-composer textarea")));
        public List<HtmlElement> AllAddedCards => new List<HtmlElement>(FindElements<HtmlElement>(By.CssSelector("span.list-card-title")));
        public HtmlElement AddCardButton => new HtmlElement(FindElement(By.CssSelector("div.cc-controls-section input")));
        public HtmlElement BoardTitle => new HtmlElement(FindElement(By.CssSelector("div[href='#'] h1")));
        public HtmlElement MenuButton => new HtmlElement(FindElement(By.XPath("//a[contains(@class,'mod-show-menu')]")));
        public HtmlElement BoardMenuFrame => new HtmlElement(FindElement(By.CssSelector("div.board-menu-content-frame")));
        public HtmlElement BoardMenuMoreOption => new HtmlElement(FindElement(By.XPath("//a[contains(@class,'js-open-more')]")));
        public HtmlElement CloseBoardOption => new HtmlElement(FindElement(By.XPath("//a[contains(@class,'js-close-board')]")));
        public HtmlElement CloseBoardConfirmButton => new HtmlElement(FindElement(By.XPath("//input[contains(@class,'js-confirm')]")));
        public HtmlElement DeleteBoardLink => new HtmlElement(FindElement(By.CssSelector("p.delete-container a")));
        public HtmlElement DeleteConfiramtionMessage => new HtmlElement(FindElement(By.CssSelector("div.js-react-root h1")));
        public HtmlElement TitleOfTheList => new HtmlElement(FindElement(By.ClassName("list-name-input")));
        public HtmlElement AddTitleOfTheList => new HtmlElement(FindElement(By.CssSelector("input[type='submit']")));
        public HtmlElement AddCardButtonToList => new HtmlElement(FindElement(By.XPath("//a[contains(@class, 'open-card-composer')]")));


        public bool IsBoardDisplayed()
        {
            return Board.WaitForVisible().IsPresent();
        }

        public BoardPage EnterTitleForToDoItem(string text)
        {
            TitleForToDoItem.SendKeys(text);
            return this;

        }

        public BoardPage EnterTitleForList(string text)
        {
            TitleOfTheList.SendKeys(text);
            return this;

        }

        public BoardPage ClickAddTitleToTheList()
        {
            AddTitleOfTheList.Click();
            return this;
        }

        public BoardPage ClickAddCardTheListButton()
        {
            AddCardButtonToList.Click();
            return this;
        }


        public List<string> GetAllCardsName()
        {
            List<string> allCardsTitles = new List<string>();
            AllAddedCards.ForEach(x => allCardsTitles.Add(x.Text));
            return allCardsTitles;

        }

        public BoardPage ClickAddCardButton()
        {
            AddCardButton.Click();
            return this;

        }

        public string GetBoardTitle()
        {
            return BoardTitle.Text;
        }

        public BoardPage ClickMenuButton()
        {
            MenuButton.Click();
            return this;

        }

        public bool IsBoardMenuFrameDisplayed()
        {
            return BoardMenuFrame.Displayed;
        }

        public BoardPage ClickMoreOptionFrmMenuFrame()
        {
            BoardMenuMoreOption.Click();
            return this;

        }

        public BoardPage ClickCloseBoardOption()
        {
            CloseBoardOption.Click();
            return this;

        }

        public BoardPage ClickCloseConfirmButton()
        {
            CloseBoardConfirmButton.Click();
            return this;

        }

        public BoardPage ClickDeleteLink()
        {
            WaitForElement.FindAndWaitForElement(Browser.Driver, DeleteBoardLink, 5);
            DeleteBoardLink.Click();
            return this;

        }

        public bool IsDeletionConfirmationMessageDisplayed()
        {
            return DeleteConfiramtionMessage.Displayed;

        }
    }
}
