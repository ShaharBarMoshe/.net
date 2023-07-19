using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Playlist.API.Controllers
{
    [AllowAnonymous]
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {

            var tokenString = GenerateJSONWebToken();
            return Ok(new { token = tokenString });



        }

        private string GenerateJSONWebToken()
        {
            Log.Information("start generate token");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1555555555555523"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("admin",
              "admin",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }


}

