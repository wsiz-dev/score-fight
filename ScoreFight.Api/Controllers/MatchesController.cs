using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScoreFight.Domain;
using ScoreFight.Domain.Bets.Command;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Api.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns active matches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Match>), 200)]
        public IActionResult Get()
        {
            var result = _mediator.Query(new GetActiveMatchesQuery());
            return Ok(result);
        }

        /// <summary>
        /// Set user bet for given match
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /matches/bet
        ///     {
        ///         "matchId": "4ec510a9-40b0-421b-8f81-eb1ae26debc6",
        ///         "userId": "1e940b6e-abaf-492e-96b5-fe9e885c3520",
        ///         "teamBet": "2",
        ///         "pointsBet": 100
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="202">Bet correctly inserted</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Given match was not found</response>
        [HttpPost]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Bet([FromBody] SetBetCommand command)
        {
            try
            {
                _mediator.Command(command);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
