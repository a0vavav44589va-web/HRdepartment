using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HRdepartment
{
    public partial class Form15 : Form
    {
        int currentUserID;
        string userRole;
        int currentEmployeeID = 0;
        public Form15(string role, int userID, int employeeID)
        {
            InitializeComponent();
            userRole = role;
            currentUserID = userID;
            currentEmployeeID = employeeID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
                return;
            }

            // Проверка наличия элементов
            if (fileNameTextBox == null || filePathTextBox == null)
            {
                MessageBox.Show("Элементы формы не настроены!");
                return;
            }

            if (string.IsNullOrWhiteSpace(fileNameTextBox.Text))
            {
                MessageBox.Show("Введите название файла!");
                return;
            }

            if (string.IsNullOrWhiteSpace(filePathTextBox.Text))
            {
                MessageBox.Show("Введите путь к файлу!");
                return;
            }

            if (!File.Exists(filePathTextBox.Text))
            {
                MessageBox.Show("Файл по указанному пути не найден!");
                return;
            }

            DataRow newRow = this.hRdepartmentDataSet.AttachedFiles.NewRow();
            newRow["EmployeeID"] = currentEmployeeID;
            newRow["FileName"] = fileNameTextBox.Text;
            newRow["FilePath"] = filePathTextBox.Text;
            newRow["UploadDate"] = DateTime.Now;

            this.hRdepartmentDataSet.AttachedFiles.Rows.Add(newRow);
            this.attachedFilesTableAdapter.Update(this.hRdepartmentDataSet.AttachedFiles);

            fileNameTextBox.Text = "";
            filePathTextBox.Text = "";

            LoadFiles();

            MessageBox.Show("Файл успешно добавлен!");

            Form3 form3 = Application.OpenForms.OfType<Form3>().FirstOrDefault();
            if (form3 != null)
            {
                form3.WriteToHistory(currentUserID, "добавление файла");
            }
        }

        private void attachedFilesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.attachedFilesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);

        }

        private void Form15_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.AttachedFiles". При необходимости она может быть перемещена или удалена.
            this.attachedFilesTableAdapter.Fill(this.hRdepartmentDataSet.AttachedFiles);
            LoadFiles();
        }

        private void LoadFiles()
        {
            this.attachedFilesTableAdapter.Fill(this.hRdepartmentDataSet.AttachedFiles);
            DataRow[] files = this.hRdepartmentDataSet.AttachedFiles.Select($"EmployeeID = {currentEmployeeID}");

            listBox1.Items.Clear();
            foreach (DataRow row in files)
            {
                string fileName = row["FileName"].ToString();
                string filePath = row["FilePath"].ToString();
                listBox1.Items.Add($"{fileName}|{filePath}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите файл для открытия!");
                return;
            }

            string selectedItem = listBox1.SelectedItem.ToString();
            string filePath = selectedItem.Substring(selectedItem.IndexOf('|') + 1);

            if (File.Exists(filePath))
            {
                try
                {
                    System.Diagnostics.Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось открыть файл: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (userRole == "директор")
            {
                MessageBox.Show("Недостаточно прав доступа!");
                return;
            }

            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите файл для удаления!");
                return;
            }

            DialogResult result = MessageBox.Show("Удалить выбранный файл?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string fileName = selectedItem.Substring(0, selectedItem.IndexOf('|'));

                DataRow[] rows = this.hRdepartmentDataSet.AttachedFiles.Select($"FileName = '{fileName}' AND EmployeeID = {currentEmployeeID}");
                if (rows.Length > 0)
                {
                    rows[0].Delete();
                    this.attachedFilesTableAdapter.Update(this.hRdepartmentDataSet.AttachedFiles);
                    LoadFiles();

                    MessageBox.Show("Файл удалён!");

                    Form3 form3 = Application.OpenForms.OfType<Form3>().FirstOrDefault();
                    if (form3 != null)
                    {
                        form3.WriteToHistory(currentUserID, "удаление файла");
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
