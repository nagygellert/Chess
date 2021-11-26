using Chess.API.SignalRHubs.Interfaces;
using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Hangfire;
using Hangfire.Storage;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.SignalRHubs.Services
{
    public class LobbyHub : Hub<ILobbyHub>
    {
        private const string _suffix = "Lobby";
        private const string LobbyGroup = "LobbySearchGroup";
        private readonly ILobbyConfigService _lobbyConfigService;
        private readonly IUserService _userService;
        private readonly ILobbyService _lobbyService;
        private readonly IVoteService _voteService;
        private readonly IHubContext<LobbyHub> _context;

        public LobbyHub(ILobbyConfigService lobbyConfigService, IUserService userService, ILobbyService lobbyService, IVoteService voteService,
            IHubContext<LobbyHub> context)
        {
            _lobbyConfigService = lobbyConfigService;
            _userService = userService;
            _lobbyService = lobbyService;
            _voteService = voteService;
            _context = context;
        }

        public async Task SwapSides(UserDTO player, string lobbyName)
        {
            await _userService.SwapSides(player.Id);
            var lobby = await _lobbyConfigService.GetLobbyConfigByName(lobbyName);
            await Clients.Group($"{lobbyName}{_suffix}").SetLobby(lobby);
        }

        public async Task EnterLobby(UserDTO player, string lobbyName)
        {
            var lobby = await _lobbyConfigService.GetLobbyConfigByName(lobbyName);
            if (lobby == null)
                await Clients.Caller.SetLobby(null);
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"{lobbyName}{_suffix}");
                var lobbyConfig = await _lobbyConfigService.AddPlayerToLobby(player, lobbyName);
                var user = await _userService.GetUser(player.Id);
                await Clients.Group($"{lobbyName}{_suffix}").PlayerJoined(user);
                await Clients.Caller.SetLobby(lobbyConfig);
                if (lobby.GameStarted)
                {
                    await Clients.Caller.SetMoves(await _lobbyService.GetTableMoves(lobbyName));
                }
                 
            }
        }

        public async Task AddVote(VoteDTO vote)
        {
            await _voteService.InsertVote(vote);
            await Clients.Group($"{vote.LobbyName}{_suffix}").SetVotes(await _voteService.GetVotesForLobby(vote.LobbyName, vote.Round));
        }

        public async Task StartGame(string lobbyName)
        {
            var board = await _lobbyService.CreateLobby(lobbyName);
            var lobbyConfig = await _lobbyConfigService.GetLobbyConfigByName(lobbyName);
            //await Clients.Group($"{lobbyName}{_suffix}").SetBoard(board);
            await Clients.Group($"{lobbyName}{_suffix}").SetLobby(lobbyConfig);
            RecurringJob.AddOrUpdate<LobbyHub>($"{lobbyName}update", (lobby) => lobby.RoundEnded(lobbyName), "*/20 * * * * *");
        }

        public async Task RoundEnded(string lobbyName)
        {
            await _voteService.SummarizeVotes(lobbyName);
            await _lobbyConfigService.IncrementTurn(lobbyName);
            await _context.Clients.Group($"{lobbyName}{_suffix}").SendAsync("SetMoves", await _lobbyService.GetTableMoves(lobbyName));
            var asd = JobStorage.Current.GetConnection().GetRecurringJobs().FirstOrDefault(x => x.Id == $"{lobbyName}update");
            var roundEnd = asd?.NextExecution;
            await _context.Clients.Group($"{lobbyName}{_suffix}").SendAsync("SetRoundEnd", roundEnd);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = new Guid(Context.GetHttpContext().Request.Query["userId"]);
            var user = await _userService.GetUser(userId);
            var lobby = await _lobbyConfigService.GetLobbyConfigByName(user.LobbyName);
            if (lobby != null && lobby.Owner.Id == userId)
            {
                RecurringJob.RemoveIfExists($"{user.LobbyName}update");
                await _lobbyConfigService.DeleteLobbyConfig(lobby.Name);
                await Clients.Group($"{user.LobbyName}{_suffix}").OwnerLeft();
            }
            else 
                await Clients.Group($"{user.LobbyName}{_suffix}").PlayerLeft(user);
            await _lobbyConfigService.RemovePlayerFromLobby(userId);
            //await Clients.Group($"{user.LobbyName}{_suffix}").SetLobby(lobby);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
