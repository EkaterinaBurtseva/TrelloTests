using System;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Page;
using TrelloTests.Fixture;

namespace TrelloBasicApiTests.PageSteps
{
    public class BoardPageSteps : BaseTestSteps
    {
        private BoardPage boardPage = new BoardPage();


        public void VerifyBoardExistenseAndTitle(String boardTitle)
        {
            Check.EqualBoolean(true, boardPage.IsBoardDisplayed(),"Board page is displayed", "Board page isn't displayed");
            Check.Equals(boardPage.GetBoardTitle(), boardTitle);
          
        }

        public void AddCardToTheToDoList(String cardName)
        {
            boardPage.EnterTitleForToDoItem(cardName)
                .ClickAddCardButton();
        }

        public void VerifyAddedCardDisplayedInTheList(String cardName)
        {
            bool act = boardPage.GetAllCardsName().FindAll(x => x.Contains(cardName)).ToArray().Length > 0;
            Check.EqualBoolean(true, act, $"{cardName} is dispalyed in the given board", $"{cardName} isn't dispalyed in the given board");

        }

        public void DeleteCurrentBoardFromTheSystem()
        {
            boardPage.ClickMenuButton()
                .ClickMoreOptionFrmMenuFrame()
                .ClickCloseBoardOption()
                .ClickCloseConfirmButton()
                .ClickDeleteLink()
                .ClickCloseConfirmButton();

            Check.Equal("Board is deleted", boardPage.DeletionConfirmationMessage());

        }

    }
}
