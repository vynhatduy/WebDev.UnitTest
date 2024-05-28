using Microservices.CartServices.Models;
using Microservices.CartServices.Repository;
using Microservices.CartServices.Service_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartServices.Test
{
    [TestClass]
    public class UnitTest
    {
        MyDbContext dbContext;
        CartRepository repo;
        CartService services;

        [TestInitialize]
        public void Init()
        {
            var otp = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "Default").Options;
            dbContext = new MyDbContext(otp);
            dbContext.Database.EnsureCreated();
            dbContext.SaveChanges();
            repo = new CartRepository(dbContext);
            services = new CartService(repo);
        }
        [TestMethod]
        public async Task TestAddCart()
        {
            var model = new Cart
            {
                Username="demo",
                Name="demo",
                Img="demo",
                Price=12000,
                ProductId=1,
                Quantity=100
            };
            var result = await repo.AddItemAsync(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task TestAddOrUpdateCart()
        {
            var model = new Cart
            {
                Username = "demo",
                Name = "demo",
                Img = "demo",
                Price = 12000,
                ProductId = 1,
                Quantity = 1000
            };
            var result=await services.AddOrUpdateItemAsync(model);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task TestDeleteCart()
        {
            var result = await services.RemoveAsync("demo");
            Assert.IsTrue(result);
        }
    }
}
