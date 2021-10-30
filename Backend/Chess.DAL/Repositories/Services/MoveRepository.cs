using Chess.DAL.Contexts;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class MoveRepository : IMoveRepository
    {
        private readonly ChessDbContext _chessDbContext;

        public MoveRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public async Task<Move> GetMove(Guid id)
            => await _chessDbContext.Moves.FindAsync(id);

        public async Task<Move> InsertMove(Move move)
        {
            await _chessDbContext.Moves.AddAsync(move);
            return move;
        }
    }
}
