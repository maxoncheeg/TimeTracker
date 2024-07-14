using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Entities.Abstract;

public abstract class AbstractActivity : AbstractEntity
{
    [MaxLength(128), Required] public string Description { get; set; } = string.Empty;
    [Required] public DateTime Date { get; set; }
    [Required] public TimeOnly Time { get; set; }
}