using System;
namespace TrelloAssignment.API.Models
{
    public class Card
    {
        public string Key { get; set; }

        public string Id { get; set; }

        public string Token { get; set; }

        public string IdList { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Pos { get; set; }

        public string Due { get; set; }

        public bool DueComplete { get; set; }

        public string IdCardSource { get; set; }

        public string KeepFromSource { get; set; }

        public string Address { get; set; }

        public string LocationName { get; set; }

        public string Coordinates { get; set; }
    }
}
