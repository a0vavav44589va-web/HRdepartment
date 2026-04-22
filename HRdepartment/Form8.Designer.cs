namespace HRdepartment
{
    partial class Form8
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
            System.Windows.Forms.Label startDateLabel;
            System.Windows.Forms.Label endDateLabel;
            System.Windows.Forms.Label vacationTypeLabel;
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hRdepartmentDataSet = new HRdepartment.HRdepartmentDataSet();
            this.vacationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vacationsTableAdapter = new HRdepartment.HRdepartmentDataSetTableAdapters.VacationsTableAdapter();
            this.tableAdapterManager = new HRdepartment.HRdepartmentDataSetTableAdapters.TableAdapterManager();
            this.employeeIDTextBox = new System.Windows.Forms.TextBox();
            this.startDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vacationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeesTableAdapter = new HRdepartment.HRdepartmentDataSetTableAdapters.EmployeesTableAdapter();
            label2 = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            startDateLabel = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            vacationTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hRdepartmentDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vacationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(16, 273);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(197, 22);
            label2.TabIndex = 35;
            label2.Text = "* - обязательные поля";
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            employeeIDLabel.Location = new System.Drawing.Point(16, 62);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(174, 22);
            employeeIDLabel.TabIndex = 36;
            employeeIDLabel.Text = "Номер сотрудника*";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            startDateLabel.Location = new System.Drawing.Point(295, 62);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new System.Drawing.Size(117, 22);
            startDateLabel.TabIndex = 37;
            startDateLabel.Text = "Дата начала";
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            endDateLabel.Location = new System.Drawing.Point(295, 128);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new System.Drawing.Size(146, 22);
            endDateLabel.TabIndex = 38;
            endDateLabel.Text = "Дата окончания";
            // 
            // vacationTypeLabel
            // 
            vacationTypeLabel.AutoSize = true;
            vacationTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            vacationTypeLabel.Location = new System.Drawing.Point(16, 126);
            vacationTypeLabel.Name = "vacationTypeLabel";
            vacationTypeLabel.Size = new System.Drawing.Size(119, 22);
            vacationTypeLabel.TabIndex = 39;
            vacationTypeLabel.Text = "Тип отпуска*";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(380, 216);
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
            this.button1.Location = new System.Drawing.Point(188, 216);
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
            this.button8.Location = new System.Drawing.Point(18, 216);
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
            this.label1.Location = new System.Drawing.Point(168, 9);
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
            // vacationsBindingSource
            // 
            this.vacationsBindingSource.DataMember = "Vacations";
            this.vacationsBindingSource.DataSource = this.hRdepartmentDataSet;
            // 
            // vacationsTableAdapter
            // 
            this.vacationsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AttachedFilesTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.EmployeesTableAdapter = null;
            this.tableAdapterManager.HistoryTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = HRdepartment.HRdepartmentDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            this.tableAdapterManager.VacationsTableAdapter = this.vacationsTableAdapter;
            this.tableAdapterManager.ViolationsTableAdapter = null;
            // 
            // employeeIDTextBox
            // 
            this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vacationsBindingSource, "EmployeeID", true));
            this.employeeIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeeIDTextBox.Location = new System.Drawing.Point(20, 87);
            this.employeeIDTextBox.Name = "employeeIDTextBox";
            this.employeeIDTextBox.Size = new System.Drawing.Size(245, 28);
            this.employeeIDTextBox.TabIndex = 37;
            // 
            // startDateDateTimePicker
            // 
            this.startDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vacationsBindingSource, "StartDate", true));
            this.startDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDateDateTimePicker.Location = new System.Drawing.Point(299, 87);
            this.startDateDateTimePicker.Name = "startDateDateTimePicker";
            this.startDateDateTimePicker.Size = new System.Drawing.Size(245, 28);
            this.startDateDateTimePicker.TabIndex = 38;
            // 
            // endDateDateTimePicker
            // 
            this.endDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.vacationsBindingSource, "EndDate", true));
            this.endDateDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endDateDateTimePicker.Location = new System.Drawing.Point(299, 153);
            this.endDateDateTimePicker.Name = "endDateDateTimePicker";
            this.endDateDateTimePicker.Size = new System.Drawing.Size(245, 28);
            this.endDateDateTimePicker.TabIndex = 39;
            // 
            // vacationTypeComboBox
            // 
            this.vacationTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.vacationsBindingSource, "VacationType", true));
            this.vacationTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vacationTypeComboBox.FormattingEnabled = true;
            this.vacationTypeComboBox.Items.AddRange(new object[] {
            "оплачиваемый",
            "за свой счёт"});
            this.vacationTypeComboBox.Location = new System.Drawing.Point(20, 151);
            this.vacationTypeComboBox.Name = "vacationTypeComboBox";
            this.vacationTypeComboBox.Size = new System.Drawing.Size(245, 30);
            this.vacationTypeComboBox.TabIndex = 40;
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            this.employeesBindingSource.DataSource = this.hRdepartmentDataSet;
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(597, 314);
            this.Controls.Add(vacationTypeLabel);
            this.Controls.Add(this.vacationTypeComboBox);
            this.Controls.Add(endDateLabel);
            this.Controls.Add(this.endDateDateTimePicker);
            this.Controls.Add(startDateLabel);
            this.Controls.Add(this.startDateDateTimePicker);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label1);
            this.Name = "Form8";
            this.Text = "Добавить отпуск";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hRdepartmentDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vacationsBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource vacationsBindingSource;
        private HRdepartmentDataSetTableAdapters.VacationsTableAdapter vacationsTableAdapter;
        private HRdepartmentDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox employeeIDTextBox;
        private System.Windows.Forms.DateTimePicker startDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateDateTimePicker;
        private System.Windows.Forms.ComboBox vacationTypeComboBox;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private HRdepartmentDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
    }
}