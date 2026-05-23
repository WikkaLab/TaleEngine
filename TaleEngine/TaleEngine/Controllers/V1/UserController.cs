using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.API.Contracts.Dtos;
using TaleEngine.CQRS.Contracts;

namespace TaleEngine.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserCommands _command;
        private readonly IUserQueries _queries;

        public UserController(IUserCommands command, IUserQueries queries)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult GetUserProfile(int userId)
        {
            var result = _queries.UserQuery(userId);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] UserDto user)
        {
            var result = _command.RegisterCommand(user);

            if (result == null)
            {
                return BadRequest(new { message = "Invalid user information" });
            }

            return Ok(result);
        }

        [HttpPut("[action]/{userId}")]
        public IActionResult UpdateProfile(int userId, [FromBody] UserDto user)
        {
            if (userId == default)
            {
                return BadRequest(new { message = "Invalid user id" });
            }

            _command.UpdateProfileCommand(userId, user);
            return Ok();
        }
    }
}
