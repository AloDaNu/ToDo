using OperationResults;

namespace ToDo.Application.Abstractions.Features;

public interface ITaskUpdateFeature
{
    Result Update(Guid taskId, string title, string description, long? deadline);
}