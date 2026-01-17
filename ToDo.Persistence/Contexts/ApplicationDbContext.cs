using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Persistence.Configurations;

namespace ToDo.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
    }
    
    public DbSet<TaskEntity> Tasks { get; private set; }
}