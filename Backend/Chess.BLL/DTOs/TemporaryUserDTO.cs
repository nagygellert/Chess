using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class TemporaryUserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int LobbyCode { get; set; }

        public Side? Side { get; set; }
    }
}
