using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo.WinForms.Control
{
    public partial class TaskControl : UserControl
    {
        public TaskControl(Guid taskId,
                           bool isCompleted,
                           string title,
                           string description,
                           long? deadline,
                           Action<Guid> deleteCallBack,
                           Action<Guid> editCallBack,
                           Action<Guid, bool> completeCallBack)
        {
            InitializeComponent();

            taskIsCompletedCheckBox.Checked = isCompleted;
            taskGroup.Text = title;
            descriptionLabel.Text = description;
            deleteButton.Click += (s, e) => deleteCallBack?.Invoke(taskId);
            editButton.Click += (s, e) => editCallBack?.Invoke(taskId);
            taskIsCompletedCheckBox.CheckedChanged += (s, e) => completeCallBack?.Invoke(taskId, taskIsCompletedCheckBox.Checked);

            if (deadline.HasValue)
            {
                var deadlineDate = DateTimeOffset.FromUnixTimeSeconds(deadline.Value).LocalDateTime;

                deadlineStateLabel.Text = deadlineDate.ToString("dd.MM.yyyy HH:mm");

                if (deadlineDate < DateTime.Now)
                    deadlineStateLabel.ForeColor = Color.Red;
                else if ((deadlineDate - DateTime.Now).TotalDays <= 3)
                    deadlineStateLabel.ForeColor = Color.Orange;
                else
                    deadlineStateLabel.ForeColor = Color.Green;
            }
            else
            {
                deadlineStateLabel.Text = "No deadline";
                deadlineStateLabel.ForeColor = Color.Gray;

            }
        }
    }
}
