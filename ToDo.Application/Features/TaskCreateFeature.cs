using OperationResults;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Repositories;
using ToDo.Application.Abstractions.Services;

namespace ToDo.Application.Features;

public class TaskCreateFeature : ITaskCreateFeature
{
    private readonly ITaskCreationService _taskCreationService;

    public TaskCreateFeature(ITaskCreationService taskCreationService)
    {
        _taskCreationService = taskCreationService;
    }

    public Result Create(string title, string description, long? deadline)
    {
        try
        {
            _taskCreationService.Create(title, description, deadline);
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