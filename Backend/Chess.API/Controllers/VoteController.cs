using Chess.BLL.DTOs;
using Chess.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chess.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string id, VoteDTO vote)
        {
            var allMsg = await _voteService.InsertVote(id, vote);
            return Ok(allMsg);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var msg = await _voteService.GetVotesForLobby(id);
            return Ok(msg);
        }
    }
}
