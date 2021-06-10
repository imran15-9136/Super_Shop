using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuperShop.Models.Common;
using SuperShop.Models.RequestModel.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationUser> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationUser> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]ApplicationUserCreateDto model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist!=null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status="Error", Massage="User Alreate Exist"});
            }
            else
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var result = _userManager.CreateAsync(user, model.Password);

                if (!result.IsCompletedSuccessfully)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Massage = "User Unable to Create" });
                }
            }
            return Ok( new Response { Status="Success", Massage="User Create Successfully." });
        }
    }
}
