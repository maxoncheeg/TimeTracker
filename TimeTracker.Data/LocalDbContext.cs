using Microsoft.EntityFrameworkCore;
using TimeTracker.Data.Entities;
using TaskEntity = TimeTracker.Data.Entities.Task;

namespace TimeTracker.Data;

public class LocalDbContext : DbContext
{
    public bool Initialized { get; private set; } = false;
    public string FilePath { get; private set; }
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<ProjectActivity> ProjectActivities { get; set; }
    public DbSet<TaskActivity> TaskActivities { get; set; }
    public DbSet<Plan> Plans { get; set; }

    public LocalDbContext()
    {
        FilePath = Path.Combine("../", "migration.db3");
        Initialize();
    }
    
    public LocalDbContext(string fileName)
    {
        FilePath = Path.Combine("../" + fileName);
        Initialize();
    }

    public void Initialize()
    {
        if (Initialized) return;
        Initialized = true;
        
        SQLitePCL.Batteries_V2.Init();

        //Database.EnsureDeleted();
        Database.Migrate();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite($"Filename={FilePath}");
    }
}