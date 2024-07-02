namespace TimeTracker.Data.Entities.Abstract;

public abstract class AbstractActivity : AbstractEntity
{
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeOnly Time { get; set; }
}