using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class MoveDTO
    {
        public TileDTO From { get; set; }

        public TileDTO To { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
