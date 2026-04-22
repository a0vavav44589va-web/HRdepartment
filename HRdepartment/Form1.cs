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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.hRdepartmentDataSet.Users);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (login == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль!");
            }
            else
            {
                HRdepartmentDataSet.UsersDataTable data = hRdepartmentDataSet.Users;
                bool found = false;
                string role = "";
                int userID = 0;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i]["Login"].ToString() == login &&
                        data.Rows[i]["Password"].ToString() == password)
                    {
                        found = true;
                        role = data.Rows[i]["Role"].ToString();
                        userID = (int)data.Rows[i]["UserID"];
                        break;
                    }
                }

                if (found)
                {
                    Form2 f2 = new Form2(role, userID);
                    f2.Show();
                    this.Hide();
                    f2.FormClosed += (s, args) =>
                    {
                        this.Show();
                    };
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }
}
