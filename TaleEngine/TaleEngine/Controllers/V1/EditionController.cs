﻿using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EditionController : Controller
    {
        private readonly IEditionQueries _command;

        public EditionController(IEditionQueries command)
        {
            _command = command;
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetEditionDays(int editionId)
        {
            var result = _command.EditionDaysQuery(editionId);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}