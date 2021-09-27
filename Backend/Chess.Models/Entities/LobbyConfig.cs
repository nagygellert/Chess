using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class LobbyConfig : EntityBase
    {
        public int Round { get; set; }

        public DateTime RoundStart { get; set; }
    }
}
