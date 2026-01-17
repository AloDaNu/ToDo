using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Exceptions;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services;

public class TaskUpdateService : ITaskUpdateService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TaskUpdateService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }
    public void Update(Guid taskId, string name, string description, long? deadline)
    {
        TaskEntity? taskEntity = _taskRepository.Get(taskId);
        if (taskEntity == null)
            throw new NotFoundApplicationException($"The task with id ({taskId}) was not found.");
        
        taskEntity.ChangeTitle(name);
        taskEntity.ChangeDescription(description);
        taskEntity.ChangeDeadline(deadline);
        _unitOfWork.Save();
    }
}