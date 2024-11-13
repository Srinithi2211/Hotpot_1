using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class DashboardUserImpl : IDashboardUser
{
    private readonly ApplicationDbContext _context;

    public DashboardUserImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get user information by UserID
    public async Task<DashboardUser> GetUserInfo(int userId)
    {
        return await _context.DashboardUsers.FindAsync(userId);
    }

    // Update the address for a specific user
    public async Task<bool> UpdateAddress(int userId, string newAddress)
    {
        var user = await _context.DashboardUsers.FindAsync(userId);
        if (user != null)
        {
            user.Address = newAddress;
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    // Get menu items by category
    public async Task<IEnumerable<Menu>> GetMenuByCategory(string category)
    {
        return await _context.Menus
            .Where(m => m.Category == category)
            .ToListAsync();
    }

    // Search for menu items based on a search term
    public async Task<IEnumerable<Menu>> SearchMenuItems(string searchTerm)
    {
        return await _context.Menus
            .Where(m => m.Item.Contains(searchTerm) || m.Description.Contains(searchTerm))
            .ToListAsync();
    }

    // Validate the contact number
    public bool ValidateContactNumber(string contactNumber)
    {
        return Regex.IsMatch(contactNumber, @"^[0-9]{10}$");
    }

    // Validate the email address
    public bool ValidateEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}
