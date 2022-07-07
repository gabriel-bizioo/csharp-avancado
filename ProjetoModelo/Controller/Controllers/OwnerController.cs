using model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Controller.Controllers
{
    [ApiController]
    [Route("owner")]
    public class OwnerController : ControllerBase
    {
        public IConfiguration _configuration;

        public OwnerController(IConfiguration config)
        {
           _configuration = config;
        } 

        [HttpPost]
        [Route("api")]
        public IActionResult GenerateToken([FromBody]OwnerDTO Login)
        {
            Console.Write("entrando no login");
            if(Login != null && Login.login != null && Login.passwd != null)
            {
                var user = model.Owner.GetLogin(Login);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                if(user != null )
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.getID().ToString()),
                        new Claim("UserName", user.getName()),
                        new Claim("Email", user.getEmail())
                    };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var SignIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                    var Token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: SignIn);

                    var response = new{
                        token = new JwtSecurityTokenHandler().WriteToken(Token),
                        clientId = user.getID().ToString()
                    }   ;

                    return Ok(response);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
                
            }
            else
            {
                return BadRequest("deu ruim");
            }
        }




        [HttpPost]
        [Route("register")]
        public object registerOwner([FromBody]OwnerDTO ownerDTO)
        {
            var owner = model.Owner.convertDTOToModel(ownerDTO);

            var id = owner.save();

            return new 
            {
                name = ownerDTO.name,
                date_of_birth = ownerDTO.date_of_birth,
                document = ownerDTO.document,
                email = ownerDTO.email,
                phone = ownerDTO.phone,
                login = ownerDTO.login,
                passwd = ownerDTO.passwd,
                address = Address.convertDTOToModel(ownerDTO.owner_address),
                ID = id
            };
        }
        
        [HttpGet]
        [Route("get")]
        public object getInformations([FromBody] int ownerID)
        {
            var ownerInfo = model.Owner.find(ownerID);

            return ownerInfo;
        }
    }
}