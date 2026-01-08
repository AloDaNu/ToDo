using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Factories;

public interface ITaskFactory
{
    TaskEntity Create(string title, string description, long? deadline);
}