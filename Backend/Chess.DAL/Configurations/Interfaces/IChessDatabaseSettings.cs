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
    }
}
