using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Exceptions;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services;

public class TaskDeletionService : ITaskDeletionService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TaskDeletionService(ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }
    
    public void Delete(Guid taskId)
    {
        TaskEntity? taskEntity = _taskRepository.Get(taskId);
        if (taskEntity == null)
            throw new NotFoundApplicationException($"The task with id ({taskId}) was not found.");
        
        _taskRepository.Delete(taskEntity);
        _unitOfWork.Save();
    }
}