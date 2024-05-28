using Microservices.CartServices.Models;

namespace Microservices.CartServices.Service_Layer
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAllItemsAsync(string Username);
        Task<bool> AddOrUpdateItemAsync(Cart cartItem);
        Task<bool> RemoveItemAsync(string Username, int id);
        Task<bool> RemoveAsync(string Username);
    }

}
