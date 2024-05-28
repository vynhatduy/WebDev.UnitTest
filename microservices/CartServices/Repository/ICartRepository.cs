using Microservices.CartServices.Models;

namespace Microservices.CartServices.Repository
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllItemsAsync(string Username);
        Task<Cart> GetById(string Username,int id);
        Task<bool> AddItemAsync(Cart cartItem);
        Task<bool> UpdateItemAsync(Cart cartItem);
        Task<bool> RemoveItemAsync(string Username, int id);
        Task<bool> RemoveAsync(string Username);
    }
}
