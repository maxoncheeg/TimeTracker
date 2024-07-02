using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using TimeTracker.Data.Entities.Abstract;
using TimeTracker.Domain.CQRS.Enums;

namespace TimeTracker.Data.Entities;

public class Plan : AbstractEntity
{
    [NotNull, MaxLength(255)] public string Description { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public DateTime DateScheduled { get; set; }
    public PlanStatus Status { get; set; }
    
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    [NotNull]
    public required Project Project { get; set; }
}