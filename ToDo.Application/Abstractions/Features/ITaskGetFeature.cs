using OperationResults;
using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Features;

public interface ITaskGetFeature
{
    Result<IReadOnlyCollection<TaskDto>> Get();
}