using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICart
{
    Task<Cart> AddToCart(int userId, int itemId, int quantity);
    Task<Cart> RemoveFromCart(int userId, int itemId);
    Task<List<CartItem>> GetCartItems(int userId);
    Task<decimal> CalculateTotal(int userId);
}

