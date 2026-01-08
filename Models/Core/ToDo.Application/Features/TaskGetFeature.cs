using OperationResults;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Services;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features;

public class TaskGetFeature : ITaskGetFeature
{
    private readonly ITaskQueryService _taskQueryService;

    public TaskGetFeature(ITaskQueryService taskQueryService)
    {
        _taskQueryService = taskQueryService;
    }
    
    public Result<IReadOnlyCollection<TaskEntity>> Get()
    {
        try
        {
            IReadOnlyCollection<TaskEntity> tasks = _taskQueryService.Get();
            
            return Result<IReadOnlyCollection<TaskEntity>>.Success(tasks);
        }
        catch (ResultException exception)
        {
            return exception.GetResult<IReadOnlyCollection<TaskEntity>>();
        }
        catch (Exception exception)
        {
            return Result<IReadOnlyCollection<TaskEntity>>.Failure(new ResultError(ResultErrorTypes.InvalidOperation, exception.Message));
        }
    }
}