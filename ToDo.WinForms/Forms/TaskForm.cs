using Microsoft.Extensions.DependencyInjection;
using OperationResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Dtos;
using ToDo.View.Abstractions.Delegates;
using ToDo.View.Abstractions.Views;
using ToDo.WinForms.Control;

namespace ToDo.WinForms.Forms
{
    public partial class TaskForm : Form
    {
        private IServiceScope _scope;
        private IServiceProvider _serviceProvider;

        public TaskForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _scope = serviceProvider.CreateScope();
            _serviceProvider = _scope.ServiceProvider;

            refreshButton.Click += OnRefreshClicked;
            addButton.Click += OnAddClicked;
        }
        protected override void OnLoad(EventArgs e)
        {
            Result<IReadOnlyCollection<TaskDto>> tasksResult = GetTasks();
            LoadTasks(tasksResult.IsSuccess ? tasksResult.Content : Array.Empty<TaskDto>());
        }

        private Result<IReadOnlyCollection<TaskDto>> GetTasks()
        {
            using (_scope = _serviceProvider.CreateScope())
            {
                ITaskGetFeature taskGetFeature = _scope.ServiceProvider.GetRequiredService<ITaskGetFeature>();
                return taskGetFeature.Get();
            }
        }

        private void OnDeleteClicked(Guid taskId)
        {
            ITaskDeleteFeature deleteFeature = _serviceProvider.GetRequiredService<ITaskDeleteFeature>();

            Result deleteResult = deleteFeature.Delete(taskId);

            if (deleteResult.IsFailure)
                MessageBox.Show(deleteResult.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Deletion succed", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void OnCheckClicked(Guid taskId, bool isCompleted)
        {
            ITaskCompleteFeature completeFeature = _serviceProvider.GetRequiredService<ITaskCompleteFeature>();

            Result completeResult = completeFeature.Complete(taskId, isCompleted);

            if (completeResult.IsFailure)
                MessageBox.Show(completeResult.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Click succed", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnEditClicked(Guid taskId)
        {
            EditForm editForm = _serviceProvider.GetRequiredService<EditForm>();
            editForm.SetTask(taskId);
            editForm.ShowDialog();
        }

        private void OnViewLoaded(object? sender, EventArgs e)
        {
            Result<IReadOnlyCollection<TaskDto>> tasksResult = GetTasks();
            LoadTasks(tasksResult.IsSuccess? tasksResult.Content : Array.Empty<TaskDto>());
        }

        private void OnAddClicked(object? sender, EventArgs e)
        {
            AddForm addform = _serviceProvider.GetRequiredService<AddForm>();
            addform.ShowDialog();
        } 

        private void LoadTasks(IReadOnlyCollection<TaskDto> tasks)
        {
            taskListContainer.Controls.Clear();

            foreach (TaskDto task in tasks)
            {
                TaskControl taskControl = new TaskControl(task.Id,
                                                            task.Completed,
                                                            task.Title,
                                                            task.Description,
                                                            task.Deadline,
                                                            OnDeleteClicked,
                                                            OnEditClicked,
                                                            OnCheckClicked);

                taskListContainer.Controls.Add(taskControl);
            }
        }

        public void OnRefreshClicked(object? sender, EventArgs e)
        {
            Result<IReadOnlyCollection<TaskDto>> tasksResult = GetTasks();
            LoadTasks(tasksResult.IsSuccess ? tasksResult.Content : Array.Empty<TaskDto>());
        }
    }
}
