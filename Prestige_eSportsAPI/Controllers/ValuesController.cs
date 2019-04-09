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
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }
        // first API everything works
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
           return _userService.Get().ToList();
        }

    }
}
