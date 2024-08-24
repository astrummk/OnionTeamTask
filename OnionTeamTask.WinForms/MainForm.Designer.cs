namespace OnionTeamTask.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv = new DataGridView();
            btnClose = new Button();
            btnAddNew = new Button();
            txtTaskName = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            dtpTaskDueDate = new DateTimePicker();
            label3 = new Label();
            cboCategory = new ComboBox();
            cboStatus = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            txtTaskDescription = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(59, 236);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(669, 215);
            dgv.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(684, 477);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(104, 31);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(649, 21);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(97, 32);
            btnAddNew.TabIndex = 2;
            btnAddNew.Text = "Add New";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(221, 25);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(246, 27);
            txtTaskName.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(637, 109);
            button1.Name = "button1";
            button1.Size = new Size(114, 27);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 28);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 5;
            label1.Text = "Task Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 73);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 6;
            label2.Text = "Task Date";
            // 
            // dtpTaskDueDate
            // 
            dtpTaskDueDate.Location = new Point(221, 68);
            dtpTaskDueDate.Name = "dtpTaskDueDate";
            dtpTaskDueDate.Size = new Size(250, 27);
            dtpTaskDueDate.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 104);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 8;
            label3.Text = "Category";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(221, 101);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(244, 28);
            cboCategory.TabIndex = 9;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(221, 135);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(244, 28);
            cboStatus.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 138);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 10;
            label4.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 178);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 12;
            label5.Text = "Task Description";
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(221, 178);
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(247, 27);
            txtTaskDescription.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 520);
            Controls.Add(txtTaskDescription);
            Controls.Add(label5);
            Controls.Add(cboStatus);
            Controls.Add(label4);
            Controls.Add(cboCategory);
            Controls.Add(label3);
            Controls.Add(dtpTaskDueDate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtTaskName);
            Controls.Add(btnAddNew);
            Controls.Add(btnClose);
            Controls.Add(dgv);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv;
        private Button btnClose;
        private Button btnAddNew;
        private TextBox txtTaskName;
        private Button button1;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpTaskDueDate;
        private Label label3;
        private ComboBox cboCategory;
        private ComboBox cboStatus;
        private Label label4;
        private Label label5;
        private TextBox txtTaskDescription;
    }
}
