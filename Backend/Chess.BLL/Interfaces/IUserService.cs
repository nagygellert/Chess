using Chess.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetRegisteredUser(Guid id);

        Task<UserDTO> GetRegisteredUserBySub(string sub);

        Task<UserDTO> GetUser(Guid id);

        Task<UserDTO> CreateRegisteredUser(UserDTO user);

        Task<UserDTO> CreateTemporaryUser(UserDTO temporaryUser);

        Task<UserDTO> UpdateRegisteredUser(UserDTO updatedUser);

        Task<UserDTO> UpdateUser(UserDTO updatedUser);

        Task<UserDTO> SwapSides(Guid id);

        Task DeleteUser(Guid id);
    }
}
