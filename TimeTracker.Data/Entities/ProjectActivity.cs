using System.ComponentModel.DataAnnotations.Schema;
using TimeTracker.Data.Entities.Abstract;

namespace TimeTracker.Data.Entities;

public class ProjectActivity : AbstractActivity
{
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}