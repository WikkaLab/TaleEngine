using Microsoft.AspNetCore.Mvc;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : Controller
    {
        private readonly IEventQueries _queries;

        public EventController(IEventQueries queries)
        {
            _queries = queries;
        }

        [HttpGet("[action]")]
        public IActionResult GetEvents()
        {
            var result = _queries.EventsNoFilterQuery();

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetEvent(int eventId)
        {
            var result = _queries.GetEvent(eventId);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetCurrentEditionInEvent(int eventId) {
            var result = _queries.GetCurrentEdition(eventId);

            return Ok(result);
        }
    }
}
