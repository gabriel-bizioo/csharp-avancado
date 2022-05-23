// using DTO;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Cors;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;

// namespace Controller.Controllers
// {
//     public class TokenController
//     {
//         public IConfiguration _configuration;

//         public TokenController(IConfiguration config)
//         {
//             _configuration = config;
//         }    
//         [HttpPost]
//         [Route("api")]
//         public IActionResult GenerateToken([FromBody]LoggingBuilderExtensions Login)
//         {
//             if(Login != null && Login.login != null && Login.passwd != null)
//             {
//                 var user = model.Client.getLogin(Login);
//                 if(user != null )
//                 {
//                     var claims = new[]
//                     {
//                         new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
//                         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                         new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                         new Claim("UserId", user.getId().ToString()),
//                         new Claim("UserName", user.getClient()),
//                         new Claim("Email", user.getEmail())
//                     };

//                     var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

//                     var SignIn = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

//                     var Token = new JwtSecurityToken(
//                         _configuration["Jwt:Issuer"],
//                         _configuration["Jwt:Audience"],
//                         claims,
//                         expires: DateTime.UtcNow.AddMinutes(10),
//                         signingCredentials: SignIn);

//                     return Ok(new JwtSecurityTokenHandler().WriteToken(Token));
//                 }
//                 else
//                 {
//                     return BadRequest("Invalid credentials");
//                 }
                
//             }
//             else
//             {
//                 return BadRequest();
//             }
//         }
//     }
// }