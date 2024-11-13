using System.ComponentModel.DataAnnotations;

public class DashboardRestaurant
{
    [Key]
    public int RestaurantID { get; set; }

    [Required]
    public string RestaurantName { get; set; }

    public string Location { get; set; }

    [Required]
    [Phone]
    public string ContactNumber { get; set; }
}
