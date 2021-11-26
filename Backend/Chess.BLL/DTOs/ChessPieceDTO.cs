using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class ChessPieceDTO
    {
        public ChessPieceType Type { get; set; }

        public Side Side { get; set; }

        public string IconUrl { get; set; }
    }
}
