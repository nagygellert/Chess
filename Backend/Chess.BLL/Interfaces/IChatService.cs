using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessageDTO>> GetAsync();

        Task<ChatMessageDTO> GetAsync(string id);

        Task<ChatMessageDTO> InsertAsync(string text);

        Task RemoveAsync(string id);
    }
}
