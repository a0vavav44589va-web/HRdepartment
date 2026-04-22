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
    public partial class Form10 : Form
    {
        public static DataTable ViolationsData = null;
        public static int CurrentUserID { get; set; }
        string userRole;
        int currentUserID;
        public Form10(string role, int userID)
        {
            InitializeComponent();
            userRole = role;
            currentUserID = userID;
            CurrentUserID = userID;
        }

        private void violationsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.violationsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.History". При необходимости она может быть перемещена или удалена.
            this.historyTableAdapter.Fill(this.hRdepartmentDataSet.History);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Violations". При необходимости она может быть перемещена или удалена.
            this.violationsTableAdapter.Fill(this.hRdepartmentDataSet.Violations);
            ViolationsData = this.hRdepartmentDataSet.Violations;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(userRole, currentUserID);
            form10.Show();
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
                Form Form11 = new Form11(currentUserID);
                Form11.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
                return;
            }
            if (violationsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись о нарушении для редактирования!");
                return;
            }
            Form12.SelectedViolationID = Convert.ToInt32(violationsDataGridView.CurrentRow.Cells[0].Value);
            Form12 form12 = new Form12(currentUserID);
            form12.ShowDialog();
            this.violationsTableAdapter.Fill(this.hRdepartmentDataSet.Violations);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
            }
            else
            {
                DataRowView currentRow = (DataRowView)violationsBindingSource.Current;
                if (currentRow == null)
                {
                    MessageBox.Show("Выберите запись о нарушении для удаления!");
                    return;
                }

                DialogResult result = MessageBox.Show("Удалить запись о нарушении?", "Удаление",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                    WriteToHistory(currentUserID, "удаление нарушения");
                    violationsBindingSource.RemoveCurrent();
                    this.violationsTableAdapter.Update(this.hRdepartmentDataSet.Violations);
                    MessageBox.Show("Запись о нарушении успешно удалена!", "Удаление",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
