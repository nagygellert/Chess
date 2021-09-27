using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class Lobby : EntityBase
    {
        public LobbyConfig Config { get; set; }

        public PieceLocation[] Tiles { get; set; }

        public string[] MoveIds { get; set; }
    }
}
