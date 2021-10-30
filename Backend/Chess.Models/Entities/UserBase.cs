using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    [Table("UserData")]
    public class UserBase : EntityBase
    {
        public string Username { get; set; }

        public LobbyConfig Lobby { get; set; }

        public Side? Side { get; set; }
    }
}
