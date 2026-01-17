using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Dtos;
using ToDo.View.Abstractions.Delegates;

namespace ToDo.View.Abstractions.Views
{
    public interface ITaskView : IView
    {
        event EventHandler AddClickedEvent;

        event TaskDeletedDelegate TaskDeletedEvent;

        event TaskEditClickedDelegate TaskEditClickedEvent;

        void LoadTasks(IReadOnlyCollection<TaskDto> tasks);
    }
}
