using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        public IConfiguration _configuration;

        public ClientController(IConfiguration config)
        {
            _configuration = config;
        }    
        
        [HttpPost]
        [Route("api")]
        public IActionResult GenerateToken([FromBody]ClientDTO Login)
        {
            if(Login != null && Login.login != null && Login.passwd != null)
            {
                var user = model.Client.GetLogin(Login);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                if(user != null )
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserEmail", user.getEmail()),
                        new Claim("UserName", user.getName())
                    };

                    var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var SignIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                    var Token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: SignIn);

                    var response = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(Token),
                        email = user.getEmail()                    
                    };

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
        public IActionResult registerClient([FromBody] ClientDTO clientDTO)
        {
            var client = model.Client.convertDTOToModel(clientDTO);

            var id = client.save();

            var NewClient = new 
            {
                name = clientDTO.name,
                date_of_birth = clientDTO.date_of_birth,
                document = clientDTO.document,
                email = clientDTO.email,
                phone = clientDTO.phone,
                login = clientDTO.login,
                passwd = clientDTO.passwd,
                address = clientDTO.address,
                id = id
            };

            var result = new ObjectResult(NewClient);

            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public IActionResult getInformations([FromBody] int clientID)
        {
            var ClientInfo = model.Client.find(clientID);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(ClientInfo);

            return result;
        }
    }
}