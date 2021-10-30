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
        Task<UserBase> GetTemporaryUser(Guid id);

        Task<RegisteredUser> GetRegisteredUserById(Guid id);

        Task<IEnumerable<UserBase>> GetAllUser();

        Task<RegisteredUser> GetRegisteredUserBySub(string sub);

        Task<UserBase> CreateTemporaryUser(UserBase user);

        Task<RegisteredUser> CreateRegisteredUser(RegisteredUser user);

        Task<RegisteredUser> UpdateRegisteredUser(RegisteredUser updatedUser);

        Task<UserBase> UpdateTemporaryUser(UserBase updatedUser);

        Task DeleteTemporaryUser(Guid id);

        Task DeleteRegisteredUser(Guid id);
    }
}
