using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TechTalk.SpecFlow;
using TrelloAssignment.API.Models;
using TrelloAssignment.API.Services;
using TrelloAssignment.Assert;

namespace TrelloAssignment.StepBinding
{
    [Binding]
    public class ApiSteps
    {

        private CardService CardService;
        private BoardService BoardService;
        string createdCardId;
        IRestResponse boardInvalidIdResponseUpdate;
        IRestResponse boardInvalidIdResponseDelete;

        public ApiSteps(CardService cardService, BoardService boardService)
        {
            CardService = cardService;
            BoardService = boardService;

        }

        [StepDefinition(@"I add new card to the existing board with name (.*)")]
        public void IAddNewCardToTheExistingBoard(string name)
        {
            IRestResponse cardResponse = CardService.CreateCard(name);

            createdCardId = JObject.Parse(cardResponse.Content.ToString()).GetValue("id").ToString();
       
            Check.EqualBoolean(true, cardResponse.Content.Contains("OK"), "Card is successfully created", "Card isn't created");

        }

        [StepDefinition(@"I update existing card name to (.*)")]
        public void AddAttachmentTheCard(string cardName)
        {
            Check.EqualBoolean(true, CardService.UpdateCardName(createdCardId, cardName).Content.Contains("OK"));
        }

        [StepDefinition(@"I delete current card from the board")]
        public void DeleteCurrentCard()
        {
            Check.EqualBoolean(true, CardService.DeleteCard(createdCardId).IsSuccessful, "Card successfully removed",
                $"Card with id {createdCardId} wasn't removed");
        }


        [StepDefinition(@"I update board with id (.*) to name (.*)")]
        public void UpdateBoardWithId(string boardId, string boardNameNew)
        {
            Check.EqualBoolean(false, BoardService.GetBoardById(boardId).IsSuccessful, "Board can not be found",
                $"Board with id {boardId} is existed");
            boardInvalidIdResponseUpdate = BoardService.UpdateBoard(boardId, boardNameNew);
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
            boardInvalidIdResponseDelete = BoardService.DeleteBoard(boardId);
            Check.EqualBoolean(false, boardInvalidIdResponseDelete.IsSuccessful, "Board can not be deleted",
                "Board is deleted");
        }
    }
}
