using Chess.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.DAL.Repositories.Interfaces
{
    public interface ILobbyConfigRepository
    {
        Task<LobbyConfig> GetLobbyConfig(string id);

        Task<LobbyConfig> InsertOne(LobbyConfig config);

        Task DeleteLobbyConfig(string id);
    }
}
