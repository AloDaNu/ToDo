using OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Abstractions.Features
{
    public interface ITaskCompleteFeature
    {
        Result Complete(Guid taskId, bool completed);
    }
}
