using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Services;

public interface ITaskUpdateService
{
    void Update(Guid taskId, string name, string description, long? deadline);
}