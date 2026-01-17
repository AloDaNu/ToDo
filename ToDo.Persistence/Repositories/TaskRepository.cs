using ToDo.Application.Abstractions.Repositories;
using ToDo.Domain.Entities;
using ToDo.Persistence.Contexts;

namespace ToDo.Persistence.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;
    
        
    public TaskRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public IReadOnlyCollection<TaskEntity> Get()
    {
        return _context.Tasks.ToArray();
    }

    public TaskEntity? Get(Guid id)
    {
        return _context.Tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Add(TaskEntity task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void Delete(TaskEntity task)
    {
        _context.Tasks.Remove(task);
    }
}