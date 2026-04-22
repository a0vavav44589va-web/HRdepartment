namespace HRdepartment
{
    partial class Form11
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label violationDateLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label penaltyLabel;
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hRdepartmentDataSet = new HRdepartment.HRdepartmentDataSet();
            this.violationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.violationsTableAdapter = new HRdepartment.HRdepartmentDataSetTableAdapters.ViolationsTableAdapter();
            this.tableAdapterManager = new HRdepartment.HRdepartmentDataSetTableAdapters.TableAdapterManager();
            this.employeesTableAdapter = new HRdepartment.HRdepartmentDataSetTableAdapters.EmployeesTableAdapter();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.violationDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.penaltyComboBox = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            label2 = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            violationDateLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            penaltyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hRdepartmentDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.violationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(26, 273);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(197, 22);
            label2.TabIndex = 35;
            label2.Text = "* - обязательные поля";
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            employeeIDLabel.Location = new System.Drawing.Point(26, 73);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(174, 22);
            employeeIDLabel.TabIndex = 36;
            employeeIDLabel.Text = "Номер сотрудника*";
            // 
            // violationDateLabel
            // 
            violationDateLabel.AutoSize = true;
            violationDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            violationDateLabel.Location = new System.Drawing.Point(304, 73);
            violationDateLabel.Name = "violationDateLabel";
            violationDateLabel.Size = new System.Drawing.Size(150, 22);
            violationDateLabel.TabIndex = 37;
            violationDateLabel.Text = "Дата нарушения";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            descriptionLabel.Location = new System.Drawing.Point(26, 140);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(100, 22);
            descriptionLabel.TabIndex = 38;
            descriptionLabel.Text = "Описание*";
            // 
            // penaltyLabel
            // 
            penaltyLabel.AutoSize = true;
            penaltyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            penaltyLabel.Location = new System.Drawing.Point(304, 140);
            penaltyLabel.Name = "penaltyLabel";
            penaltyLabel.Size = new System.Drawing.Size(173, 22);
            penaltyLabel.TabIndex = 39;
            penaltyLabel.Text = "Мера воздействия*";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(390, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 40);
            this.button2.TabIndex = 34;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(198, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 40);
            this.button1.TabIndex = 33;
            this.button1.Text = "Очистить поля";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(28, 216);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(164, 40);
            this.button8.TabIndex = 32;
            this.button8.Text = "Сохранить";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(178, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 32);
            this.label1.TabIndex = 31;
            this.label1.Text = "Добавление";
            // 
            // hRdepartmentDataSet
            // 
            this.hRdepartmentDataSet.DataSetName = "HRdepartmentDataSet";
            this.hRdepartmentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // violationsBindingSource
            // 
            this.violationsBindingSource.DataMember = "Violations";
            this.violationsBindingSource.DataSource = this.hRdepartmentDataSet;
            // 
            // violationsTableAdapter
            // 
            this.violationsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AttachedFilesTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EmployeesTableAdapter = this.employeesTableAdapter;
            this.tableAdapterManager.HistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = HRdepartment.HRdepartmentDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            this.tableAdapterManager.VacationsTableAdapter = null;
            this.tableAdapterManager.ViolationsTableAdapter = this.violationsTableAdapter;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.violationsBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeeIDTextBox.Location = new System.Drawing.Point(30, 98);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(246, 28);
            this.employeeIDTextBox.TabIndex = 37;
            // 
            // violationDateDateTimePicker
            // 
            this.violationDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.violationsBindingSource, "ViolationDate", true));
            this.violationDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationDateDateTimePicker.Location = new System.Drawing.Point(308, 98);
            this.violationDateDateTimePicker.Name = "violationDateDateTimePicker";
            this.violationDateDateTimePicker.Size = new System.Drawing.Size(246, 28);
            this.violationDateDateTimePicker.TabIndex = 38;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.violationsBindingSource, "Description", true));
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionTextBox.Location = new System.Drawing.Point(30, 165);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(246, 28);
            this.descriptionTextBox.TabIndex = 39;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            this.employeesBindingSource.DataSource = this.hRdepartmentDataSet;
            // 
            // penaltyComboBox
            // 
            this.penaltyComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.violationsBindingSource, "Penalty", true));
            this.penaltyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penaltyComboBox.FormattingEnabled = true;
            this.penaltyComboBox.Items.AddRange(new object[] {
            "выговор",
            "штраф"});
            this.penaltyComboBox.Location = new System.Drawing.Point(308, 163);
            this.penaltyComboBox.Name = "penaltyComboBox";
            this.penaltyComboBox.Size = new System.Drawing.Size(246, 30);
            this.penaltyComboBox.TabIndex = 40;
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(598, 318);
            this.Controls.Add(this.penaltyComboBox);
            this.Controls.Add(penaltyLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(violationDateLabel);
            this.Controls.Add(this.violationDateDateTimePicker);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label1);
            this.Name = "Form11";
            this.Text = "Добавление нарушений";
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hRdepartmentDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.violationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private HRdepartmentDataSet hRdepartmentDataSet;
        private System.Windows.Forms.BindingSource violationsBindingSource;
        private HRdepartmentDataSetTableAdapters.ViolationsTableAdapter violationsTableAdapter;
        private HRdepartmentDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.DateTimePicker violationDateDateTimePicker;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private HRdepartmentDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private System.Windows.Forms.ComboBox penaltyComboBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}