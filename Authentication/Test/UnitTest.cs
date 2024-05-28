using Authentication.Service_Layer;
using Microservices.Authentication.Controllers;
using Microservices.Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Authentication.Test
{
    [TestClass]
    public class UnitTest
    {
        IConfiguration config;
        IAuthentication authen;
        Authen service;
        AuthenticationController controller;
        Mock<IHttpClientFactory> mock;

        [TestInitialize]
        public void Init()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Secret", "BaiTapLonMonMauThietKeVyNhatDuyToVanSinhNguyenThiThuyLinh"},
                {"Jwt:Issuer", "BackendWithAsp.netCoreWebApiContainInDockerCompose"},
                {"Jwt:Audience", "FontEndWithReactJsContainInDockerCompose"}
            };
            config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            // Khởi tạo mock cho IHttpClientFactory
            mock = new Mock<IHttpClientFactory>();
            var httpClientMock = new Mock<HttpClient>();
            mock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClientMock.Object);
            //controller = new AuthenticationController(config, mock.Object, authen);
            controller = new AuthenticationController(config,mock.Object,authen);
            service = new Authen(config);
        }

        [TestMethod]
        public void TestGeneratorJWT()
        {
            var username = "Admin";
            var rolename = "admin";
            var token = service.GenerateJWTWebToken(username, rolename);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public async Task TestLogin()
        {
            var model = new LoginModel
            {
                Username = "Admin",
                Password = "admin"
            };
            var result = await controller.Login(model);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Phải trả về mã trạng thái HTTP 200 OK");
            var okResult = (OkObjectResult)result;
            if (okResult.Value != null)
            {
                dynamic data = okResult.Value;
                var token = data.token;
                Assert.IsNotNull(token, "Không có token trả về");
            }
        }
    }
}
