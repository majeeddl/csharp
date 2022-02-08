using CoreWebApi.Entities;
using CoreWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {

        private IUserService _userService;
        public AuthenticateController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {
            return "salam";
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = this._userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username And Password are incorrect " });
            return Ok(user);
        }
    }
}
