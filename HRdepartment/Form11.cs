using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRdepartment
{
    public partial class Form11 : Form
    {
        int currentUserID;
        public Form11(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
        }

        private void violationsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.violationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Violations". При необходимости она может быть перемещена или удалена.
            this.violationsTableAdapter.Fill(this.hRdepartmentDataSet.Violations);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            violationsBindingSource.AddNew();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (employeeIDTextBox.Text == "")
            {
                MessageBox.Show("Введите ID сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (descriptionTextBox.Text == "")
            {
                MessageBox.Show("Введите описание нарушения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(employeeIDTextBox.Text, out int employeeID))
            {
                MessageBox.Show("Введите корректный ID сотрудника (число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.hRdepartmentDataSet.Employees.Rows.Count == 0)
            {
                this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            }
            DataRow[] existingRows = this.hRdepartmentDataSet.Employees.Select($"EmployeeID = {employeeID}");
            if (existingRows.Length == 0)
            {
                MessageBox.Show($"Сотрудник с ID {employeeID} не найден!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow newRow = this.hRdepartmentDataSet.Violations.NewRow();
            newRow["EmployeeID"] = employeeID;
            newRow["ViolationDate"] = violationDateDateTimePicker.Value;
            newRow["Description"] = descriptionTextBox.Text;
            newRow["Penalty"] = penaltyComboBox.SelectedItem.ToString();
            this.hRdepartmentDataSet.Violations.Rows.Add(newRow);
            this.violationsTableAdapter.Update(this.hRdepartmentDataSet.Violations);
            int violationsCount = GetViolationsCountForMonth(employeeID, violationDateDateTimePicker.Value);
            if (violationsCount >= 2)
            {
                MessageBox.Show($"Внимание! У сотрудника уже {violationsCount} нарушения за этот месяц!\n" +
                    "Рекомендуется принять меры.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MessageBox.Show("Нарушение успешно добавлено!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            Form10 form10 = Application.OpenForms.OfType<Form10>().FirstOrDefault();
            form10?.WriteToHistory(currentUserID, "добавление нарушения");
            this.Close();
        }



        private int GetViolationsCountForMonth(int employeeID, DateTime date)
        {
            int count = 0;
            int month = date.Month;
            int year = date.Year;

            DataRow[] violations = this.hRdepartmentDataSet.Violations.Select($"EmployeeID = {employeeID}");

            foreach (DataRow row in violations)
            {
                DateTime violationDate = (DateTime)row["ViolationDate"];
                if (violationDate.Month == month && violationDate.Year == year)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
