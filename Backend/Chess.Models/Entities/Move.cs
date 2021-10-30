using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class Move : PieceLocation
    {
        public TableColumn NewColumn { get; set; }

        public int NewRow { get; set; }

        public UserBase User { get; set; }
    }
}
