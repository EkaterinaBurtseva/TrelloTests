using System;
using System.Collections.Generic;
using RestSharp;
using TrelloBasicApiTests.BaseObjects;
using TrelloBasicApiTests.Helpers;
using TrelloBasicApiTests.Logger;
using TrelloBasicApiTests.Models;

namespace TrelloBasicApiTests.Services
{
    public class CardService : BaseObject
    {
        private new static readonly RestClient RestClient = new RestClient(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);


        public CardService() : base(RestClient)
        {
        }


        public IRestResponse CreateCard(string cardName)
        {
            RestRequest request = new RestRequest("/1/cards", Method.POST);
            request.AddJsonBody(new Card() { Key = KeyAccess, Token = TokenAccess, IdList = "abbe4b7ddc1b351ef961414", Name = cardName });
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
