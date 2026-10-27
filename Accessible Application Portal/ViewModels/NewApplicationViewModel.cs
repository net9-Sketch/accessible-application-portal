using System.ComponentModel.DataAnnotations;

namespace Accessible_Application_Portal.ViewModels;

public sealed class NewApplicationViewModel
{
    [Required(ErrorMessage = "Enter your first name.")]
    [StringLength(60, ErrorMessage = "First name must be 60 characters or fewer.")]
    [Display(Name = "First name (required)")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter your last name.")]
    [StringLength(60, ErrorMessage = "Last name must be 60 characters or fewer.")]
    [Display(Name = "Last name (required)")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter your email address.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [StringLength(254, ErrorMessage = "Email address must be 254 characters or fewer.")]
    [Display(Name = "Email (required)")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Enter your phone number.")]
    [Phone(ErrorMessage = "Enter a valid phone number.")]
    [StringLength(30, ErrorMessage = "Phone number must be 30 characters or fewer.")]
    [Display(Name = "Phone number (required)")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Select an application type.")]
    [Display(Name = "Application type (required)")]
    public string ApplicationType { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Comments must be 1,000 characters or fewer.")]
    [Display(Name = "Comments (optional)")]
    public string Comments { get; set; } = string.Empty;
}
