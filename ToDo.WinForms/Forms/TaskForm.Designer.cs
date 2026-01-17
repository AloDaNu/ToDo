namespace ToDo.WinForms.Forms
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolPanel = new Panel();
            addButton = new Button();
            taskListContainer = new FlowLayoutPanel();
            refreshButton = new Button();
            toolPanel.SuspendLayout();
            SuspendLayout();
            // 
            // toolPanel
            // 
            toolPanel.BackColor = SystemColors.GradientInactiveCaption;
            toolPanel.Controls.Add(refreshButton);
            toolPanel.Controls.Add(addButton);
            toolPanel.Dock = DockStyle.Bottom;
            toolPanel.Location = new Point(0, 335);
            toolPanel.Margin = new Padding(3, 2, 3, 2);
            toolPanel.Name = "toolPanel";
            toolPanel.Size = new Size(729, 98);
            toolPanel.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom;
            addButton.Location = new Point(327, 67);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(82, 22);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // taskListContainer
            // 
            taskListContainer.AutoScroll = true;
            taskListContainer.BackColor = SystemColors.Info;
            taskListContainer.Dock = DockStyle.Fill;
            taskListContainer.Location = new Point(0, 0);
            taskListContainer.Margin = new Padding(3, 2, 3, 2);
            taskListContainer.Name = "taskListContainer";
            taskListContainer.Size = new Size(729, 335);
            taskListContainer.TabIndex = 1;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Bottom;
            refreshButton.Location = new Point(635, 65);
            refreshButton.Margin = new Padding(3, 2, 3, 2);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(82, 22);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            // 
            // TaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 433);
            Controls.Add(taskListContainer);
            Controls.Add(toolPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TaskForm";
            Text = "ToDo";
            toolPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        protected internal Panel toolPanel;
        private FlowLayoutPanel taskListContainer;
        private Button addButton;
        private Button refreshButton;
    }
}