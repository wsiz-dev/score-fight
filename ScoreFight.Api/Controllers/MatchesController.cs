using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScoreFight.Domain;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Matches.Commands;
using ScoreFight.Domain.Matches.Queries;

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
        /// Get match by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Match), 200)]
        public IActionResult GetById(Guid id)
        {
            var result = _mediator.Query(new GetMatchByIdQuery(id));
            if (result == null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }

        /// <summary>
        /// Set match result and count points for players
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/matches/end
        ///     {
        ///         "matchId": "081ede0d-2fdf-4d0b-9b8e-6cc256deacd0",
        ///         "matchResult": 2
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="202">Bet correctly deleted</response>
        /// <response code="404">Given bet was not found</response>
        /// 
        [Route("end")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<Match>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Match>), 404)]
        public IActionResult EndMatch([FromBody] EndMatchCommand command)
        {
            try
            {
                _mediator.Command(command);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
