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
        public async Task<ActionResult<User>> Insert([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");
            var found = await _userService.GetById(user.UserId);

            if (found != null)
                return BadRequest("User already exists");

            return CreatedAtAction("Insert", await _userService.InsertNewUser(user));
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");
            var found = await _userService.GetById(user.UserId);

            if (found == null)
                return NotFound();

            return CreatedAtAction("Delete", await _userService.DeleteUser(user));
        }

        [HttpPatch]
        public async Task<ActionResult<User>> Update([FromBody] User user)
        {
            if (user == null)
                return BadRequest("User cannot be null");

            var found = await _userService.GetById(user.UserId);

            if (found == null)
                return NotFound();

            return CreatedAtAction("Update",await _userService.UpdateUser(user));
        }
    }
}
