namespace Accessible_Application_Portal.Models;

public static class ApplicationStore
{
    private static readonly object SyncRoot = new();
    private static int _nextId = 1009;

    private static readonly List<Application> Applications =
    [
        new() { ApplicationId = 1001, FirstName = "Jane", LastName = "Anderson", Email = "jane.anderson@example.test", PhoneNumber = "555-0101", ApplicationType = "Initial Application", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 1, 14), Status = "In Review" },
        new() { ApplicationId = 1002, FirstName = "Malik", LastName = "Brooks", Email = "malik.brooks@example.test", PhoneNumber = "555-0102", ApplicationType = "Renewal", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 2, 2), Status = "Received" },
        new() { ApplicationId = 1003, FirstName = "Sofia", LastName = "Chen", Email = "sofia.chen@example.test", PhoneNumber = "555-0103", ApplicationType = "Information Update", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 2, 19), Status = "Approved" },
        new() { ApplicationId = 1004, FirstName = "Elena", LastName = "Cruz", Email = "elena.cruz@example.test", PhoneNumber = "555-0104", ApplicationType = "Initial Application", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 3, 3), Status = "Additional Information Requested" },
        new() { ApplicationId = 1005, FirstName = "Noah", LastName = "Patel", Email = "noah.patel@example.test", PhoneNumber = "555-0105", ApplicationType = "Renewal", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 4, 21), Status = "In Review" },
        new() { ApplicationId = 1006, FirstName = "Grace", LastName = "Kim", Email = "grace.kim@example.test", PhoneNumber = "555-0106", ApplicationType = "Information Update", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 5, 7), Status = "Closed" },
        new() { ApplicationId = 1007, FirstName = "Liam", LastName = "Thompson", Email = "liam.thompson@example.test", PhoneNumber = "555-0107", ApplicationType = "Initial Application", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 6, 15), Status = "Received" },
        new() { ApplicationId = 1008, FirstName = "Aisha", LastName = "Williams", Email = "aisha.williams@example.test", PhoneNumber = "555-0108", ApplicationType = "Renewal", Comments = "Sample record for the application list.", SubmittedDate = new DateOnly(2025, 7, 29), Status = "Approved" }
    ];

    public static IReadOnlyList<Application> GetAll()
    {
        lock (SyncRoot)
        {
            return Applications.ToArray();
        }
    }

    public static Application? FindById(int id)
    {
        lock (SyncRoot)
        {
            return Applications.FirstOrDefault(application => application.ApplicationId == id);
        }
    }

    public static Application Add(Application application)
    {
        lock (SyncRoot)
        {
            application.ApplicationId = _nextId++;
            Applications.Add(application);
            return application;
        }
    }
}
