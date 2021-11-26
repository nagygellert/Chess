using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class VoteDTO
    {
        public MoveDTO Move { get; set; }

        public int Round { get; set; }

        public string LobbyName { get; set; }

        public UserDTO User { get; set; }
    }
}
