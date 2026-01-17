using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Exceptions;
using ToDo.Domain.Entities;

namespace ToDo.Application.Services
{
    public class TaskCompletionService : ITaskCompletionService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskCompletionService(ITaskRepository taskRepository, IUnitOfWork unitOfWork) 
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
        }

        public void Complete(Guid taskId, bool completed)
        {
            TaskEntity? taskEntity = _taskRepository.Get(taskId);
            if (taskEntity == null)
                throw new NotFoundApplicationException($"The task with id ({taskId}) was not found.");

            taskEntity.SetCompleted(completed);
            _unitOfWork.Save();
        }
    }
}
