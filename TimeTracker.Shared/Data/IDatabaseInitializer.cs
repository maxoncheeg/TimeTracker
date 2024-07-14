namespace TimeTracker.Shared.Data;

public interface IDatabaseInitializer : IDisposable
{
    public string ConnectionString { get; }
}