using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class MenuImpl : IMenu
{
    private readonly ApplicationDbContext _context;

    public MenuImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Menu> AddItem(Menu item)
    {
        _context.Menus.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Menu> DeleteItem(int itemId)
    {
        var item = await _context.Menus.FindAsync(itemId);
        if (item != null)
        {
            _context.Menus.Remove(item);
            await _context.SaveChangesAsync();
        }
        return item;
    }

    public async Task<List<Menu>> GetAllItems()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task<List<Menu>> FilterItems(string category,  decimal? price)
    {
        var query = _context.Menus.AsQueryable();

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(x => x.Category == category);
        }

       

        if (price.HasValue)
        {
            query = query.Where(x => x.Price <= price.Value);
        }

        return await query.ToListAsync(); 
    }
}
