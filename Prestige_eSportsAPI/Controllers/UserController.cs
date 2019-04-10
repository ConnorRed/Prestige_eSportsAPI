using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prestige_eSports.Service.Interfaces;
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
            return Ok(_userService.Get().ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User cannot be null");
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User cannot be null");
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User cannot be null");
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
