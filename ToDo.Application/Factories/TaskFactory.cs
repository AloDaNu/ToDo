using ToDo.Application.Abstractions.Factories;
using ToDo.Application.Abstractions.Providers;
using ToDo.Domain.Entities;

namespace ToDo.Application.Factories;

public class TaskFactory : ITaskFactory
{
    private readonly ITimeProvider _timeProvider;

    public TaskFactory(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }
    
    public TaskEntity Create(string title, string description, long? deadline)
    {
        long createdAt = _timeProvider.NowUnix();
        return TaskEntity.Create(title, description, deadline, createdAt);
    }
}