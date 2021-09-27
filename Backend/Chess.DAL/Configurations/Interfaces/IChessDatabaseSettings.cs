using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.DAL.Configurations.Interfaces
{
    public interface IChessDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string ChatMessagesCollectionName { get; set; }

        string LobbiesCollectionName { get; set; }

        string LobbyConfigCollectionName { get; set; }

        string VotesCollectionName { get; set; }

        string MovesCollectionName { get; set; }
    }
}
