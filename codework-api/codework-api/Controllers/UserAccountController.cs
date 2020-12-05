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
    [Route("[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private CodeWorkContext _context;

        public UserAccountController()
        {
            _context = new CodeWorkContext();
        }

        [HttpPost("login")]
        public Object Login(LoginDTO login)
        {
            using (_context)
            {
                var userInDb = _context.UserLogins.SingleOrDefault(x => x.Username == login.Username);

                if (userInDb != null)
                {
                    if (userInDb.Password.Trim() == login.Password.Trim())
                        return GetToken(userInDb.UserId);
                }
                
                return BadRequest("Invalid username or password.");
            }
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
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
