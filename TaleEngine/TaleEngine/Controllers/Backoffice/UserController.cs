using Microsoft.AspNetCore.Mvc;
using System;
using TaleEngine.Application.Contracts.Services;

namespace TaleEngine.Controllers.Backoffice
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException();
        }
    }
}
