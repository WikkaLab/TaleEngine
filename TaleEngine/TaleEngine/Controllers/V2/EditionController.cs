using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V2
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class EditionController : Controller
    {
        private readonly IEditionCommands _command;

        public EditionController(IEditionCommands command)
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