using Microsoft.Extensions.DependencyInjection;
using OperationResults;
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
        private readonly IServiceScope _scope;
        private readonly IServiceProvider _serviceProvider;

        public TaskForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            refreshButton.Click += OnRefreshClicked;
        }
        protected override void OnLoad(EventArgs e)
        {
            LoadTasks();
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

        private void OnAddClicked(object? sender, EventArgs e)
        {
            AddForm addform = _serviceProvider.GetRequiredService<AddForm>();
            addform.ShowDialog();
        }

        public void LoadTasks()
        {
            taskListContainer.Controls.Clear();

            ITaskGetFeature taskGetFeature = _serviceProvider.GetRequiredService<ITaskGetFeature>();

            Result<IReadOnlyCollection<TaskDto>> taskResult = taskGetFeature.Get();

            if (taskResult.IsFailure)
                return;

            foreach (TaskDto task in taskResult.Content)
            {
                TaskControl taskControl = new TaskControl(task.Id,
                                                          task.Completed,
                                                          task.Title,
                                                          task.Description,
                                                          task.Deadline,
                                                          OnDeleteClicked);

                taskListContainer.Controls.Add(taskControl);
            }
        }

        public void OnRefreshClicked(object? sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}
