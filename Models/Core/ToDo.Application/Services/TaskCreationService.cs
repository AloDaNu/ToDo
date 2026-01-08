using ToDo.Application.Abstractions.Factories;
using ToDo.Application.Abstractions.Providers;
using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services;

public class TaskCreationService : ITaskCreationService
{
    private readonly ITaskFactory _taskFactory;

    private readonly ITaskRepository _taskRepository;
    
    private readonly IUnitOfWork _unitOfWork;
    
    public TaskCreationService(ITaskFactory taskFactory, ITaskRepository taskRepository, IUnitOfWork unitOfWork)
    {
        _taskFactory = taskFactory;
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }
    
    public void Create(string title, string description, long? deadline)
    {
        TaskEntity newTask = _taskFactory.Create(title, description, deadline);
         
        _taskRepository.Add(newTask);
        _unitOfWork.Save();
    }
}