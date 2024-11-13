using System;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int OrderID { get; set; }

    [Required]
    public int UserID { get; set; } 

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public decimal TotalAmount { get; set; }

    [Required]
    public string Status { get; set; } 

    [Required]
    public string PaymentMethod { get; set; } 

    public string ShippingAddress { get; set; } 

    public DateTime? EstimatedDeliveryTime { get; set; }
}
