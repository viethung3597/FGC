using FGC.BI.Authentication;
using FGC.BI.Data.Sys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FGC.BI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private SysDbContext _sysDbContext;

        public ProfileController(SysDbContext sysDbContext)
        {
            _sysDbContext = sysDbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            //var user = await _sysDbContext.Users.Where(x => x.UserName == User.Identity.Name).Select(x => new
            //{
            //    x.Id,
            //    x.UserName,
            //    x.DisplayName
            //}).FirstOrDefaultAsync();
            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, user.UserName),
            //    new Claim("DisplayName", user.DisplayName),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            //};

            return Ok(new
            {
                Id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value,
                UserName = User.Identity.Name,
                DisplayName = User.Claims.FirstOrDefault(x => x.Type == "DisplayName").Value
            });
        }
    }
}
