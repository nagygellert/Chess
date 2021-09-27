using Chess.DAL.Configurations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.DAL.Configurations.Services
{
    public class ChessDatabaseSettings : IChessDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string ChatMessagesCollectionName { get; set; }

        public string LobbiesCollectionName { get; set; }

        public string LobbyConfigCollectionName { get; set; }

        public string VotesCollectionName { get; set; }

        public string MovesCollectionName { get; set; }
    }
}
