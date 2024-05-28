using Microservices.CartServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.CartServices.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MyDbContext _dbContext;

        public CartRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cart>> GetAllItemsAsync(string Username)
        {
            return await _dbContext.Carts.Where(x=>x.Username==Username).ToListAsync();
        }
        public async Task<Cart> GetById(string Username,int id)
        {
            return await _dbContext.Carts.FirstOrDefaultAsync(x => x.Username == Username&&x.ProductId==id);
        }

        public async Task<bool> AddItemAsync(Cart cartItem)
        {
            try
            {
                _dbContext.Carts.Add(cartItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateItemAsync(Cart cartItem)
        {
            try
            {
                _dbContext.Entry(cartItem).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveItemAsync(string Username,int id)
        {
            var cartItem = await _dbContext.Carts.FirstOrDefaultAsync(x=>x.Username==Username&&x.ProductId==id);
            if (cartItem != null)
            {
                _dbContext.Carts.Remove(cartItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> RemoveAsync(string Username)
        {
            try
            {
                var cartItem = await _dbContext.Carts.Where(x => x.Username == Username).ToListAsync();
                if (cartItem != null)
                {
                    _dbContext.Carts.RemoveRange(cartItem);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
