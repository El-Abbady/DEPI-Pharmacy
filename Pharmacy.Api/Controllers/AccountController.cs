using Dto;
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

            User s = new User
            {
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                Email = user1.Email,
                PasswordHash = user1.Password,
                RoleId=user1?.RoleId

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

           
            var user = _unitOfWork.Users
                        .GetAll()
                        .FirstOrDefault(z => z.Email == l.Email);

            if (user != null)
            {
          
                //bool va = BCrypt.Net.BCrypt.Verify(l.Password, user.PasswordHash);
                if (l.Password==user.PasswordHash)
                {
               
                    List<Claim> userclaim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName),
                 new Claim(ClaimTypes.Role, user.RoleId.ToString())
                    };

                   


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecritKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    
                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: _config["Jwt:IssuerIP"],
                        audience: _config["Jwt:AudienceIP"],
                        claims: userclaim,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: creds
                    );

                   
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
