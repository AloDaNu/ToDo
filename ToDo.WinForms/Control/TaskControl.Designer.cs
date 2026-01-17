namespace ToDo.WinForms.Control
{
    partial class TaskControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            taskGroup = new GroupBox();
            editButton = new Button();
            deleteButton = new Button();
            descriptionLabel = new Label();
            taskIsCompletedCheckBox = new CheckBox();
            taskGroup.SuspendLayout();
            SuspendLayout();
            // 
            // taskGroup
            // 
            taskGroup.Controls.Add(editButton);
            taskGroup.Controls.Add(deleteButton);
            taskGroup.Controls.Add(descriptionLabel);
            taskGroup.Controls.Add(taskIsCompletedCheckBox);
            taskGroup.Dock = DockStyle.Fill;
            taskGroup.Location = new Point(0, 0);
            taskGroup.Margin = new Padding(3, 2, 3, 2);
            taskGroup.Name = "taskGroup";
            taskGroup.Padding = new Padding(3, 2, 3, 2);
            taskGroup.Size = new Size(735, 146);
            taskGroup.TabIndex = 0;
            taskGroup.TabStop = false;
            taskGroup.Text = " Title";
            // 
            // editButton
            // 
            editButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            editButton.Location = new Point(648, 120);
            editButton.Margin = new Padding(3, 2, 3, 2);
            editButton.Name = "editButton";
            editButton.Size = new Size(82, 22);
            editButton.TabIndex = 3;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            deleteButton.Location = new Point(560, 120);
            deleteButton.Margin = new Padding(3, 2, 3, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(82, 22);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = AnchorStyles.Left;
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(81, 64);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(67, 15);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Description";
            // 
            // taskIsCompletedCheckBox
            // 
            taskIsCompletedCheckBox.Anchor = AnchorStyles.Left;
            taskIsCompletedCheckBox.AutoSize = true;
            taskIsCompletedCheckBox.Location = new Point(18, 64);
            taskIsCompletedCheckBox.Margin = new Padding(3, 2, 3, 2);
            taskIsCompletedCheckBox.Name = "taskIsCompletedCheckBox";
            taskIsCompletedCheckBox.Size = new Size(15, 14);
            taskIsCompletedCheckBox.TabIndex = 0;
            taskIsCompletedCheckBox.UseVisualStyleBackColor = true;
            // 
            // TaskControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(taskGroup);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TaskControl";
            Size = new Size(735, 146);
            taskGroup.ResumeLayout(false);
            taskGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox taskGroup;
        private CheckBox taskIsCompletedCheckBox;
        private Button editButton;
        private Button deleteButton;
        private Label descriptionLabel;
    }
}
