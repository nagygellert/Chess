using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Chess.Models.Entities
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
