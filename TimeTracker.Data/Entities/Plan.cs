using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using TimeTracker.Data.Entities.Abstract;
using TimeTracker.Domain.CQRS.Enums;

namespace TimeTracker.Data.Entities;

public class Plan : AbstractEntity
{
    [Required, MaxLength(255)] public string Description { get; set; } = string.Empty;
    [Required] public DateTime DateCreated { get; set; }
    [Required] public DateTime DateScheduled { get; set; }
    [Required] public PlanStatus Status { get; set; }

    [ForeignKey(nameof(Project))] public int ProjectId { get; set; }
    public required Project Project { get; set; }
}