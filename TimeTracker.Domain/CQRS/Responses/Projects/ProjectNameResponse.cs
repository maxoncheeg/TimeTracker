namespace TimeTracker.Domain.CQRS.Responses.Projects;

public class ProjectNameResponse
{
    public int ProjectId { get; set; }
    public string Name { get; set; } = String.Empty;
}