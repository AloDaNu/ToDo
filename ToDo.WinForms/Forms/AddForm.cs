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

namespace ToDo.WinForms.Forms
{
    public partial class AddForm : Form
    {
        private readonly IServiceScope _scope;
        private readonly IServiceProvider _serviceProvider;
        public AddForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _scope = serviceProvider.CreateScope();
            _serviceProvider = _scope.ServiceProvider;

            addButton.Click += OnAddClicked;
        }

        private void OnAddClicked(object? sender, EventArgs e)
        {
            ITaskCreateFeature taskCreateFeature = _serviceProvider.GetRequiredService<ITaskCreateFeature>();

            string title = titleInput.Text;
            string description = descriptionInput.Text;
            long? deadline = ((DateTimeOffset)deadlineInput.Value).ToUnixTimeSeconds();

            Result createResult = taskCreateFeature.Create(title, description, deadline);
            if (createResult.IsFailure)
            {
                MessageBox.Show(createResult.Error.Message, "Create error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Creation completed", "Create error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _scope.Dispose();
            base.OnClosing(e);
        }
    }
}
