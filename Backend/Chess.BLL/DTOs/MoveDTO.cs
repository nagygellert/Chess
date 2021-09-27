using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class MoveDTO
    {
        public TableSpaceDTO From { get; set; }

        public TableSpaceDTO To { get; set; }

        public int Piece { get; set; }
    }
}
