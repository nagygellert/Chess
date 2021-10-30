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

        Task<IEnumerable<TemporaryUserDTO>> GetAllUser();

        Task<TemporaryUserDTO> GetTemporaryUser(Guid id);

        Task<UserDTO> CreateRegisteredUser(UserDTO user);

        Task<TemporaryUserDTO> CreateTemporaryUser(TemporaryUserDTO temporaryUser);

        Task<UserDTO> UpdateRegisteredUser(UserDTO updatedUser);

        Task<TemporaryUserDTO> UpdateTemporaryUser(TemporaryUserDTO updatedUser);

        Task DeleteTemporaryUser(Guid id);

        Task DeleteRegisteredUser(Guid id);
    }
}
