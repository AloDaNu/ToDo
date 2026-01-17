using OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Abstractions.Services;
using ToDo.Application.Services;

namespace ToDo.Application.Features
{
    public class TaskCompleteFeature : ITaskCompleteFeature
    {
        private readonly ITaskCompletionService _taskCompletionService;

        public TaskCompleteFeature(ITaskCompletionService taskCompletionService)
        {
            _taskCompletionService = taskCompletionService;
        }
        public Result Complete(Guid taskId, bool completed)
        {
            try
            {
                _taskCompletionService.Complete(taskId, completed);
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
}
