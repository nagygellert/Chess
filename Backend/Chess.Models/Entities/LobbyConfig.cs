using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class LobbyConfig : EntityBase
    {
        [ForeignKey("OwnerId")]
        public RegisteredUser Owner { get; set; }

        public List<UserBase> Players { get; set; }

        public int Round { get; set; } = 1;

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public bool GameStarted { get; set; }

        public string Password { get; set; }
    }
}
