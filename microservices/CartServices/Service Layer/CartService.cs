using Microservices.CartServices.Models;
using Microservices.CartServices.Repository;

namespace Microservices.CartServices.Service_Layer
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<Cart>> GetAllItemsAsync(string Username)
        {
            return await _cartRepository.GetAllItemsAsync(Username);
        }

        public async Task<bool> AddOrUpdateItemAsync(Cart cartItem)
        {
            try
            {
                var existingCartItem = await _cartRepository.GetById(cartItem.Username, cartItem.ProductId);

                if (existingCartItem != null)
                {
                    var price = (double)cartItem.Price / cartItem.Quantity;
                    existingCartItem.Quantity = cartItem.Quantity;
                    existingCartItem.Price = (double)price * existingCartItem.Quantity;
                    await _cartRepository.UpdateItemAsync(existingCartItem);
                }
                else
                {
                    await _cartRepository.AddItemAsync(cartItem);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveItemAsync(string Username, int id)
        {
            var result= await _cartRepository.RemoveItemAsync(Username,id);
            if (result)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> RemoveAsync(string Username)
        {
            var result= await _cartRepository.RemoveAsync(Username);
            if (result)
            {
                return true;
            }
            return false;
        }
    }
}
