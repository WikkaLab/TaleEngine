using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaleEngine.Application.Contracts.Dtos;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers.V1
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
        private IRoleService _roleService;

        /// <summary>
        /// Constructor for roles controller
        /// </summary>
        /// <param name="roleService">Role service</param>
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
        }

    }
}
