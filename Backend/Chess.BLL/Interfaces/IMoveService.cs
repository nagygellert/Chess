using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface IMoveService
    {
        Task<MoveDTO> GetMove(string id);

        Task<MoveDTO> InsertMove(MoveDTO move);
    }
}
