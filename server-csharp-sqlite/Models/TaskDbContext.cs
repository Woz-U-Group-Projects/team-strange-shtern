using Microsoft.EntityFrameworkCore;

namespace server_csharp_sqlite.Models
{
  public class TaskDbContext : DbContext
  {
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

    public DbSet<Task> Tasks { get; set; }

  }
}