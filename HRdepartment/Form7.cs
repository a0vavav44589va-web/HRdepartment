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
    public partial class Form7 : Form
    {
        public static DataTable VacationsData = null;
        public static int CurrentUserID { get; set; }
        string userRole;
        int currentUserID;
        public Form7(string role, int userID)
        {
            InitializeComponent();
            userRole = role;
            currentUserID = userID;
            CurrentUserID = userID;
        }

        private void vacationsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vacationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.History". При необходимости она может быть перемещена или удалена.
            this.historyTableAdapter.Fill(this.hRdepartmentDataSet.History);
            this.historyTableAdapter.Fill(this.hRdepartmentDataSet.History);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Vacations". При необходимости она может быть перемещена или удалена.
            this.vacationsTableAdapter.Fill(this.hRdepartmentDataSet.Vacations);
            VacationsData = this.hRdepartmentDataSet.Vacations;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
            }
            else
            {
                DataRowView currentRow = (DataRowView)vacationsBindingSource.Current;
                if (currentRow == null)
                {
                    MessageBox.Show("Выберите запись об отпуске для удаления!");
                    return;
                }

                DialogResult result = MessageBox.Show("Удалить запись об отпуске?", "Удаление",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                    WriteToHistory(currentUserID, "удаление отпуска");
                    vacationsBindingSource.RemoveCurrent();
                    this.vacationsTableAdapter.Update(this.hRdepartmentDataSet.Vacations);
                    MessageBox.Show("Запись об отпуске успешно удалена!", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(userRole, currentUserID);
            form7.Show();
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
                Form Form8 = new Form8(currentUserID);
                Form8.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
                return;
            }
            if (vacationsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись об отпуске для редактирования!");
                return;
            }
            Form9.SelectedVacationID = Convert.ToInt32(vacationsDataGridView.CurrentRow.Cells[0].Value);
            Form9 form9 = new Form9(currentUserID);
            form9.ShowDialog();
            this.vacationsTableAdapter.Fill(this.hRdepartmentDataSet.Vacations);
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
