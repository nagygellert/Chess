using Chess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Sub { get; set; }

        public AccountType AccountType { get; set; }

        public string LobbyName { get; set; }

        public Side? Side { get; set; }
    }
}
