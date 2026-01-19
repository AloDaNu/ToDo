using Microsoft.Extensions.DependencyInjection;
using OperationResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Application.Abstractions.Features;
using ToDo.Application.Dtos;
using ToDo.View.Abstractions.Delegates;
using ToDo.View.Abstractions.Views;
using ToDo.WinForms.Control;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ToDo.WinForms.Forms
{
    public partial class TaskForm : Form
    {
        private IServiceScope _scope;
        private List<TaskDto> _allTasks = new();
        private IServiceProvider _serviceProvider;
        private string _currentSearch = "";

        public TaskForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _scope = serviceProvider.CreateScope();
            _serviceProvider = _scope.ServiceProvider;

            refreshButton.Click += OnRefreshClicked;
            addButton.Click += OnAddClicked;
            searchBox.TextChanged += OnSearchTextChanged;
        }
        protected override void OnLoad(EventArgs e)
        {
            Result<IReadOnlyCollection<TaskDto>> tasksResult = GetTasks();
            LoadAllTasks();
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

        private void OnSearchTextChanged(object? sender, EventArgs e)
        {
            _currentSearch = searchBox.Text.Trim();
            PerformSearch();
        }

        private void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(_currentSearch))
            {
                DisplayTasks(_allTasks);
            }
            else
            {
                var filteredTasks = FilterTasks(_allTasks, _currentSearch);
                DisplayTasks(filteredTasks);
            }
        }

        private void DisplayTasks(List<TaskDto> tasks)
        {
            taskListContainer.Controls.Clear();
            taskListContainer.SuspendLayout();

            foreach (TaskDto task in tasks)
            {
                TaskControl taskControl = new TaskControl(
                    task.Id,
                    task.Completed,
                    task.Title,
                    task.Description,
                    task.Deadline,
                    OnDeleteClicked,
                    OnEditClicked,
                    OnCheckClicked);

                taskListContainer.Controls.Add(taskControl);
            }

            taskListContainer.ResumeLayout(); 
        }

        private List<TaskDto> FilterTasks(List<TaskDto> tasks, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return tasks;

            var searchLower = searchText.ToLowerInvariant();

            return tasks.Where(task =>
                (task.Title?.Contains(searchLower, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (task.Description?.Contains(searchLower, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();
        }


        private void LoadAllTasks()
        {
            ITaskGetFeature taskGetFeature = _serviceProvider.GetRequiredService<ITaskGetFeature>();
            Result<IReadOnlyCollection<TaskDto>> taskResult = taskGetFeature.Get();

            if (taskResult.IsSuccess)
            {
                _allTasks = taskResult.Content.ToList();
            }
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
            LoadAllTasks();
        }

        public void OnRefreshClicked(object? sender, EventArgs e)
        {
            Result<IReadOnlyCollection<TaskDto>> tasksResult = GetTasks();
            LoadTasks(tasksResult.IsSuccess ? tasksResult.Content : Array.Empty<TaskDto>());
        }
    }
}
