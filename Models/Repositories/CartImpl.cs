using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CartImpl : ICart
{
    private readonly ApplicationDbContext _context;

    public CartImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public async Task<Cart> AddToCart(int userId, int itemId, int quantity)
    {
        // Retrieve the user's cart (create if not found)
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserID = userId,
                CartItems = new List<CartItem>()
            };
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        
        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ItemID == itemId);
        if (cartItem != null)
        {
           
            cartItem.Quantity += quantity;
        }
        else
        {
            
            cart.CartItems.Add(new CartItem
            {
                ItemID = itemId,
                Quantity = quantity
            });
        }

        await _context.SaveChangesAsync();
        return cart;
    }

   
    public async Task<Cart> RemoveFromCart(int userId, int itemId)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserID == userId);

        if (cart != null)
        {
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ItemID == itemId);
            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        return cart;
    }

    
    public async Task<List<CartItem>> GetCartItems(int userId)
    {
        var cart = await _context.Carts
            .Where(c => c.UserID == userId)
            .Include(c => c.CartItems) // Include CartItems
            .FirstOrDefaultAsync();

        return cart?.CartItems ?? new List<CartItem>();
    }

    
    public async Task<decimal> CalculateTotal(int userId)
    {
        var cartItems = await GetCartItems(userId);
        decimal totalCost = 0;

        foreach (var cartItem in cartItems)
        {
            
            var menuItem = await _context.Menus.FirstOrDefaultAsync(m => m.ItemID == cartItem.ItemID);
            if (menuItem != null)
            {
                totalCost += menuItem.Price * cartItem.Quantity;
            }
        }

        return totalCost;
    }
}
