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
    public partial class Form3 : Form
    {
        public static DataTable EmployeesData = null;
        public static int CurrentUserID { get; set; }
        string userRole;
        int currentUserID;
        public Form3(string role, int userID)
        {
            InitializeComponent();
            userRole = role;
            currentUserID = userID;
            CurrentUserID = userID;
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.History". При необходимости она может быть перемещена или удалена.
            this.historyTableAdapter.Fill(this.hRdepartmentDataSet.History);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Violations". При необходимости она может быть перемещена или удалена.
            this.violationsTableAdapter.Fill(this.hRdepartmentDataSet.Violations);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Vacations". При необходимости она может быть перемещена или удалена.
            this.vacationsTableAdapter.Fill(this.hRdepartmentDataSet.Vacations);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.hRdepartmentDataSet.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.AttachedFiles". При необходимости она может быть перемещена или удалена.
            this.attachedFilesTableAdapter.Fill(this.hRdepartmentDataSet.AttachedFiles);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.AttachedFiles". При необходимости она может быть перемещена или удалена.
            this.attachedFilesTableAdapter.Fill(this.hRdepartmentDataSet.AttachedFiles);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            EmployeesData = this.hRdepartmentDataSet.Employees;
            AddExperienceColumn();

        }
        private void AddExperienceColumn()
        {
            if (employeesDataGridView.Columns["Experience"] == null)
            {
                DataGridViewTextBoxColumn expColumn = new DataGridViewTextBoxColumn();
                expColumn.Name = "Experience";
                expColumn.HeaderText = "Стаж";
                expColumn.ReadOnly = true;
                employeesDataGridView.Columns.Add(expColumn);
            }
            for (int i = 0; i < employeesDataGridView.Rows.Count - 1; i++)
            {
                DataGridViewRow row = employeesDataGridView.Rows[i];
                object hireDateValue = row.Cells["dataGridViewTextBoxColumn8"].Value;

                if (hireDateValue != null && hireDateValue != DBNull.Value)
                {
                    try
                    {
                        DateTime hireDate = Convert.ToDateTime(hireDateValue);
                        DateTime today = DateTime.Now;

                        int years = today.Year - hireDate.Year;
                        if (today < hireDate.AddYears(years)) years--;

                        string yearsWord = GetYearsWord(years);
                        row.Cells["Experience"].Value = $"{years} {yearsWord}";
                    }
                    catch
                    {
                        row.Cells["Experience"].Value = "ошибка";
                    }
                }
                else
                {
                    row.Cells["Experience"].Value = "";
                }
            }
        }

        private string GetYearsWord(int years)
        {
            if (years % 10 == 1 && years % 100 != 11)
                return "год";
            else if (years % 10 >= 2 && years % 10 <= 4 && (years % 100 < 10 || years % 100 >= 20))
                return "года";
            else
                return "лет";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(userRole, currentUserID);
            form3.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
            }
            else 
            {
                Form Form4 = new Form4(currentUserID);
                Form4.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
            }
            else
            {
                DataRowView currentRow = (DataRowView)employeesBindingSource.Current;
                if (currentRow == null)
                {
                    MessageBox.Show("Выберите сотрудника для удаления!");
                    return;
                }
                int employeeID = (int)currentRow["EmployeeID"];
                bool hasVacations = false;
                bool hasViolations = false;
                bool hasFiles = false;
                bool hasUser = false;
                HRdepartmentDataSet.VacationsDataTable vacations = this.vacationsTableAdapter.GetData();
                foreach (var row in vacations)
                {
                    if (row.EmployeeID == employeeID)
                    {
                        hasVacations = true;
                        break;
                    }
                }
                HRdepartmentDataSet.ViolationsDataTable violations = this.violationsTableAdapter.GetData();
                foreach (var row in violations)
                {
                    if (row.EmployeeID == employeeID)
                    {
                        hasViolations = true;
                        break;
                    }
                }
                HRdepartmentDataSet.AttachedFilesDataTable files = this.attachedFilesTableAdapter.GetData();
                foreach (var row in files)
                {
                    if (row.EmployeeID == employeeID)
                    {
                        hasFiles = true;
                        break;
                    }
                }
                HRdepartmentDataSet.UsersDataTable users = this.usersTableAdapter.GetData();
                foreach (var row in users)
                {
                    if (row.EmployeeID == employeeID)
                    {
                        hasUser = true;
                        break;
                    }
                }
                if (hasVacations || hasViolations || hasFiles || hasUser)
                {
                    string message = "Нельзя удалить сотрудника, так как у него есть:\n";
                    if (hasVacations) message += "- Записи об отпусках\n";
                    if (hasViolations) message += "- Записи о нарушениях\n";
                    if (hasFiles) message += "- Прикреплённые файлы\n";
                    if (hasUser) message += "- Учётная запись пользователя\n";
                    message += "\nСначала удалите все связанные записи.";

                    MessageBox.Show(message, "Невозможно удалить",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show("Удалить запись?", "Удаление",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.OK)
                {
                    WriteToHistory(currentUserID, "удаление сотрудника");
                    employeesBindingSource.RemoveCurrent();
                    this.employeesTableAdapter.Update(this.hRdepartmentDataSet.Employees);
                    MessageBox.Show("Сотрудник успешно удалён!", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
                return;
            }
            if (employeesDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }
            Form5.SelectedEmployeeID = Convert.ToInt32(employeesDataGridView.CurrentRow.Cells[0].Value);
            Form5 form5 = new Form5(currentUserID);
            form5.ShowDialog();
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            AddExperienceColumn();
        }




        public void WriteToHistory(int userID, string description)
        {
            try
            {
                DataRow newRow = this.hRdepartmentDataSet.History.NewRow();
                newRow["UserID"] = userID;
                newRow["Description"] = description;
                newRow["ActionDateTime"] = DateTime.Now;

                this.hRdepartmentDataSet.History.Rows.Add(newRow);
                this.historyTableAdapter.Update(this.hRdepartmentDataSet.History);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи истории: " + ex.Message);
            }
        }
    }
}
