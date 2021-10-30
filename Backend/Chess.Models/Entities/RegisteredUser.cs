using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Entities
{
    public class RegisteredUser : UserBase
    {
        public string UserProfileId { get; set; }
    }
}
