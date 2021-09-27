using Chess.BLL.Interfaces;
using Chess.BLL.MapperProfiles;
using Chess.BLL.Services;
using Chess.DAL.Configurations.Interfaces;
using Chess.DAL.Configurations.Services;
using Chess.DAL.Repositories.Interfaces;
using Chess.DAL.Repositories.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ChessDatabaseSettings>(Configuration.GetSection(nameof(ChessDatabaseSettings)));

            services.AddSingleton<IChessDatabaseSettings>(sp =>
                        sp.GetRequiredService<IOptions<ChessDatabaseSettings>>().Value);
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<ILobbyConfigRepository, LobbyConfigRepository>();
            services.AddTransient<ILobbyRepository, LobbyRepository>();
            services.AddTransient<IMoveRepository, MoveRepository>();
            services.AddTransient<IVoteRepository, VoteRepository>();
            services.AddTransient<ILobbyService, LobbyService>();
            services.AddTransient<IMoveService, MoveService>();
            services.AddTransient<IVoteService, VoteService>();
            services.AddAutoMapper(typeof(ChessProfile));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Chess", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chess v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
