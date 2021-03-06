using System;

namespace Chess.Models.Entities
{
    public class ChatMessage : EntityBase
    {
        public UserBase User { get; set; }

        public string Text { get; set; }

        public Lobby Lobby { get; set; }
    }
}
