using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [Obsolete("This API version is deprecated. Please use V1 instead.")]
    [ApiController]
    [Route("api/v2/[controller]")]
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

        [HttpGet("[action]/{eventId}")]
        public IActionResult GetEditionsBy(int eventId) {
            var result = _command.EditionsQuery(eventId);

            if (result == null) {
                return NoContent();
            }

            return Ok(result);
        }
    }
}