using System;
using NLog;
using RestSharp;
using TrelloAssignment.API.Base;
using TrelloAssignment.API.Models;
using TrelloAssignment.Helpers;

namespace TrelloAssignment.API.Services
{
    public class CardService : BaseObject
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private new static readonly RestClient RestClient = new RestClient(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);


        public CardService() : base(RestClient, Logger)
        {
            Logger.Info("Card services started");
        }

        public IRestResponse CreateCard(string cardName)
        {
            RestRequest request = new RestRequest("/1/cards", Method.POST);
            request.AddQueryParameter("key", KeyAccess)
                .AddQueryParameter("token", TokenAccess)
                .AddQueryParameter("idList", ListForCard);
            request.AddJsonBody(new Card() { Name = cardName });
            return Execute(request);
        }

        public IRestResponse<Card> GetCard(string cardId)
        {
            RestRequest request = new RestRequest($"/1/cards/{cardId}", Method.GET);
            request.AddParameter("key", KeyAccess)
                .AddParameter("token", TokenAccess)
                .AddHeader("Accept", "application/json");
            return Execute<Card>(request);
        }

        public IRestResponse<Card> UpdateCardName(string cardId, string newCardName)
        {
            RestRequest request = new RestRequest($"/1/cards/{cardId}", Method.PUT);
            request.AddJsonBody(new Card()
            {
                Key = KeyAccess,
                Token = TokenAccess,
                Id = cardId,
                Name = newCardName
            });

            return Execute<Card>(request);
        }

        public IRestResponse DeleteCard(string cardId)
        {
            RestRequest request = new RestRequest($"/1/cards/{cardId}", Method.DELETE);
            request.AddJsonBody(new Card()
            {
                Key = KeyAccess,
                Token = TokenAccess,
                Id = cardId
            });

            return Execute(request);
        }
    }
}
