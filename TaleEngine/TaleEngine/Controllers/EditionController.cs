using Microsoft.AspNetCore.Mvc;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class EditionController : Controller
    {
        private readonly IEditionService _editionService;

        public EditionController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpGet("[action]/{editionId}")]
        [MapToApiVersion("1")]
        public IActionResult GetEditionDays(int editionId)
        {
            var result = _editionService.GetEditionDays(editionId);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}