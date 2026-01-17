using DDD.Primitives;
using ToDo.Domain.Exceptions;

namespace ToDo.Domain.Entities;

public class TaskEntity
{
    public TaskEntity(Guid id, string title, string description, long? deadline, long createdAt,
        bool completed)
    {
        Id = id;
        Title = title;
        Description = description;
        Deadline = deadline;
        CreatedAt = createdAt;
        Completed = completed;
    }

    public static TaskEntity Create(string title, string description, long? deadline, long createdAt)
    {
        Guid id = Guid.NewGuid();
        return new TaskEntity(id, !string.IsNullOrEmpty(title) ? title:throw new EmptyDomainException("The title can't be null or empty"), !string.IsNullOrEmpty(description)? description : throw new EmptyDomainException("The description can't be null or empty"), deadline, createdAt, false);
    }
    
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool Completed { get; private set; }
    public long? Deadline { get; private set; }
    public long CreatedAt { get; private set; }

    public void SetCompleted(bool isCompleted)
    {
        Completed = isCompleted;
    }
    public void ChangeTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new EmptyDomainException("The title cannot be null or empty.");
        Title = title;
    }

    public void ChangeDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new EmptyDomainException("The description cannot be null or empty.");
        Description = description;
    }

    public void ChangeDeadline(long? deadline)
    {
        Deadline = deadline;
    }
    
}