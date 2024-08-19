using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Web.Http;
using System;
using System.Security.Cryptography;

namespace WebThucPham.Controllers
{
    public class AuthController : ApiController
    {


        [HttpPost]
        [Route("api/auth/token")]
        public IHttpActionResult GetToken(string username, string password)
        {

            if (username == "tamlh" && password == "123") // Kiểm tra thông tin đăng nhập
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = "ákjdhajsdhjsad";
                var key = Encoding.UTF8.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
