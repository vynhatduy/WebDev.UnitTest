using Microservices.UserServices.Controllers;
using Microservices.UserServices.Models;
using Microservices.UserServices.Repository;
using Microservices.UserServices.Services_layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserServices.Test
{
    [TestClass]
    public class UnitTest
    {
        MyDbContext dbContext;
        UserRepository userRepository;
        UserService userService;

        [TestInitialize]
        public void Init()
        {
            var otp = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "Default").Options;
            dbContext = new MyDbContext(otp);
            dbContext.Database.EnsureCreated();
            dbContext.SaveChanges();
            userRepository = new UserRepository(dbContext);
            userService = new UserService(userRepository);
        }
        [TestMethod]
        public async Task TestLogin()
        {
            LoginModel model = new LoginModel { Username = "admin", Password = "admin" };

            var result =await userRepository.ValidateUserCredentialsAsync(model.Username,model.Password);
            Assert.AreEqual(true,result);
        }

        [TestMethod]
        public async Task TestRegist() 
        {
            var model = new UserModel { Username = "demo", Password = "demo", Address = "demo", Name = "demo" };
            var result = await userRepository.AddUserAsync(model); 
            dbContext.SaveChangesAsync(); 
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task TestGetUserRole()
        {
            var result = await userRepository.GetUserRolesAsync("Admin");
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public  async Task TestUpdateUser()
        {
            UserModel model = new UserModel 
            {
             Address="123",
             Name="123",
             Password="admin",
             Username= "Admin"

            };
            var result = await userRepository.UpdateUserAsync(model);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public async Task TestDeleteUser()
        {
            var result = await userRepository.DeleteUserAsync("User");
            Assert.AreEqual(true,result);
        }
    }
}