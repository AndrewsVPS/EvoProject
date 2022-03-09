using EvoSystems.Application.Interfaces;
using EvoSystems.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evo_Systems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = (UserService)userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            this.userService.Test();
            return Ok("Ok");
        }
    }
}
