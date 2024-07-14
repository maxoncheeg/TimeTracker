using System.ComponentModel.DataAnnotations;
using TimeTracker.Data.Entities.Abstract;
using TimeTracker.Domain.CQRS.Enums;

namespace TimeTracker.Data.Entities;

public class Project : AbstractEntity
{
    [MaxLength(64), Required] public string Name { get; set; } = string.Empty;
    [MaxLength(256), Required] public string? Description { get; set; } = string.Empty;
    [Required] public ProjectStatus Status { get; set; }
    [Required] public DateTime DateCreated { get; set; }
    [Required] public DateTime DateUpdated { get; set; }

    public List<Task> Tasks { get; set; } = [];
    public List<ProjectActivity> Activities { get; set; } = [];
    public List<Plan> Plans { get; set; } = [];
}