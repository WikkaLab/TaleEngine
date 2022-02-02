using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.Commands.Contracts;

namespace TaleEngine.API.Controllers.Backoffice
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserCommands _command;

        public UserController(IUserCommands command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllUsers()
        {
            var result = _command.GetAllUsers();

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult ActivateUser(int userId)
        {
            var result = _command.ActivateUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult BanUser(int userId)
        {
            var result = _command.BanUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult DeactivateUser(int userId)
        {
            var result = _command.DeactivateUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult MarkAsPendingUser(int userId)
        {
            var result = _command.MarkAsPendingUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult ReviewUser(int userId)
        {
            var result = _command.ReviewUser(userId);

            return Ok(result);
        }
    }
}
