namespace ToDo.WinForms.Forms
{
    partial class AddForm
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
            titleGroup = new GroupBox();
            titleInput = new TextBox();
            descriptionGroup = new GroupBox();
            descriptionInput = new TextBox();
            deadlineGroup = new GroupBox();
            deadlineInput = new DateTimePicker();
            addButton = new Button();
            titleGroup.SuspendLayout();
            descriptionGroup.SuspendLayout();
            deadlineGroup.SuspendLayout();
            SuspendLayout();
            // 
            // titleGroup
            // 
            titleGroup.Controls.Add(titleInput);
            titleGroup.Location = new Point(10, 22);
            titleGroup.Margin = new Padding(3, 2, 3, 2);
            titleGroup.Name = "titleGroup";
            titleGroup.Padding = new Padding(3, 2, 3, 2);
            titleGroup.Size = new Size(348, 37);
            titleGroup.TabIndex = 0;
            titleGroup.TabStop = false;
            titleGroup.Text = "Title";
            // 
            // titleInput
            // 
            titleInput.Dock = DockStyle.Fill;
            titleInput.Location = new Point(3, 18);
            titleInput.Margin = new Padding(3, 2, 3, 2);
            titleInput.Name = "titleInput";
            titleInput.Size = new Size(342, 23);
            titleInput.TabIndex = 0;
            // 
            // descriptionGroup
            // 
            descriptionGroup.Controls.Add(descriptionInput);
            descriptionGroup.Location = new Point(13, 64);
            descriptionGroup.Margin = new Padding(3, 2, 3, 2);
            descriptionGroup.Name = "descriptionGroup";
            descriptionGroup.Padding = new Padding(3, 2, 3, 2);
            descriptionGroup.Size = new Size(348, 37);
            descriptionGroup.TabIndex = 1;
            descriptionGroup.TabStop = false;
            descriptionGroup.Text = "Description";
            // 
            // descriptionInput
            // 
            descriptionInput.Dock = DockStyle.Fill;
            descriptionInput.Location = new Point(3, 18);
            descriptionInput.Margin = new Padding(3, 2, 3, 2);
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Size = new Size(342, 23);
            descriptionInput.TabIndex = 0;
            // 
            // deadlineGroup
            // 
            deadlineGroup.Controls.Add(deadlineInput);
            deadlineGroup.Location = new Point(13, 106);
            deadlineGroup.Margin = new Padding(3, 2, 3, 2);
            deadlineGroup.Name = "deadlineGroup";
            deadlineGroup.Padding = new Padding(3, 2, 3, 2);
            deadlineGroup.Size = new Size(348, 37);
            deadlineGroup.TabIndex = 1;
            deadlineGroup.TabStop = false;
            deadlineGroup.Text = "Deadline";
            // 
            // deadlineInput
            // 
            deadlineInput.Dock = DockStyle.Fill;
            deadlineInput.Location = new Point(3, 18);
            deadlineInput.Margin = new Padding(3, 2, 3, 2);
            deadlineInput.Name = "deadlineInput";
            deadlineInput.Size = new Size(342, 23);
            deadlineInput.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(15, 180);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(340, 22);
            addButton.TabIndex = 2;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 213);
            Controls.Add(addButton);
            Controls.Add(deadlineGroup);
            Controls.Add(descriptionGroup);
            Controls.Add(titleGroup);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddForm";
            Text = "Add";
            WindowState = FormWindowState.Minimized;
            titleGroup.ResumeLayout(false);
            titleGroup.PerformLayout();
            descriptionGroup.ResumeLayout(false);
            descriptionGroup.PerformLayout();
            deadlineGroup.ResumeLayout(false);
            ResumeLayout(false);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        #endregion

        private GroupBox titleGroup;
        private TextBox titleInput;
        private GroupBox descriptionGroup;
        private TextBox descriptionInput;
        private GroupBox deadlineGroup;
        private DateTimePicker deadlineInput;
        private Button addButton;
    }
}