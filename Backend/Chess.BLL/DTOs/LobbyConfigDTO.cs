using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class LobbyConfigDTO
    {
        public UserDTO Owner { get; set; }

        public IEnumerable<UserDTO> WhiteTeamPlayers { get; set; }

        public IEnumerable<UserDTO> BlackTeamPlayers { get; set; }

        public int RoomCode { get; set; }
    }
}
