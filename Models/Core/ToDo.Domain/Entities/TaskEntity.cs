using DDD.Primitives;
using ToDo.Domain.Exceptions;

namespace ToDo.Domain.Entities;

public class TaskEntity
{
    public TaskEntity(Guid id, string title, string description, long? deadline, long createdAt)
    {
        Id = id;
        Title = title;
        Description = description;
        Deadline = deadline;
        CreatedAt = createdAt;
    }

    public static TaskEntity Create(string title, string description, long? deadline, long createdAt)
    {
        Guid id = Guid.NewGuid();
        return new TaskEntity(id, title, description, deadline, createdAt);
    }
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long? Deadline { get; set; }
    public long CreatedAt { get; set; }

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