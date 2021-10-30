using Chess.DAL.Contexts;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ChessDbContext _chessDbContext;

        public UserRepository(ChessDbContext chessDbContext)
        {
            _chessDbContext = chessDbContext;
        }

        public async Task<RegisteredUser> GetRegisteredUserById(Guid id)
        {
            return await _chessDbContext.RegisteredUsers.FindAsync(id);
        }

        public async Task<RegisteredUser> GetRegisteredUserBySub(string sub)
        {
            return await _chessDbContext.RegisteredUsers.FirstOrDefaultAsync(u => u.UserProfileId == sub);
        }

        public async Task<UserBase> GetTemporaryUser(Guid id)
        {
            return await _chessDbContext.TemporaryUsers.FindAsync(id);
        }

        public async Task<IEnumerable<UserBase>> GetAllUser()
        {
            return await _chessDbContext.TemporaryUsers.ToListAsync();
        }

        public async Task<RegisteredUser> CreateRegisteredUser(RegisteredUser user)
        {
            await _chessDbContext.RegisteredUsers.AddAsync(user);
            await _chessDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserBase> CreateTemporaryUser(UserBase temporaryUser)
        {
            await _chessDbContext.TemporaryUsers.AddAsync(temporaryUser);
            await _chessDbContext.SaveChangesAsync();
            return temporaryUser;
        }

        public async Task<RegisteredUser> UpdateRegisteredUser(RegisteredUser updatedUser)
        {
            _chessDbContext.RegisteredUsers.Update(updatedUser);
            await _chessDbContext.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<UserBase> UpdateTemporaryUser(UserBase updatedUser)
        {
            _chessDbContext.TemporaryUsers.Update(updatedUser);
            await _chessDbContext.SaveChangesAsync();
            return updatedUser;
        }

        public async Task DeleteTemporaryUser(Guid id)
        {
            var user = await _chessDbContext.TemporaryUsers.FindAsync(id);
            _chessDbContext.TemporaryUsers.Remove(user);

        }

        public async Task DeleteRegisteredUser(Guid id)
        {
            var registeredUser = await _chessDbContext.RegisteredUsers.FindAsync(id);
            _chessDbContext.RegisteredUsers.Remove(registeredUser);
        }
    }
}
