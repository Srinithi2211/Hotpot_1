using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDashboardRestaurant
{
    Task<bool> AddMenuItem(Menu menu);
    Task<bool> UpdateMenuItem(Menu menu);
    Task<bool> DeleteMenuItem(int itemId);
    Task<bool> MarkItemOutOfStock(int itemId);
    Task<List<Menu>> GetMenuByCategory(string category);
    Task<List<Order>> GetOrderStatuses();
    Task<List<Order>> GetOrderHistory();
}
