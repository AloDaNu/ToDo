using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services;

public class TaskQueryService : ITaskQueryService
{
    private readonly ITaskRepository _taskRepository;

    public TaskQueryService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public IReadOnlyCollection<TaskDto> Get()
    {
        IReadOnlyCollection<TaskEntity> task = _taskRepository.Get();

        return task.Select(x=>new TaskDto(x.Id, x.Title, x.Description, x.Deadline,
            x.Completed, x.CreatedAt)).ToArray();
    }
}