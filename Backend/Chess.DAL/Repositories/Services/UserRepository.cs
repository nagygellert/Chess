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

        public async Task<UserBase> GetUser(Guid id)
        {
            return await _chessDbContext.Users.FindAsync(id);
        }

        public async Task<RegisteredUser> CreateRegisteredUser(RegisteredUser user)
        {
            await _chessDbContext.RegisteredUsers.AddAsync(user);
            await _chessDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserBase> CreateUser(UserBase temporaryUser)
        {
            await _chessDbContext.Users.AddAsync(temporaryUser);
            await _chessDbContext.SaveChangesAsync();
            return temporaryUser;
        }

        public async Task<RegisteredUser> UpdateRegisteredUser(RegisteredUser updatedUser)
        {
            _chessDbContext.RegisteredUsers.Update(updatedUser);
            await _chessDbContext.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<UserBase> UpdateUser(UserBase updatedUser)
        {
            _chessDbContext.Users.Update(updatedUser);
            await _chessDbContext.SaveChangesAsync();
            return updatedUser;
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _chessDbContext.Users.FindAsync(id);
            _chessDbContext.Users.Remove(user);

        }
    }
}
