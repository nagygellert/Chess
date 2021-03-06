using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface IMoveRepository
    {
        Task<Move> GetMove(Guid id);

        Task<Move> InsertMove(Move move);
    }
}
