using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Service_Layer
{
    public class Authen:IAuthentication
    {
        private readonly IConfiguration config;

        public Authen(IConfiguration config)
        {
            this.config = config;
        }
        public string GenerateJWTWebToken(string username, string role)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Jwt:Secret"]));
                var cendentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(config["Jwt:Issuer"],
                    config["Jwt:Issuer"],
                    new Claim[]
                    {
                    new Claim(ClaimTypes.Name,username),
                    new Claim(ClaimTypes.Role,role)
                    },
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: cendentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
