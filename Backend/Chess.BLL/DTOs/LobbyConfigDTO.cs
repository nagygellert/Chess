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

        public string Name { get; set; }

        public int Round { get; set; }

        public bool GameStarted { get; set; }

        public bool IsPrivate { get; set; }

        public string Password { get; set; }
    }
}
