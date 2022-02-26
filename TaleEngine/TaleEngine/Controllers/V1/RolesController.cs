using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    /// <summary>
    /// Roles management
    /// </summary>
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ControllerName("Management roles and permissions associated")]
    [Route("api/v1/[controller]")]
    public class RolesController : Controller
    {
        private IRoleCommands _command;

        /// <summary>
        /// Constructor for roles controller
        /// </summary>
        /// <param name="command">Role service</param>
        public RolesController(IRoleCommands command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

    }
}
