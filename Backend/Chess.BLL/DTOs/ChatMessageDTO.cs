using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.DTOs
{
    public class ChatMessageDTO
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
