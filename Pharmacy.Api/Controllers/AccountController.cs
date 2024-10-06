using Dto;
using BCrypt.Net;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.AspNetCore.Identity;

namespace Pharmacy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiBaseController
    {
        private readonly IConfiguration _config;

        public AccountController(IUnitOfWork unitOfWork, IConfiguration config) : base(unitOfWork)
        {
            _config = config;
        }

        [HttpPost("Register")]
        public IActionResult Register(Registerdto user1)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user1.Password);

            User s = new User
            {
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                Email = user1.Email,
                Phone = user1.Phone,
                Address = user1.Address,
                PasswordHash = passwordHash,
                RoleId = 2

            };

            _unitOfWork.Users.Add(s);
            _unitOfWork.Save();

            return Ok("Done");
        }

        [HttpPost("Login")]
        public IActionResult Login(logindto l)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the user by email
            var user = _unitOfWork.Users
                        .GetAll()
                        .FirstOrDefault(z => z.Email == l.Email);

            if (user != null)
            {
                if (user.PasswordHash == null)
                {
                    return BadRequest("Password hash not found.");
                }
                // Verify the provided password against the stored hash
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(l.Password, user.PasswordHash);

                if (isPasswordValid)
                {
                    // Create user claims
                    List<Claim> userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

                    // Create the JWT key and credentials
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecritKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Create the JWT token
                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: _config["Jwt:IssuerIP"],
                        audience: _config["Jwt:AudienceIP"],
                        claims: userClaims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds
                    );

                    // Return the generated JWT token
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(mytoken)
                    });
                }
            }

            return Unauthorized();
        }
    }
}

