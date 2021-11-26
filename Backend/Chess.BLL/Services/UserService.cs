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

        public async Task<UserDTO> GetUser(Guid id)
        {
            var efUser = await _userRepository.GetUser(id);
            var mappedUser = _mapper.Map<UserDTO>(efUser);
            if (efUser.LobbyConfigId.HasValue)
            {
                var lobby = await _lobbyConfigRepository.GetLobbyConfigById(efUser.LobbyConfigId.Value);
                mappedUser.LobbyName = lobby.Name;
            }
            return mappedUser;
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

        public async Task<UserDTO> CreateTemporaryUser(UserDTO temporaryUser)
        {
            var userToInsert = _mapper.Map<UserBase>(temporaryUser);
            var insertedUser = await _userRepository.CreateUser(userToInsert);
            return _mapper.Map<UserDTO>(insertedUser);
        }

        public async Task<UserDTO> UpdateRegisteredUser(UserDTO updatedUser)
        {
            var mappedUser = _mapper.Map<RegisteredUser>(updatedUser);
            var result = await _userRepository.UpdateRegisteredUser(mappedUser);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task<UserDTO> UpdateUser(UserDTO updatedUser)
        {
            var mappedUser = _mapper.Map<UserBase>(updatedUser);
            var result = await _userRepository.UpdateUser(mappedUser);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<UserDTO> SwapSides(Guid id)
        {
            var user = await _userRepository.GetUser(id);
            user.Side = user.Side == Models.Enums.Side.White ? Models.Enums.Side.Black : Models.Enums.Side.White;
            return _mapper.Map<UserDTO>(await _userRepository.UpdateUser(user));
        }
    }
}
