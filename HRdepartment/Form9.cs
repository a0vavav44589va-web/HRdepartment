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
    public partial class Form9 : Form
    {
        int currentUserID;
        public static int SelectedVacationID = -1;
        public Form9(int userID)
        {
            InitializeComponent();
            currentUserID = userID;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void vacationsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vacationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }
        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            this.vacationsTableAdapter.Fill(this.hRdepartmentDataSet.Vacations);
            int vacationID = SelectedVacationID;
            HRdepartmentDataSet.VacationsRow row =
                this.hRdepartmentDataSet.Vacations.FindByVacationID(vacationID);

            if (row != null)
            {
                HRdepartmentDataSet.EmployeesRow employeeRow =
                    this.hRdepartmentDataSet.Employees.FindByEmployeeID(row.EmployeeID);

                if (employeeRow != null)
                {
                    employeeIDTextBox.Text = row.EmployeeID.ToString();
                }

                startDateDateTimePicker.Value = row.StartDate;
                endDateDateTimePicker.Value = row.EndDate;

                if (row.VacationType == "оплачиваемый")
                    vacationTypeComboBox.SelectedIndex = 0;
                else
                    vacationTypeComboBox.SelectedIndex = 1;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (startDateDateTimePicker.Value > endDateDateTimePicker.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания!");
                return;
            }

            DateTime startDate = startDateDateTimePicker.Value;
            DateTime endDate = endDateDateTimePicker.Value;

            // ПРОВЕРКА: длительность отпуска не более 28 дней
            if (!CheckVacationDuration(startDate, endDate))
                return;

            // Получаем ID сотрудника из текущей записи
            DataRow[] currentRows = this.hRdepartmentDataSet.Vacations.Select($"VacationID = {SelectedVacationID}");
            if (currentRows.Length == 0)
            {
                MessageBox.Show("Запись об отпуске не найдена!");
                return;
            }

            int employeeID = (int)currentRows[0]["EmployeeID"];
            if (!CheckVacationLimit(employeeID, startDate, endDate, SelectedVacationID))
                return;
            DataRow[] rows = this.hRdepartmentDataSet.Vacations.Select($"VacationID = {SelectedVacationID}");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                row["StartDate"] = startDate;
                row["EndDate"] = endDate;
                row["VacationType"] = vacationTypeComboBox.SelectedItem.ToString();
            }
            this.vacationsTableAdapter.Update(this.hRdepartmentDataSet.Vacations);
            Form7 form7 = Application.OpenForms.OfType<Form7>().FirstOrDefault();
            if (form7 != null)
            {
                form7.WriteToHistory(currentUserID, "редактирование отпуска");
            }
            MessageBox.Show("Данные отпуска сохранены!");
            this.Close();
        }




        private bool CheckVacationLimit(int employeeID, DateTime startDate, DateTime endDate, int excludeVacationID = -1)
        {
            DataRow[] allVacations = this.hRdepartmentDataSet.Vacations.Select();

            int overlappingCount = 0;

            foreach (DataRow row in allVacations)
            {
                int vacationID = (int)row["VacationID"];
                if (excludeVacationID != -1 && vacationID == excludeVacationID)
                    continue;

                int empID = (int)row["EmployeeID"];
                DateTime rowStart = (DateTime)row["StartDate"];
                DateTime rowEnd = (DateTime)row["EndDate"];
                bool isOverlap = (startDate <= rowEnd && endDate >= rowStart);

                if (isOverlap)
                {
                    overlappingCount++;
                }
            }
            if (overlappingCount >= 3)
            {
                MessageBox.Show("В данный период уже 3 сотрудника в отпуске!\nБольше трёх одновременно отпускать нельзя.",
                    "Лимит отпускников", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

