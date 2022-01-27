using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers.Backoffice
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("[action]")]
        public IActionResult GetAllUsers()
        {
            var result = _userService.GetAllUsers();

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult ActivateUser(int userId)
        {
            var result = _userService.ActivateUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult BanUser(int userId)
        {
            var result = _userService.BanUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult DeactivateUser(int userId)
        {
            var result = _userService.DeactivateUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult MarkAsPendingUser(int userId)
        {
            var result = _userService.MarkAsPendingUser(userId);

            return Ok(result);
        }

        [HttpPut("[action]")]
        public IActionResult ReviewUser(int userId)
        {
            var result = _userService.ReviewUser(userId);

            return Ok(result);
        }
    }
}
