using codework_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace codework_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private CodeWorkContext _context;

        public UserAccountController()
        {
            _context = new CodeWorkContext();
        }

        [HttpPost("login")]
        public Object Login()
        {
            string username = HttpContext.Request.Form["username"];
            string password = HttpContext.Request.Form["password"];

            using (_context)
            {
                var userInDb = _context.UserLogins.SingleOrDefault(x => x.Username == username);
                if (userInDb.Password.Trim() == password.Trim())
                {
                    return GetToken(userInDb.UserId);
                }
            }
            return NotFound();
        }

        [NonAction]
        public Object GetToken(int userId)
        {
            string key = "this->CodeWork.pk()";
            var issuer = "http://codework.pk";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("userId", userId.ToString()));

            var token = new JwtSecurityToken(issuer,
                                        issuer,
                                        claims,
                                        expires: DateTime.Now.AddDays(1),
                                        signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return new { token = jwt_token };
        }
    }
}
