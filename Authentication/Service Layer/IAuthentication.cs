using Microservices.Authentication.Models;

namespace Authentication.Service_Layer
{
    public interface IAuthentication
    {
        public string GenerateJWTWebToken(string username, string role);

    }
}
