using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prestige_eSports.Core.Models;
using Prestige_eSports.Service.Interfaces;
using Prestige_eSports.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestige_eSportsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] User user)
        {
            var token = _userService.ValidateUser(user.Username, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.Get().ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userService.GetById(id);
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
                var inserted = await _userService.InsertNewUser(user);
                return CreatedAtRoute("api/user POST", new { id = user.UserId }, user);
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

                var existingUser = _userService.GetFirstOrDefault(user.UserId);
                if(existingUser == null)
                    return BadRequest("This user does not exist");
                    
                var deleted = await _userService.DeleteUser(user); ;
                return Ok(deleted);
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

                var existingUser = _userService.GetFirstOrDefault(user.UserId);
                if(existingUser == null)
                    return BadRequest("This user does not exist");
                
                var updated = await _userService.UpdateUser(user);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
