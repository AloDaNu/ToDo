using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Services;

public interface ITaskQueryService
{
    IReadOnlyCollection<TaskEntity> Get();
}