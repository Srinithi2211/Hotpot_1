using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMenu
{
    Task<Menu> AddItem(Menu item);
    Task<Menu> DeleteItem(int itemId);
    Task<List<Menu>> GetAllItems();
    Task<List<Menu>> FilterItems(string category,  decimal? price);
}
