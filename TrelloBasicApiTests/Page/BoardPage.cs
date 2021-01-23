using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TrelloBasicApiTests.Properties;

namespace TrelloBasicApiTests.Page
{
    public class BoardPage : BasePage
    {
        public BoardPage() : base()
        {
            LogName = "Board Page";
        }

        [FindsBy(How = How.Id, Using = "board")]
        private IWebElement Board;

        [FindsBy(How = How.CssSelector, Using = "div.card-composer textarea")]
        private IWebElement TitleForToDoItem;

        [FindsBy(How = How.CssSelector, Using = "span.list-card-title")]
        private List<IWebElement> AllAddedCards;

        [FindsBy(How = How.CssSelector, Using = "div.cc-controls-section input")]
        private IWebElement AddCardButton;

        [FindsBy(How = How.CssSelector, Using = "div[href='#'] h1")]
        private IWebElement BoardTitle;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'board-header-btn mod-show-menu')]")]
        private IWebElement MenuButton;

        [FindsBy(How = How.CssSelector, Using = "div.board-menu-content-frame")]
        private IWebElement BoardMenuFrame;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'js-open-more')]")]
        private IWebElement BoardMenuMoreOption;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'js-close-board')]")]
        private IWebElement CloseBoardOption;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'js-confirm')]")]
        private IWebElement CloseBoardConfirmButton;

        [FindsBy(How = How.CssSelector, Using = "p.delete-container a")]
        private IWebElement DeleteBoardLink;

        [FindsBy(How = How.CssSelector, Using = "div.js-react-root h1")]
        private IWebElement DeleteConfiramtionMessage;


        public bool IsBoardDisplayed()
        {
            return Board.Displayed;
        }

        public BoardPage EnterTitleForToDoItem(String text)
        {
            TitleForToDoItem.SendKeys(text);
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

        public String GetBoardTitle()
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

        public String DeletionConfirmationMessage()
        {
            return DeleteConfiramtionMessage.Text;

        }



    }
}
