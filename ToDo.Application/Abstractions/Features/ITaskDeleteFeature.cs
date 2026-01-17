using OperationResults;

namespace ToDo.Application.Abstractions.Features;

public interface ITaskDeleteFeature
{
    Result Delete(Guid taskId);
}