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
    public partial class Form2 : Form
    {
        string userRole;
        int currentUserID;
        public Form2(string role, int userID)
        {
            InitializeComponent();
            userRole = role;
            currentUserID = userID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(userRole, currentUserID);
            f3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(userRole, currentUserID);
            f7.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10(userRole, currentUserID);
            f10.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataRow[] userRows = this.hRdepartmentDataSet.Users.Select($"UserID = {currentUserID}");

            if (userRows.Length == 0)
            {
                MessageBox.Show("Пользователь не найден!");
                return;
            }

            int employeeID = (int)userRows[0]["EmployeeID"];

            Form15 f15 = new Form15(userRole, currentUserID, employeeID);
            f15.ShowDialog();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.hRdepartmentDataSet.Users);

        }
    }
}
