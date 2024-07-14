using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeTracker.Data.Entities.Abstract;

namespace TimeTracker.Data.Entities;

public class Task : AbstractEntity
{
    [Required, MaxLength(64)] public string Name { get; set; } = string.Empty;
    [MaxLength(128)] public string Description { get; set; } = string.Empty;
    [Required] public TaskStatus Status { get; set; }
    [Required] public DateTime DateCreated { get; set; }
    [Required] public DateTime DateUpdated { get; set; }

    [ForeignKey(nameof(Project))] public int ProjectId { get; set; }
    public required Project Project { get; set; }

    public required List<TaskActivity> Activities { get; set; }
}