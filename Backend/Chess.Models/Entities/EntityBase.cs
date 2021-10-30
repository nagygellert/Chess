using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Chess.Models.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
