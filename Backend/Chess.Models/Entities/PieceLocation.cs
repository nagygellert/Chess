using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class PieceLocation : EntityBase
    {
        public TableSpace CurrentLocation { get; set; }

        public ChessPiece Piece { get; set; }
    }
}
