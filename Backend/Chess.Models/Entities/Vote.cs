using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class Vote : EntityBase 
    {
        public int Row { get; set; }

        public TableColumn Column { get; set; }

        public int NewRow { get; set; }

        public TableColumn NewColumn { get; set; }

        public int Round { get; set; }

        public Lobby Lobby { get; set; }

        public UserBase User { get; set; }
    }
}
