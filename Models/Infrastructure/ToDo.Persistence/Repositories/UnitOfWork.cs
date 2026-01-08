using ToDo.Application.Abstractions.Repositories;
using ToDo.Persistence.Contexts;

namespace ToDo.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}