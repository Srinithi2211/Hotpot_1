using System.ComponentModel.DataAnnotations;

public class DashboardUser
{
    [Key]
    public int UserID { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [RegularExpression("Male|Female|Others", ErrorMessage = "Gender must be 'Male' 'Female' or 'Others'.")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Contact Number is required.")]
    [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please enter a valid mobile number.")]
    public string ContactNumber { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; }
}
