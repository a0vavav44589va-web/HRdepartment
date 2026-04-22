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
    public partial class Form12 : Form
    {
        int currentUserID;
        public static int SelectedViolationID = -1;
        public Form12(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Violations". При необходимости она может быть перемещена или удалена.
            this.violationsTableAdapter.Fill(this.hRdepartmentDataSet.Violations);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            HRdepartmentDataSet.ViolationsRow row =
            this.hRdepartmentDataSet.Violations.FindByViolationID(SelectedViolationID);

            if (row != null)
            {
                // ПРАВИЛЬНО: выводим ID сотрудника из записи нарушения
                employeeIDTextBox1.Text = row.EmployeeID.ToString();  // ВОТ ЭТА СТРОКА ВАЖНА

                violationDateDateTimePicker1.Value = row.ViolationDate;
                descriptionTextBox.Text = row.Description;

                if (row.Penalty == "выговор")
                    penaltyComboBox.SelectedIndex = 0;
                else
                    penaltyComboBox.SelectedIndex = 1;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(employeeIDTextBox1.Text, out int employeeID))
            {
                MessageBox.Show("Введите корректный ID сотрудника!");
                return;
            }

            // Проверяем, существует ли сотрудник
            DataRow[] empRows = this.hRdepartmentDataSet.Employees.Select($"EmployeeID = {employeeID}");
            if (empRows.Length == 0)
            {
                MessageBox.Show("Сотрудник с таким ID не найден!");
                return;
            }

            if (descriptionTextBox.Text == "")
            {
                MessageBox.Show("Введите описание нарушения!");
                return;
            }

            // Обновляем
            DataRow[] rows = this.hRdepartmentDataSet.Violations.Select($"ViolationID = {SelectedViolationID}");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                row["EmployeeID"] = employeeID;
                row["ViolationDate"] = violationDateDateTimePicker1.Value;
                row["Description"] = descriptionTextBox.Text;
                row["Penalty"] = penaltyComboBox.SelectedItem.ToString();
            }

            this.violationsTableAdapter.Update(this.hRdepartmentDataSet.Violations);

            Form10 form10 = Application.OpenForms.OfType<Form10>().FirstOrDefault();
            if (form10 != null)
            {
                form10.WriteToHistory(currentUserID, "редактирование нарушения");
            }

            MessageBox.Show("Данные сохранены!");
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
