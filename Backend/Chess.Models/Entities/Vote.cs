using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class Vote : EntityBase 
    {
        public Move Move { get; set; }

        public int Round { get; set; }

        public string LobbyId { get; set; }
    }
}
