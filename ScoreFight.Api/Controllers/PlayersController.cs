﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScoreFight.Domain;
using ScoreFight.Domain.Players;

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
        [ProducesResponseType(typeof(IEnumerable<Player>), 200)]
        public IActionResult GetById(Guid id)
        {
            var result = _mediator.Query(new GetPlayerByIdQuery(id));
            if (result == null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }
    }
}
