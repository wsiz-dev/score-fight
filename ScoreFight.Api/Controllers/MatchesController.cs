using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScoreFight.Domain;
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
    }
}
