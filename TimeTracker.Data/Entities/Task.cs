using System.ComponentModel.DataAnnotations.Schema;
using TimeTracker.Data.Entities.Abstract;

namespace TimeTracker.Data.Entities;

public class Task : AbstractEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public List<TaskActivity> Activities { get; set; }
}