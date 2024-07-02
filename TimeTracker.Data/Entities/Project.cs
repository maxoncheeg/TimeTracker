using TimeTracker.Data.Entities.Abstract;
using TimeTracker.Domain.CQRS.Enums;

namespace TimeTracker.Data.Entities;

public class Project : AbstractEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    
    public List<Task> Tasks { get; set; }
    public List<ProjectActivity> Activities { get; set; }
    public List<Plan> Plans { get; set; }
}