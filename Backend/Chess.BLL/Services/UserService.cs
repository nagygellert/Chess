using AutoMapper;
using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Chess.DAL.Repositories.Interfaces;
using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILobbyConfigRepository _lobbyConfigRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, ILobbyConfigRepository lobbyConfigRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _lobbyConfigRepository = lobbyConfigRepository;
        }

        public async Task<UserDTO> GetRegisteredUser(Guid id)
        {
            var efUser = await _userRepository.GetRegisteredUserById(id);
            return _mapper.Map<UserDTO>(efUser);
        }

        public async Task<UserDTO> GetRegisteredUserBySub(string sub)
        {
            var efUser = await _userRepository.GetRegisteredUserBySub(sub);
            return _mapper.Map<UserDTO>(efUser);
        }

        public async Task<TemporaryUserDTO> GetTemporaryUser(Guid id)
        {
            var efUser = await _userRepository.GetTemporaryUser(id);
            return _mapper.Map<TemporaryUserDTO>(efUser);
        }

        public async Task<IEnumerable<TemporaryUserDTO>> GetAllUser()
        {
            var efUser = await _userRepository.GetAllUser();
            return _mapper.Map<IEnumerable<TemporaryUserDTO>>(efUser);
        }

        public async Task<UserDTO> CreateRegisteredUser(UserDTO user)
        {
            var existingUser = await _userRepository.GetRegisteredUserBySub(user.Sub);
            if (existingUser == null)
            {
                var userToInsert = _mapper.Map<RegisteredUser>(user);
                var insertedUser = await _userRepository.CreateRegisteredUser(userToInsert);
                return _mapper.Map<UserDTO>(insertedUser);
            }
            return _mapper.Map<UserDTO>(existingUser);
        }

        public async Task<TemporaryUserDTO> CreateTemporaryUser(TemporaryUserDTO temporaryUser)
        {
            var userToInsert = _mapper.Map<UserBase>(temporaryUser);
            var lobby = await _lobbyConfigRepository.GetLobbyConfigByCode(temporaryUser.LobbyCode);
            userToInsert.Lobby = lobby;
            var insertedUser = await _userRepository.CreateTemporaryUser(userToInsert);
            return _mapper.Map<TemporaryUserDTO>(insertedUser);
        }

        public async Task<UserDTO> UpdateRegisteredUser(UserDTO updatedUser)
        {
            var mappedUser = _mapper.Map<RegisteredUser>(updatedUser);
            var result = await _userRepository.UpdateRegisteredUser(mappedUser);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<TemporaryUserDTO> UpdateTemporaryUser(TemporaryUserDTO updatedUser)
        {
            var mappedUser = _mapper.Map<UserBase>(updatedUser);
            var result = await _userRepository.UpdateTemporaryUser(mappedUser);
            return _mapper.Map<TemporaryUserDTO>(result);
        }

        public async Task DeleteRegisteredUser(Guid id)
        {
            await _userRepository.DeleteRegisteredUser(id);
        }

        public async Task DeleteTemporaryUser(Guid id)
        {
            await _userRepository.DeleteTemporaryUser(id);
        }
    }
}
