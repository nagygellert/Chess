using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserBase> GetUser(Guid id);

        Task<RegisteredUser> GetRegisteredUserById(Guid id);

        Task<RegisteredUser> GetRegisteredUserBySub(string sub);

        Task<UserBase> CreateUser(UserBase user);

        Task<RegisteredUser> CreateRegisteredUser(RegisteredUser user);

        Task<RegisteredUser> UpdateRegisteredUser(RegisteredUser updatedUser);

        Task<UserBase> UpdateUser(UserBase updatedUser);

        Task DeleteUser(Guid id);
    }
}
