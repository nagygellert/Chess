using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Chess.Models.Entities
{
    public class ChatMessage : EntityBase
    {
        public string User { get; set; }

        public string Text { get; set; }

        public string LobbyId { get; set; }
    }
}
