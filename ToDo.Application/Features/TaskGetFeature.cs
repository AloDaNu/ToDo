using OperationResults;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Features;

public class TaskGetFeature : ITaskGetFeature
{
    private readonly ITaskQueryService _taskQueryService;

    public TaskGetFeature(ITaskQueryService taskQueryService)
    {
        _taskQueryService = taskQueryService;
    }
    
    public Result<IReadOnlyCollection<TaskDto>> Get()
    {
        try
        {
            IReadOnlyCollection<TaskDto> tasks = _taskQueryService.Get();
            
            return Result<IReadOnlyCollection<TaskDto>>.Success(tasks);
        }
        catch (ResultException exception)
        {
            return exception.GetResult<IReadOnlyCollection<TaskDto>>();
        }
        catch (Exception exception)
        {
            return Result<IReadOnlyCollection<TaskDto>>.Failure(new ResultError
                (ResultErrorTypes.InvalidOperation, exception.Message));
        }
    }
}