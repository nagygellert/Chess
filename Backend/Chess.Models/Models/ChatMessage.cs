using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Chess.DAL.Models
{
    public class ChatMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime TimeStamp { get; set; }
    }
}
