using System.ComponentModel.DataAnnotations.Schema;
using TimeTracker.Data.Entities.Abstract;

namespace TimeTracker.Data.Entities;

public class TaskActivity : AbstractActivity
{
    [ForeignKey(nameof(Task))]
    public int TaskId { get; set; }
    public required Task Task { get; set; }
}