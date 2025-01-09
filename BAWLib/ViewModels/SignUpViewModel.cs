using System.ComponentModel.DataAnnotations;

namespace BAWLib.ViewModels;

public class SignUpViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public string? Username { get; set; } = String.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
    public string? Password { get; set; }= String.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string? ConfirmPassword { get; set; }= String.Empty;
}