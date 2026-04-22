namespace HRdepartment
{
    partial class Form12
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
            System.Windows.Forms.Label penaltyLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label violationDateLabel;
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label label2;
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.hRdepartmentDataSet = new HRdepartment.HRdepartmentDataSet();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeesTableAdapter = new HRdepartment.HRdepartmentDataSetTableAdapters.EmployeesTableAdapter();
            this.tableAdapterManager = new HRdepartment.HRdepartmentDataSetTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.violationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.violationsTableAdapter = new HRdepartment.HRdepartmentDataSetTableAdapters.ViolationsTableAdapter();
            this.employeeIDTextBox1 = new System.Windows.Forms.TextBox();
            this.violationDateDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.penaltyComboBox = new System.Windows.Forms.ComboBox();
            penaltyLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            violationDateLabel = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hRdepartmentDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.violationsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // penaltyLabel
            // 
            penaltyLabel.AutoSize = true;
            penaltyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            penaltyLabel.Location = new System.Drawing.Point(286, 135);
            penaltyLabel.Name = "penaltyLabel";
            penaltyLabel.Size = new System.Drawing.Size(173, 22);
            penaltyLabel.TabIndex = 51;
            penaltyLabel.Text = "Мера воздействия*";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            descriptionLabel.Location = new System.Drawing.Point(8, 135);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(100, 22);
            descriptionLabel.TabIndex = 49;
            descriptionLabel.Text = "Описание*";
            // 
            // violationDateLabel
            // 
            violationDateLabel.AutoSize = true;
            violationDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            violationDateLabel.Location = new System.Drawing.Point(286, 68);
            violationDateLabel.Name = "violationDateLabel";
            violationDateLabel.Size = new System.Drawing.Size(150, 22);
            violationDateLabel.TabIndex = 47;
            violationDateLabel.Text = "Дата нарушения";
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            employeeIDLabel.Location = new System.Drawing.Point(8, 68);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(174, 22);
            employeeIDLabel.TabIndex = 46;
            employeeIDLabel.Text = "Номер сотрудника*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(8, 268);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(197, 22);
            label2.TabIndex = 45;
            label2.Text = "* - обязательные поля";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(372, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 40);
            this.button2.TabIndex = 44;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(10, 211);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(164, 40);
            this.button8.TabIndex = 42;
            this.button8.Text = "Сохранить";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // hRdepartmentDataSet
            // 
            this.hRdepartmentDataSet.DataSetName = "HRdepartmentDataSet";
            this.hRdepartmentDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(139, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 32);
            this.label1.TabIndex = 52;
            this.label1.Text = "Редактирование";
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
            // employeeIDTextBox1
            // 
            this.employeeIDTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.violationsBindingSource, "EmployeeID", true));
            this.employeeIDTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeeIDTextBox1.Location = new System.Drawing.Point(12, 93);
            this.employeeIDTextBox1.Name = "employeeIDTextBox1";
            this.employeeIDTextBox1.Size = new System.Drawing.Size(246, 28);
            this.employeeIDTextBox1.TabIndex = 53;
            // 
            // violationDateDateTimePicker1
            // 
            this.violationDateDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.violationsBindingSource, "ViolationDate", true));
            this.violationDateDateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.violationDateDateTimePicker1.Location = new System.Drawing.Point(290, 91);
            this.violationDateDateTimePicker1.Name = "violationDateDateTimePicker1";
            this.violationDateDateTimePicker1.Size = new System.Drawing.Size(246, 28);
            this.violationDateDateTimePicker1.TabIndex = 54;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.violationsBindingSource, "Description", true));
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 160);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(246, 28);
            this.descriptionTextBox.TabIndex = 55;
            // 
            // penaltyComboBox
            // 
            this.penaltyComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.violationsBindingSource, "Penalty", true));
            this.penaltyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.penaltyComboBox.FormattingEnabled = true;
            this.penaltyComboBox.Items.AddRange(new object[] {
            "выговор",
            "штраф"});
            this.penaltyComboBox.Location = new System.Drawing.Point(290, 160);
            this.penaltyComboBox.Name = "penaltyComboBox";
            this.penaltyComboBox.Size = new System.Drawing.Size(246, 30);
            this.penaltyComboBox.TabIndex = 56;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(610, 311);
            this.Controls.Add(this.penaltyComboBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.violationDateDateTimePicker1);
            this.Controls.Add(this.employeeIDTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(penaltyLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(violationDateLabel);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button8);
            this.Name = "Form12";
            this.Text = "Редактирование нарушений";
            this.Load += new System.EventHandler(this.Form12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hRdepartmentDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.violationsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private HRdepartmentDataSet hRdepartmentDataSet;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private HRdepartmentDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private HRdepartmentDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label1;
        private HRdepartmentDataSetTableAdapters.ViolationsTableAdapter violationsTableAdapter;
        private System.Windows.Forms.BindingSource violationsBindingSource;
        private System.Windows.Forms.TextBox employeeIDTextBox1;
        private System.Windows.Forms.DateTimePicker violationDateDateTimePicker1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox penaltyComboBox;
    }
}