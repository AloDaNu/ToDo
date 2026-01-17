using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Repositories;

public interface ITaskRepository
{
    IReadOnlyCollection<TaskEntity> Get();
    TaskEntity? Get(Guid id);
    void Add(TaskEntity task);
    void Delete(TaskEntity task);
}