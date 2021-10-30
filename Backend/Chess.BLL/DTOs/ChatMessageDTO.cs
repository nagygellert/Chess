using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class ChatMessageDTO
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public UserDTO User { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
