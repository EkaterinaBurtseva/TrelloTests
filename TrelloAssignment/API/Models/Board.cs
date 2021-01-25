using System;
namespace TrelloAssignment.API.Models
{
    public class Board
    {
        public string Key { get; set; }

        public string Id { get; set; }

        public string Token { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public bool Closed { get; set; }

        public bool Subscribed { get; set; }

        public bool IdOrganization { get; set; }

        public string PermissionLevel { get; set; }

        public string SelfJoin { get; set; }

        public string CardCovers { get; set; }

        public string HideVotes { get; set; }

    }
}

