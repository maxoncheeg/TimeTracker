using TimeTracker.Domain.CQRS.Enums;

namespace TimeTracker.Domain.CQRS.Responses.Projects;

public class ProjectResponse
{
    public int ProjectId { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public ProjectStatus Status { get; set; }
}