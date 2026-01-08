namespace ToDo.Application.Abstractions.Services;

public interface ITaskDeletionService
{
    void Delete(Guid taskId);
}