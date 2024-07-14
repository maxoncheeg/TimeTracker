using Microsoft.EntityFrameworkCore;
using TimeTracker.Data;

namespace TimeTracker.Shared.Data;

public class LocalDatabaseInitializer : IDatabaseInitializer
{
    private readonly DbContext _context;
    
    public string ConnectionString { get; }

    public LocalDatabaseInitializer(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

        ConnectionString = connectionString;
        _context = new LocalDbContext(connectionString);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}