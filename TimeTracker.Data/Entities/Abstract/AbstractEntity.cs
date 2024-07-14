using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Data.Entities.Abstract;

public abstract class AbstractEntity
{
    [Key] public int Id { get; set; }
}