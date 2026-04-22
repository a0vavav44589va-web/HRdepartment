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
    public partial class Form5 : Form
    {
        int currentUserID;
        private int _editingEmployeeID;
        public static int SelectedEmployeeID = -1;
        public Form5(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);

            // Берём ID из статической переменной
            int employeeID = SelectedEmployeeID;

            // Находим сотрудника
            HRdepartmentDataSet.EmployeesRow row =
                this.hRdepartmentDataSet.Employees.FindByEmployeeID(employeeID);

            if (row != null)
            {
                familiaTextBox.Text = row.Familia;
                nameTextBox.Text = row.Name;
                otchestvoTextBox.Text = row.Otchestvo;
                tabNumberTextBox.Text = row.TabNumber;
                positionTextBox.Text = row.Position;
                departmentTextBox.Text = row.Department;
                hireDateDateTimePicker.Value = row.HireDate;
                salaryTextBox.Text = row.Salary.ToString();
                phoneTextBox.Text = row.Phone;
                emailTextBox.Text = row.Email;

                if (row.Status == "работает")
                    statusComboBox1.SelectedIndex = 0;
                else
                    statusComboBox1.SelectedIndex = 1;
            }
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            if (familiaTextBox.Text == "" || nameTextBox.Text == "" ||
        tabNumberTextBox.Text == "" || positionTextBox.Text == "" ||
        departmentTextBox.Text == "" || salaryTextBox.Text == "")
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(salaryTextBox.Text, out decimal salaryValue) || salaryValue < 0)
            {
                MessageBox.Show("Оклад не может быть отрицательным! Введите корректную сумму.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string newTabNumber = tabNumberTextBox.Text;
            DataRow[] existingRows = this.hRdepartmentDataSet.Employees.Select($"TabNumber = '{newTabNumber}' AND EmployeeID <> {SelectedEmployeeID}");
            if (existingRows.Length > 0)
            {
                MessageBox.Show($"Табельный номер '{newTabNumber}' уже существует у другого сотрудника! Введите уникальный номер.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow[] rows = this.hRdepartmentDataSet.Employees.Select($"EmployeeID = {SelectedEmployeeID}");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                row["Familia"] = familiaTextBox.Text;
                row["Name"] = nameTextBox.Text;
                row["Otchestvo"] = otchestvoTextBox.Text;
                row["TabNumber"] = tabNumberTextBox.Text;
                row["Position"] = positionTextBox.Text;
                row["Department"] = departmentTextBox.Text;
                row["HireDate"] = hireDateDateTimePicker.Value;
                row["Salary"] = salaryValue;
                row["Phone"] = phoneTextBox.Text;
                row["Email"] = emailTextBox.Text;
                row["Status"] = statusComboBox1.SelectedItem.ToString();
            }
            this.employeesTableAdapter.Update(this.hRdepartmentDataSet.Employees);
            Form3 form3 = Application.OpenForms.OfType<Form3>().FirstOrDefault();
            if (form3 != null)
            {
                form3.WriteToHistory(currentUserID, "редактирование сотрудника");
            }
            MessageBox.Show("Данные сохранены!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}

