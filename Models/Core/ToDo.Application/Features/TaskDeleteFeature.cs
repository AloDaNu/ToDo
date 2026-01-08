using OperationResults;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Services;

namespace ToDo.Application.Features;

public class TaskDeleteFeature : ITaskDeleteFeature
{
    private readonly ITaskDeletionService _taskDeletionService;

    public TaskDeleteFeature(ITaskDeletionService taskDeletionService)
    {
        _taskDeletionService = taskDeletionService;
    }
    
    public Result Delete(Guid taskId)
    {
        try
        {
            _taskDeletionService.Delete(taskId);
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