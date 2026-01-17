using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Abstractions.Services
{
    public interface ITaskCompletionService
    {
        void Complete(Guid taskId, bool completed);
    }
}
