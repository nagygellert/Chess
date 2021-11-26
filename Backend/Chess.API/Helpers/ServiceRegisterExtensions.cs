using Chess.BLL.Interfaces;
using Chess.BLL.Services;
using Chess.DAL.Repositories.Interfaces;
using Chess.DAL.Repositories.Services;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.Helpers
{
    public static class ServiceRegisterExtensions
    {

        public static void AddHangfireServices(this IServiceCollection services, IConfiguration config)
        {
            var sqlOptions = new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            };
            services.AddHangfire(configuration => configuration
                  .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                  .UseSimpleAssemblyNameTypeSerializer()
                  .UseRecommendedSerializerSettings()
                  .UseSqlServerStorage(config.GetConnectionString("HangfireDatabase"), sqlOptions));
            JobStorage.Current = new SqlServerStorage(config.GetConnectionString("HangfireDatabase"), sqlOptions);
            using (var connection = JobStorage.Current.GetConnection())
            {
                foreach (var job in connection.GetRecurringJobs())
                {
                    RecurringJob.RemoveIfExists(job.Id);
                }
                foreach (var job in JobStorage.Current.GetMonitoringApi().ProcessingJobs(0, int.MaxValue))
                {
                    BackgroundJob.Delete(job.Key);
                }
                foreach (var job in JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue))
                {
                    BackgroundJob.Delete(job.Key);
                }
            }
            services.AddHangfireServer();

        }

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
        }
    }
}
