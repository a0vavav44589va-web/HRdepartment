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
    public partial class Form8 : Form
    {
        int currentUserID;
        private DataRow[] _cachedVacations;
        public Form8(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
        }

        private void vacationsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vacationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Vacations". При необходимости она может быть перемещена или удалена.
            this.vacationsTableAdapter.Fill(this.hRdepartmentDataSet.Vacations);
            _cachedVacations = this.hRdepartmentDataSet.Vacations.Select();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vacationsBindingSource.AddNew();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (employeeIDTextBox.Text == "")
            {
                MessageBox.Show("Введите ID сотрудника!");
                return;
            }
            if (startDateDateTimePicker.Value > endDateDateTimePicker.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания!");
                return;
            }
            if (!int.TryParse(employeeIDTextBox.Text, out int employeeID))
            {
                MessageBox.Show("Введите корректный ID сотрудника (число)!");
                return;
            }
            DataRow[] foundRows = this.hRdepartmentDataSet.Employees.Select($"EmployeeID = {employeeID}");
            if (foundRows.Length == 0)
            {
                MessageBox.Show("Сотрудник с таким ID не найден!");
                return;
            }
            DateTime startDate = startDateDateTimePicker.Value;
            DateTime endDate = endDateDateTimePicker.Value;
            if (!CheckVacationDuration(startDate, endDate))
                return;
            if (!CheckVacationLimit(startDate, endDate))
                return;
            DataRow newRow = this.hRdepartmentDataSet.Vacations.NewRow();
            newRow["EmployeeID"] = employeeID;
            newRow["StartDate"] = startDate;
            newRow["EndDate"] = endDate;
            newRow["VacationType"] = vacationTypeComboBox.SelectedItem.ToString();
            this.hRdepartmentDataSet.Vacations.Rows.Add(newRow);
            this.vacationsTableAdapter.Update(this.hRdepartmentDataSet.Vacations);
            MessageBox.Show("Отпуск успешно добавлен!");
            Form7 form7 = Application.OpenForms.OfType<Form7>().FirstOrDefault();
            form7?.WriteToHistory(currentUserID, "добавление отпуска");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private bool CheckVacationLimit(DateTime startDate, DateTime endDate, int excludeVacationID = -1)
        {
            DataRow[] allVacations = _cachedVacations;
            int overlappingCount = 0;
            foreach (DataRow row in allVacations)
            {
                int vacationID = (int)row["VacationID"];
                if (excludeVacationID != -1 && vacationID == excludeVacationID) continue;

                DateTime rowStart = (DateTime)row["StartDate"];
                DateTime rowEnd = (DateTime)row["EndDate"];
                if (startDate <= rowEnd && endDate >= rowStart) overlappingCount++;
            }
            if (overlappingCount >= 3)
            {
                MessageBox.Show("В данный период уже 3 сотрудника в отпуске!");
                return false;
            }
            return true;
        }
        private bool CheckVacationDuration(DateTime startDate, DateTime endDate)
        {
            int duration = (endDate - startDate).Days + 1;

            if (duration > 28)
            {
                MessageBox.Show($"Продолжительность отпуска не может превышать 28 дней!\nВы указали {duration} дней.",
                    "Слишком длинный отпуск", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
