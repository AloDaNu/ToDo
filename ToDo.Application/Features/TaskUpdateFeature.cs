using OperationResults;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Services;

namespace ToDo.Application.Features;

public class TaskUpdateFeature : ITaskUpdateFeature
{
    private readonly ITaskUpdateService _taskUpdateService;

    public TaskUpdateFeature(ITaskUpdateService taskUpdateService)
    {
        _taskUpdateService = taskUpdateService;
    }
    
    public Result Update(Guid taskId, string title, string description, long? deadline)
    {
        try
        {
            _taskUpdateService.Update(taskId, title, description, deadline);
            return Result.Success();
        }
        catch (ResultException exception)
        {
            return exception.GetResult();
        }
        catch (Exception exception)
        {
            return Result.Failure(new ResultError(ResultErrorTypes.InvalidOperation, exception.Message));
        }
    }
}