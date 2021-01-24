using System;
using RestSharp;
using TrelloBasicApiTests.BaseObjects;
using TrelloBasicApiTests.Helpers;
using TrelloBasicApiTests.Models;

namespace TrelloBasicApiTests.Services
{
    public class BoardServices : BaseObject
    {
        private new static readonly RestClient RestClient = new RestClient(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);

        public BoardServices() : base(RestClient)
        {
        }

        public IRestResponse CreateBoard(string boardName)
        {
            RestRequest request = new RestRequest("/1/boards/", Method.POST);
            request.AddJsonBody(new Board() { Key = KeyAccess, Token = TokenAccess, Name = boardName });
            return Execute(request);
        }

        public IRestResponse UpdateBoard(string boardNameNew, string boardId)
        {
            RestRequest request = new RestRequest($"/1/boards/{boardId}", Method.PUT);
            request.AddJsonBody(new Board() { Key = KeyAccess, Token = TokenAccess, Id = boardId, Name = boardNameNew });
            return Execute(request);
        }

        public IRestResponse DeleteBoard(string boardId)
        {
            RestRequest request = new RestRequest($"/1/boards/{boardId}", Method.DELETE);
            request.AddJsonBody(new Board() { Key = KeyAccess, Token = TokenAccess, Id = boardId });
            return Execute(request);
        }

        public IRestResponse<Board> GetBoardById(string boardId)
        {
            RestRequest request = new RestRequest($"/1/boards/{boardId}", Method.GET);
            request.AddJsonBody(new Board() { Key = KeyAccess, Token = TokenAccess, Id = boardId });
            return Execute<Board>(request);
        }
    }
}
