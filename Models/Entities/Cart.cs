using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Cart
{
    [Key]
    public int CartID { get; set; }

    [Required]
    public int UserID { get; set; }  

    public List<CartItem> CartItems { get; set; }

    public decimal TotalCost { get; set; }
}

public class CartItem
{
    [Key]
    public int CartItemID { get; set; }

    [Required]
    public int ItemID { get; set; }  

    public int Quantity { get; set; }
}
