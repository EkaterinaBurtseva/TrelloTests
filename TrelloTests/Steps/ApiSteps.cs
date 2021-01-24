using System;
using RestSharp;
using TechTalk.SpecFlow;
using TrelloBasicApiTests.Assert;
using TrelloBasicApiTests.Services;

namespace TrelloTests.Steps
{
    [Binding]
    public class ApiSteps
    {

        private CardService cardService = new CardService();
        private BoardServices boardService = new BoardServices();
        string createdCardId;
        IRestResponse boardInvalidIdResponseUpdate;
        IRestResponse boardInvalidIdResponseDelete;

        public ApiSteps()
        {
        }

        [StepDefinition(@"I add new card to the existing board with name (.*)")]
        public void IAddNewCardToTheExistingBoard(string name)
        {
            IRestResponse cardResponse = cardService.CreateCard(name);
            createdCardId = cardResponse.Content;
            Check.Equal("200", cardResponse.StatusCode.ToString(), "Card is successfully created", "Card isn't created");

        }

        [StepDefinition(@"I update existing card name to (.*)")]
        public void AddAttachmentTheCard(string cardName)
        {
            Check.EqualBoolean(true, cardService.UpdateCardName(createdCardId, cardName).IsSuccessful);
        }

        [StepDefinition(@"I delete current card from the board")]
        public void DeleteCurrentCard()
        {
            Check.EqualBoolean(true, cardService.DeleteCard(createdCardId).IsSuccessful, "Card successfully removed",
                $"Card with id {createdCardId} wasn't removed");
        }


        [StepDefinition(@"I update board with id (.*) to name (.*)")]
        public void UpdateBoardWithId(string boardId, string boardNameNew)
        {
            Check.EqualBoolean(false, boardService.GetBoardById(boardId).IsSuccessful, "Board can not be found",
                $"Board with id {boardId} is existed");
            boardInvalidIdResponseUpdate = boardService.UpdateBoard(boardId, boardNameNew);
            Check.EqualBoolean(false, boardInvalidIdResponseUpdate.IsSuccessful, "Board can not be updated",
                $"Board is updated");
        }

        [StepDefinition(@"I receive an error (.*)")]
        public void VerifyErrorForInvalidUpdate(string errorMessage)
        {
            if (errorMessage.Contains("update"))
            {
                Check.Equal(errorMessage, boardInvalidIdResponseUpdate.Content);
            }
            else if (errorMessage.Contains("delete"))
            {
                Check.Equal(errorMessage, boardInvalidIdResponseDelete.Content);
            }
        }


        [StepDefinition(@"I delete board with id (.*)")]
        public void DeleteBoardInvalidId(string boardId)
        {
            boardInvalidIdResponseDelete = boardService.DeleteBoard(boardId);
            Check.EqualBoolean(false, boardInvalidIdResponseDelete.IsSuccessful, "Board can not be deleted",
                "Board is deleted");
        }
    }
}
