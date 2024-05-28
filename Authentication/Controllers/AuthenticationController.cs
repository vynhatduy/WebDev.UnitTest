using Authentication.Service_Layer;
using Microservices.Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservices.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication service;
        private readonly IConfiguration config;
        private readonly HttpClient _userService;

        public AuthenticationController(IConfiguration config, IHttpClientFactory factory, IAuthentication service)
        {
            this.service = service;
            this.config = config;
            _userService = factory.CreateClient();
            _userService.BaseAddress = new System.Uri("http://localhost:8301/api/");

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                var response = await _userService.PostAsync("User/login", content);

                // Kiểm tra response không null trước khi sử dụng
                if (response != null && response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var userData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserRespone>(responseContent);
                    var tokenString = service.GenerateJWTWebToken(userData.Username, userData.Role);

                    if (string.IsNullOrEmpty(tokenString))
                    {
                        return Unauthorized("Không thể tạo chuỗi xác thực người dùng");
                    }

                    return Ok(new { token = tokenString });
                }
                else
                {
                    return Unauthorized("Tài khoản hoặc mật khẩu không đúng");
                }
            }
            catch (Exception ex)
            {
                // Log exception và trả về BadRequest với thông báo lỗi
                Console.WriteLine(ex.ToString());
                return BadRequest("Không thể tạo chuỗi đến userService: " + ex.Message);
            }
        }
    }
}

