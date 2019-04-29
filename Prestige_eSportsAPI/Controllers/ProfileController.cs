using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prestige_eSports.Core.Models;
using Prestige_eSports.Data.Models;
using Prestige_eSports.Service.Interfaces;
using Prestige_eSports.Service.Services;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestige_eSportsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> Get(int id)
        {
            var Profile = await _profileService.GetById(id);
            if (Profile == null)
                return NotFound();
            return Ok(Profile);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] Profile Profile)
        {
            try
            {
                if (Profile == null)
                    return BadRequest("Profile cannot be null");
                var inserted = await _profileService.InsertNewProfile(Profile);
                return CreatedAtRoute($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name}", new { id = Profile.ProfileId }, Profile);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] Profile Profile)
        {
            try
            {
                if (Profile == null)
                    return BadRequest("Profile cannot be null");

                var existingUser = _profileService.GetFirstOrDefault(Profile.ProfileId);
                if(existingUser == null)
                    return BadRequest("This Profile does not exist");
                    
                var deleted = await _profileService.DeleteProfile(Profile); ;
                return Ok(deleted);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Update([FromBody] Profile Profile)
        {
            try
            {
                if (Profile == null)
                    return BadRequest("Profile cannot be null");

                var existingUser = _profileService.GetFirstOrDefault(Profile.ProfileId);
                if(existingUser == null)
                    return BadRequest("This Profile does not exist");
                
                var updated = await _profileService.UpdateProfile(Profile);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
