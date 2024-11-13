using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DashboardRestaurantImpl : IDashboardRestaurant
{
    private readonly ApplicationDbContext _context;

    public DashboardRestaurantImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    // Add a new menu item
    public async Task<bool> AddMenuItem(Menu menu)
    {
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
        return true;
    }

    // Update an existing menu item
    public async Task<bool> UpdateMenuItem(Menu menu)
    {
        var existingMenu = await _context.Menus.FindAsync(menu.ItemID);
        if (existingMenu == null) return false;

        existingMenu.Item = menu.Item;
        existingMenu.Description = menu.Description;
        existingMenu.Price = menu.Price;
        existingMenu.Category = menu.Category;
        existingMenu.Image = menu.Image;

        await _context.SaveChangesAsync();
        return true;
    }

    // Delete a menu item
    public async Task<bool> DeleteMenuItem(int itemId)
    {
        var menu = await _context.Menus.FindAsync(itemId);
        if (menu == null) return false;

        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
        return true;
    }

    // Mark a menu item as out of stock
    public async Task<bool> MarkItemOutOfStock(int itemId)
    {
        var menu = await _context.Menus.FindAsync(itemId);
        if (menu == null) return false;

        menu.IsAvailable = false;
        await _context.SaveChangesAsync();
        return true;
    }

    // Get menu items by category
    public async Task<List<Menu>> GetMenuByCategory(string category)
    {
        return await _context.Menus.Where(m => m.Category == category).ToListAsync();
    }

    // Get the status of all current orders
    public async Task<List<Order>> GetOrderStatuses()
    {
        return await _context.Orders.Where(o => o.Status != "Completed").ToListAsync();
    }

    // Get the history of all completed orders
    public async Task<List<Order>> GetOrderHistory()
    {
        return await _context.Orders.Where(o => o.Status == "Completed").ToListAsync();
    }
}
