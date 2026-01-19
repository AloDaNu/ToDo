using Microsoft.Extensions.DependencyInjection;
using OperationResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDo.Application.Abstractions.Features;
using static System.Formats.Asn1.AsnWriter;

namespace ToDo.WinForms.Forms
{
    public partial class EditForm : Form
    {
        private readonly IServiceScope _scope;
        private readonly IServiceProvider _serviceProvider;
        private Guid _taskId;

        public EditForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _scope = serviceProvider.CreateScope();
            _serviceProvider = _scope.ServiceProvider;

            saveButton.Click += OnSaveClicked;
        }

        public void SetTask(Guid taskId)
        {
            _taskId = taskId;
            LoadTaskData();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_taskId != Guid.Empty)
            {
                LoadTaskData();
            }
        }

        private void LoadTaskData()
        {
            try
            {
                var taskGetFeature = _serviceProvider.GetRequiredService<ITaskGetFeature>();
                var result = taskGetFeature.Get();

                if (result.IsSuccess)
                {
                    var task = result.Content.FirstOrDefault(t => t.Id == _taskId);

                    if (task != null)
                    {
                        titleInput.Text = task.Title;
                        descriptionInput.Text = task.Description;

                        if (task.Deadline.HasValue)
                        {
                            deadlineInput.Value = DateTimeOffset.FromUnixTimeSeconds(task.Deadline.Value).LocalDateTime;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Task not found", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load tasks", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }


        private void OnSaveClicked(object? sender, EventArgs e)
        {
            var taskUpdateFeature = _serviceProvider.GetRequiredService<ITaskUpdateFeature>();

            string title = titleInput.Text;
            string description = descriptionInput.Text;
            long? deadline = ((DateTimeOffset)deadlineInput.Value).ToUnixTimeSeconds();

            var updateResult = taskUpdateFeature.Update(_taskId, title, description, deadline);

            if (updateResult.IsFailure)
            {
                MessageBox.Show(updateResult.Error.Message, "Update Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Task updated successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
