using System;
using NLog;
using RestSharp;
using TrelloAssignment.API.Base;
using TrelloAssignment.API.Models;
using TrelloAssignment.Helpers;

namespace TrelloAssignment.API.Services
{

    public class BoardService : BaseObject
    {
        private new static readonly RestClient RestClient = new RestClient(RunGlobalSettingHelper.RunEnvironment.GetSection("homepageUrl").Value);
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public BoardService() : base(RestClient, Logger)
        {
            Logger.Info("Board service started");
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
