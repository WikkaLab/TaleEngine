using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TaleEngine.Application.Commands;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Extensions;
using TaleEngine.Application.Queries;

namespace TaleEngine.Controllers.V3
{
    [Route("api/v3/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IActivityQueries _activityQueries;
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(
            IMediator mediator,
            IActivityQueries activityQueries,
            ILogger<ActivityController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _activityQueries = activityQueries ?? throw new ArgumentNullException(nameof(activityQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("[action]/{editionId}")]
        public IActionResult GetActivities(int editionId)
        {
            try
            {
                //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
                //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
                var result = _activityQueries.GetActivities(editionId);

                return Ok(result);
            }
            catch
            {
                return NotFound();
            }

            //var result = _activityService.GetActiveActivities(editionId);

            //if (result == null || result.Count == 0)
            //{
            //    return NoContent();
            //}
            //return Ok(result);
        }

        [Route("draft")]
        [HttpPost]
        public async Task<ActionResult<ActivityDto>> CreateActivityAsync([FromBody] CreateActivityCommand createActivityCommand)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                createActivityCommand.GetGenericTypeName(),
                nameof(createActivityCommand.EditionId),
                createActivityCommand.EditionId,
                createActivityCommand);

            return await _mediator.Send(createActivityCommand);
        }
    }
}