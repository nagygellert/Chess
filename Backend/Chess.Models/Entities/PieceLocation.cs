using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class PieceLocation : TableSpace
    {
        public Lobby Lobby { get; set; }

        public ChessPieceType Type { get; set; }

        public Side Color { get; set; }
    }
}
