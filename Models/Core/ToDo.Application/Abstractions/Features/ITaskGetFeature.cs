using OperationResults;
using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Features;

public interface ITaskGetFeature
{
    Result<IReadOnlyCollection<TaskEntity>> Get();
}