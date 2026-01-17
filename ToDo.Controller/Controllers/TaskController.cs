using OperationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Dtos;
using ToDo.View.Abstractions.Views;

namespace ToDo.Controller.Controllers
{
    public class TaskController
    {
        private readonly ITaskGetFeature _taskGetFeature;
        private readonly ITaskView _view;

        public TaskController(ITaskGetFeature taskGetFeature,
                              ITaskView view) 
        {
            _taskGetFeature = taskGetFeature;
            _view = view;

            _view.OpenEvent += OnOpen;
        }

        private void OnOpen(object? sender, EventArgs e)
        {
            Result<IReadOnlyCollection<TaskDto>> tasksResult = _taskGetFeature.Get();

            if (tasksResult.IsFailure)
            {
                _view.ShowError(tasksResult.Error.Message);
                return;
            }

            _view.LoadTasks(tasksResult.Content);
        }

    }
}
