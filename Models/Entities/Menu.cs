using System.ComponentModel.DataAnnotations;

public class Menu
{
    [Key]
    public int ItemID { get; set; }

    [Required(ErrorMessage = "Item Name is required.")]
    public string Item { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Image URL is required.")]
    [Url(ErrorMessage = "Please enter a valid URL.")]
    public string Image { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    [RegularExpression("Veg|Non-Veg", ErrorMessage = "Category must be 'Veg' or 'Non-Veg'.")]
    public string Category { get; set; }

    public bool IsAvailable { get; set; } = true;
}

