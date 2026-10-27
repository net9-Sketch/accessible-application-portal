using Accessible_Application_Portal.Models;
using Accessible_Application_Portal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Accessible_Application_Portal.Controllers;

public sealed class ApplicationsController : Controller
{
    private static readonly string[] ApplicationTypes =
    [
        "Initial Application",
        "Renewal",
        "Information Update"
    ];

    public IActionResult Index(string? searchTerm, string? status)
    {
        IEnumerable<Application> applications = ApplicationStore.GetAll();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.Trim();
            applications = applications.Where(application =>
                application.ApplicationId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                application.ApplicantName.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            applications = applications.Where(application =>
                string.Equals(application.Status, status, StringComparison.OrdinalIgnoreCase));
        }

        ViewBag.SearchTerm = searchTerm ?? string.Empty;
        ViewBag.SelectedStatus = status ?? string.Empty;
        ViewBag.Statuses = ApplicationStore.GetAll()
            .Select(application => application.Status)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(value => value)
            .ToArray();

        return View(applications.ToArray());
    }

    [HttpGet]
    public IActionResult Create()
    {
        PopulateApplicationTypes();
        return View(new NewApplicationViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(NewApplicationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            PopulateApplicationTypes();
            return View(model);
        }

        var application = ApplicationStore.Add(new Application
        {
            FirstName = model.FirstName.Trim(),
            LastName = model.LastName.Trim(),
            Email = model.Email.Trim(),
            PhoneNumber = model.PhoneNumber.Trim(),
            ApplicationType = model.ApplicationType,
            Comments = model.Comments.Trim(),
            SubmittedDate = DateOnly.FromDateTime(DateTime.Today),
            Status = "Received"
        });

        TempData["SuccessMessage"] = "Application " + application.ApplicationId + " was submitted successfully.";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var application = ApplicationStore.FindById(id);

        if (application is null)
        {
            return NotFound();
        }

        return View(application);
    }

    private void PopulateApplicationTypes()
    {
        ViewBag.ApplicationTypes = ApplicationTypes;
    }
}
