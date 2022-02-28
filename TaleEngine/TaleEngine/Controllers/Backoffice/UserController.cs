using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.CQRS.Contracts;

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
            var result = _command.AllUsersQuery();

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult ActivateUser(int userId)
        {
            _command.ActivateCommand(userId);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult BanUser(int userId)
        {
            _command.BanCommand(userId);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult DeactivateUser(int userId)
        {
            _command.DeactivateCommand(userId);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult MarkAsPendingUser(int userId)
        {
            _command.MarkAsPendingCommand(userId);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult ReviewUser(int userId)
        {
            _command.ReviewCommand(userId);

            return Ok();
        }
    }
}
