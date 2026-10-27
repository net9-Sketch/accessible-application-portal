namespace Accessible_Application_Portal.Models;

public sealed class Application
{
    public int ApplicationId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ApplicantName => FirstName + " " + LastName;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string ApplicationType { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public DateOnly SubmittedDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
