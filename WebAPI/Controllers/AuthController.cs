using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Helpers.Abstract;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private IJwtTokenGenerater _jwtTokenGenerater;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private readonly byte[] key;
        public AuthController(IConfiguration config, IJwtTokenGenerater jwtTokenGenerater, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _config = config;
            _jwtTokenGenerater = jwtTokenGenerater;
            _userManager = userManager;
            _signInManager = signInManager;
            key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var appUser = await _userManager.Users.SingleOrDefaultAsync(r => r.UserName == model.UserName);
                var tokenString = _jwtTokenGenerater
                    .Generate(new Claim[] { new Claim(ClaimTypes.Name, appUser.UserName) }, key, 7)
                    .WriteToken();

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]LoginModel model)
        {
            var user = new IdentityUser{UserName = model.UserName};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var tokenString = _jwtTokenGenerater
                    .Generate(new Claim[] { new Claim(ClaimTypes.Name, user.UserName) }, key, 7)
                    .WriteToken();

                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}