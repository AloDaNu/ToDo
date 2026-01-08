using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services;

public class TaskQueryService : ITaskQueryService
{
    private readonly ITaskRepository _taskRepository;

    public TaskQueryService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public IReadOnlyCollection<TaskEntity> Get()
    {
        return _taskRepository.Get();
    }
}