using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class TileDTO
    {
        public int Row { get; set; }

        public TableColumn Column { get; set; }

        public ChessPieceDTO ChessPiece { get; set; }
    }
}
