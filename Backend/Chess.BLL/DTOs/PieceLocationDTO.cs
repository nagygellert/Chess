using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class PieceLocationDTO
    {
        public TableSpaceDTO TableSpace { get; set; }

        public int Piece { get; set; }
    }
}
