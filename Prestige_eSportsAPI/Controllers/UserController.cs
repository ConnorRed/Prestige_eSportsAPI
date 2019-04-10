using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prestige_eSports.Repo.Context;
using Prestige_eSports.Service.Interfaces;
using System.Net.Http;
using System.Web.Http;
using Prestige_eSports.Core.Models;

namespace Prestige_eSportsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
           return CreatedAtAction("Get", _userService.Get().ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");
            await _userService.InsertNewUser(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");
            await _userService.DeleteUser(user);
            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");
            await _userService.UpdateUser(user);
            return Ok();
        }
    }
}
