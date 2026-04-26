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
    public partial class Form4 : Form
    {
        int currentUserID;
        public Form4(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
        }
        public void LoadEmployeeData(int employeeID)
        {
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
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
                    statusComboBox.SelectedIndex = 0; 
                else
                    statusComboBox.SelectedIndex = 1; 
            }
        }
        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            employeesBindingSource.AddNew();
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

            // Проверка оклада
            if (!decimal.TryParse(salaryTextBox.Text, out decimal salaryValue) || salaryValue < 0)
            {
                MessageBox.Show("Оклад не может быть отрицательным! Введите корректную сумму.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ПРОВЕРКА ТЕЛЕФОНА (только цифры, пробелы, знаки +, -, (, ), и не более 20 символов)
            string phone = phoneTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(phone))
            {
                // Разрешённые символы: цифры, пробел, +, -, (, )
                bool phoneValid = true;
                foreach (char c in phone)
                {
                    if (!char.IsDigit(c) && c != ' ' && c != '+' && c != '-' && c != '(' && c != ')')
                    {
                        phoneValid = false;
                        break;
                    }
                }

                if (!phoneValid)
                {
                    MessageBox.Show("Телефон может содержать только цифры и знаки: + - ( )", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (phone.Length > 20)
                {
                    MessageBox.Show("Телефон не должен превышать 20 символов!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // ПРОВЕРКА EMAIL (должен содержать @ и точку после неё)
            string email = emailTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                bool emailValid = email.Contains("@") && email.Contains(".");

                if (!emailValid)
                {
                    MessageBox.Show("Введите корректный email! Пример: user@mail.ru", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (email.Length > 100)
                {
                    MessageBox.Show("Email не должен превышать 100 символов!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Проверка уникальности табельного номера
            string newTabNumber = tabNumberTextBox.Text;
            if (this.hRdepartmentDataSet.Employees.Rows.Count == 0)
            {
                this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            }

            DataRow[] existingRows = this.hRdepartmentDataSet.Employees.Select($"TabNumber = '{newTabNumber}'");
            if (existingRows.Length > 0)
            {
                MessageBox.Show($"Табельный номер '{newTabNumber}' уже существует! Введите уникальный номер.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Прямое добавление строки
            DataRow newRow = this.hRdepartmentDataSet.Employees.NewRow();
            newRow["Familia"] = familiaTextBox.Text;
            newRow["Name"] = nameTextBox.Text;
            newRow["Otchestvo"] = otchestvoTextBox.Text;
            newRow["TabNumber"] = tabNumberTextBox.Text;
            newRow["Position"] = positionTextBox.Text;
            newRow["Department"] = departmentTextBox.Text;
            newRow["HireDate"] = hireDateDateTimePicker.Value;
            newRow["Salary"] = salaryValue;
            newRow["Phone"] = phoneTextBox.Text;
            newRow["Email"] = emailTextBox.Text;
            newRow["Status"] = statusComboBox.SelectedItem.ToString();

            this.hRdepartmentDataSet.Employees.Rows.Add(newRow);
            this.employeesTableAdapter.Update(this.hRdepartmentDataSet.Employees);

            MessageBox.Show("Данные сотрудника сохранены!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;

            Form3 form3 = Application.OpenForms.OfType<Form3>().FirstOrDefault();
            form3?.WriteToHistory(currentUserID, "добавление сотрудника");

            this.Close();
        }
    }
}
