using Chess.BLL.Interfaces;
using Chess.BLL.Services;
using Chess.DAL.Repositories.Interfaces;
using Chess.DAL.Repositories.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.Helpers
{
    public static class ServiceRegisterExtensions
    {
        public static void AddChessServices(this IServiceCollection services)
        {
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<ILobbyConfigRepository, LobbyConfigRepository>();
            services.AddScoped<ILobbyRepository, LobbyRepository>();
            services.AddScoped<IMoveRepository, MoveRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<ILobbyService, LobbyService>();
            services.AddScoped<IMoveService, MoveService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILobbyConfigRepository, LobbyConfigRepository>();
            services.AddScoped<ILobbyConfigService, LobbyConfigService>();
            services.AddScoped<Random>();
        }
    }
}
