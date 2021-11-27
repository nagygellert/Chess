using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class Lobby : EntityBase
    {
        public LobbyConfig LobbyConfig { get; set; }

        public IEnumerable<Move> Moves { get; set; }

        public IEnumerable<ChatMessage> Messages { get; set; }

        public IEnumerable<Vote> Votes { get; set; }
    }
}
