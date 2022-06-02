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
            Console.Write("entrando no login");
            if(Login != null && Login.Login != null && Login.Passwd != null)
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
                        new Claim("UserId", user.getId().ToString()),
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

                    return Ok(new JwtSecurityTokenHandler().WriteToken(Token));
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
        public object registerClient([FromBody] ClientDTO clientDTO)
        {
            var client = model.Client.convertDTOToModel(clientDTO);

            var id = client.save();

            return new 
            {
                name = clientDTO.Name,
                date_of_birth = clientDTO.DateOfBirth,
                document = clientDTO.Document,
                email = clientDTO.Email,
                phone = clientDTO.Phone,
                login = clientDTO.Login,
                passwd = clientDTO.Passwd,
                address = clientDTO.Address,
                id = id
            };

        }

        [HttpGet]
        [Route("get")]
        public object getInformations([FromBody] int clientID)
        {
            var clientInfo = model.Client.find(clientID);

            return clientInfo;
        }
    }
}