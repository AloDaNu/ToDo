namespace ToDo.WinForms.Forms
{
    partial class EditForm
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
            saveButton = new Button();
            deadlineGroup = new GroupBox();
            deadlineInput = new DateTimePicker();
            descriptionGroup = new GroupBox();
            descriptionInput = new TextBox();
            titleGroup = new GroupBox();
            titleInput = new TextBox();
            backButton = new Button();
            deadlineGroup.SuspendLayout();
            descriptionGroup.SuspendLayout();
            titleGroup.SuspendLayout();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(18, 215);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(389, 29);
            saveButton.TabIndex = 6;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // deadlineGroup
            // 
            deadlineGroup.Controls.Add(deadlineInput);
            deadlineGroup.Location = new Point(15, 124);
            deadlineGroup.Name = "deadlineGroup";
            deadlineGroup.Size = new Size(398, 49);
            deadlineGroup.TabIndex = 4;
            deadlineGroup.TabStop = false;
            deadlineGroup.Text = "Deadline";
            // 
            // deadlineInput
            // 
            deadlineInput.Dock = DockStyle.Fill;
            deadlineInput.Location = new Point(3, 23);
            deadlineInput.Name = "deadlineInput";
            deadlineInput.Size = new Size(392, 27);
            deadlineInput.TabIndex = 0;
            // 
            // descriptionGroup
            // 
            descriptionGroup.Controls.Add(descriptionInput);
            descriptionGroup.Location = new Point(15, 68);
            descriptionGroup.Name = "descriptionGroup";
            descriptionGroup.Size = new Size(398, 49);
            descriptionGroup.TabIndex = 5;
            descriptionGroup.TabStop = false;
            descriptionGroup.Text = "Description";
            // 
            // descriptionInput
            // 
            descriptionInput.Dock = DockStyle.Fill;
            descriptionInput.Location = new Point(3, 23);
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Size = new Size(392, 27);
            descriptionInput.TabIndex = 0;
            // 
            // titleGroup
            // 
            titleGroup.Controls.Add(titleInput);
            titleGroup.Location = new Point(12, 12);
            titleGroup.Name = "titleGroup";
            titleGroup.Size = new Size(398, 49);
            titleGroup.TabIndex = 3;
            titleGroup.TabStop = false;
            titleGroup.Text = "Title";
            // 
            // titleInput
            // 
            titleInput.Dock = DockStyle.Fill;
            titleInput.Location = new Point(3, 23);
            titleInput.Name = "titleInput";
            titleInput.Size = new Size(392, 27);
            titleInput.TabIndex = 0;
            // 
            // backButton
            // 
            backButton.Location = new Point(18, 252);
            backButton.Name = "backButton";
            backButton.Size = new Size(389, 29);
            backButton.TabIndex = 7;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 290);
            Controls.Add(backButton);
            Controls.Add(saveButton);
            Controls.Add(deadlineGroup);
            Controls.Add(descriptionGroup);
            Controls.Add(titleGroup);
            Name = "EditForm";
            Text = "Edit";
            deadlineGroup.ResumeLayout(false);
            descriptionGroup.ResumeLayout(false);
            descriptionGroup.PerformLayout();
            titleGroup.ResumeLayout(false);
            titleGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button saveButton;
        private GroupBox deadlineGroup;
        private DateTimePicker deadlineInput;
        private GroupBox descriptionGroup;
        private TextBox descriptionInput;
        private GroupBox titleGroup;
        private TextBox titleInput;
        private Button backButton;
    }
}