using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScoreFight.Domain;
using ScoreFight.Domain.Players;
using ScoreFight.Domain.Players.Queries;

namespace ScoreFight.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns player by given ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Player), 200)]
        public IActionResult GetById(Guid id)
        {
            var result = _mediator.Query(new GetPlayerByIdQuery(id));
            if (result == null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }

        /// <summary>
        /// Returns players ranking
        /// </summary>
        /// <returns></returns>
        [HttpGet("ranking")]
        [ProducesResponseType(typeof(IEnumerable<RankingPosition>), 200)]
        public IActionResult GetRanking()
        {
            var result = _mediator.Query(new GetRankingQuery());
            return Ok(result);
        }

        /// <summary>
        /// Get player bet matches
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET api/players/{playerId}/bet-matches
        ///     {   
        ///         "playerId": "C9888D13-E9DA-454A-86A2-62BEC0302F2D",
        ///     }
        /// 
        /// </remarks>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        [HttpGet("{playerId}/bet-matches")]
        [ProducesResponseType(200)]
        public IActionResult MyBets([FromRoute] GetPlayerBetMatchesQuery query)
        {
            return Ok(_mediator.Query(query));
        }
    }
}
