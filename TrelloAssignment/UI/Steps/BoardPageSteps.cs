using System;
using TrelloAssignment.Assert;
using TrelloAssignment.UI.Pages;
using TrelloAssignment.UI.Properties;

namespace TrelloAssignment.UI.Steps
{
    public class BoardPageSteps
    {
        public static BoardPage OpenBoardPage()
        {
            return Activators.Get<BoardPage>();
        }
        BoardPage boardPage = OpenBoardPage();

        public void VerifyBoardExistenseAndTitle(string boardTitle)
        {

            Check.EqualBoolean(true, boardPage.IsBoardDisplayed(), "Board page is displayed", "Board page isn't displayed");
            Check.EqualBoolean(true, boardPage.GetBoardTitle().Contains(boardTitle));

        }

        public void AddCardToTheToDoList(string list, string cardName)
        {
            boardPage.EnterTitleForList(list)
                .ClickAddTitleToTheList()
                .ClickAddCardTheListButton()
                .EnterTitleForToDoItem(cardName)
                .ClickAddCardButton();
        }

        public void VerifyAddedCardDisplayedInTheList(String cardName)
        {
            bool act = boardPage.GetAllCardsName().FindAll(x => x.Contains(cardName)).ToArray().Length > 0;
            Check.EqualBoolean(true, act, $"{cardName} is dispalyed in the given board", $"{cardName} isn't dispalyed in the given board");

        }

        public void DeleteCurrentBoardFromTheSystem()
        {
            if (!boardPage.IsBoardMenuFrameDisplayed())
            {
                boardPage.ClickMenuButton();
            }
            
            boardPage.ClickMoreOptionFrmMenuFrame()
                .ClickCloseBoardOption()
                .ClickCloseConfirmButton()
                .ClickDeleteLink()
                .ClickCloseConfirmButton();

            Check.EqualBoolean(true, boardPage.IsDeletionConfirmationMessageDisplayed());

        }
    }
}
