using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace HRdepartment
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            SetupDataGridView();
            Form3 f3 = new Form3("кадровик", Form3.CurrentUserID);
            f3.Show();
            f3.Close();
            Form7 f7 = new Form7("кадровик", Form3.CurrentUserID);
            f7.Show();
            f7.Close();
        }
        private void SetupDataGridView()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("EmployeeID", "ID");
            dataGridView1.Columns.Add("FullName", "ФИО");
            dataGridView1.Columns.Add("TabNumber", "Табельный номер");
            dataGridView1.Columns.Add("Position", "Должность");
            dataGridView1.Columns.Add("Department", "Отдел");
            dataGridView1.Columns.Add("Experience", "Стаж");
            dataGridView1.Columns.Add("Salary", "Оклад");
            dataGridView1.Columns.Add("Phone", "Телефон");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Status", "Статус");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hRdepartmentDataSet);
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.vacationsTableAdapter.Fill(this.hRdepartmentDataSet.Vacations);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hRdepartmentDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.hRdepartmentDataSet.Employees);
            dateTimePicker1.Value = new DateTime(2000, 1, 1);
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText) && !checkBox1.Checked)
            {
                MessageBox.Show("Введите текст для поиска или включите фильтр по дате!");
                return;
            }
            if (Form3.EmployeesData == null)
            {
                MessageBox.Show("Данные сотрудников не загружены!");
                return;
            }
            DataTable employees = Form3.EmployeesData;
            dataGridView1.Rows.Clear();
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (checkBox1.Checked)
            {
                fromDate = dateTimePicker1.Value.Date;
                toDate = dateTimePicker2.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Дата 'от' не может быть позже даты 'до'!");
                    return;
                }
            }

            foreach (DataRow row in employees.Rows)
            {
                // ДОБАВИТЬ ПРОВЕРКУ ПО ДАТЕ
                bool matchDate = true;
                if (checkBox1.Checked)
                {
                    DateTime hireDate = (DateTime)row["HireDate"];
                    if (fromDate.HasValue && hireDate < fromDate.Value)
                        matchDate = false;
                    if (toDate.HasValue && hireDate > toDate.Value)
                        matchDate = false;
                }

                if (!matchDate) continue;

                // Проверка по тексту (если есть)
                bool matchText = true;
                if (!string.IsNullOrEmpty(searchText))
                {
                    string fullName = $"{row["Familia"]} {row["Name"]} {row["Otchestvo"]}".ToLower();
                    string tabNumber = row["TabNumber"].ToString().ToLower();
                    string department = row["Department"].ToString().ToLower();
                    matchText = fullName.Contains(searchText) || tabNumber.Contains(searchText) || department.Contains(searchText);
                }

                if (matchText && matchDate)
                {
                    AddRowToResults(row);
                }
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Ничего не найдено!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form3.EmployeesData == null)
            {
                MessageBox.Show("Данные сотрудников не загружены!");
                return;
            }

            if (Form7.VacationsData == null)
            {
                MessageBox.Show("Данные отпусков не загружены!");
                return;
            }

            DataTable employees = Form3.EmployeesData;
            DataTable vacations = Form7.VacationsData;
            DateTime today = DateTime.Now;

            dataGridView1.Rows.Clear();

            foreach (DataRow emp in employees.Rows)
            {
                int empID = (int)emp["EmployeeID"];
                bool isOnVacation = false;

                foreach (DataRow vac in vacations.Rows)
                {
                    if ((int)vac["EmployeeID"] == empID)
                    {
                        DateTime start = (DateTime)vac["StartDate"];
                        DateTime end = (DateTime)vac["EndDate"];
                        if (today >= start && today <= end)
                        {
                            isOnVacation = true;
                            break;
                        }
                    }
                }

                if (isOnVacation)
                {
                    AddRowToResults(emp);
                }
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нет сотрудников в отпуске!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form3.EmployeesData == null)
            {
                MessageBox.Show("Данные сотрудников не загружены!");
                return;
            }

            DataTable employees = Form3.EmployeesData;
            DateTime today = DateTime.Now;

            dataGridView1.Rows.Clear();

            foreach (DataRow row in employees.Rows)
            {
                DateTime hireDate = (DateTime)row["HireDate"];
                int years = today.Year - hireDate.Year;
                if (today < hireDate.AddYears(years)) years--;

                if (years > 5)
                {
                    AddRowToResults(row);
                }
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нет сотрудников со стажем более 5 лет!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!");
                return;
            }

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                }
            }

            worksheet.Columns.AutoFit();
            MessageBox.Show("Экспорт в Excel выполнен!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!");
                return;
            }

            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = true;
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();

            Microsoft.Office.Interop.Word.Paragraph title = doc.Content.Paragraphs.Add();
            title.Range.Text = "Результаты поиска сотрудников";
            title.Range.Font.Bold = 1;
            title.Range.Font.Size = 16;
            title.Range.InsertParagraphAfter();

            Microsoft.Office.Interop.Word.Table table = doc.Tables.Add(
                doc.Content.Paragraphs.Add().Range,
                dataGridView1.Rows.Count + 1,
                dataGridView1.Columns.Count);

            table.Borders.Enable = 1;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                table.Cell(1, i + 1).Range.Text = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    table.Cell(i + 2, j + 1).Range.Text = dataGridView1.Rows[i].Cells[j].Value?.ToString();
                }
            }

            table.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent);
            MessageBox.Show("Экспорт в Word выполнен!");
        }




        private void AddRowToResults(DataRow row)
        {
            DateTime hireDate = (DateTime)row["HireDate"];
            DateTime today = DateTime.Now;
            int years = today.Year - hireDate.Year;
            if (today < hireDate.AddYears(years)) years--;

            dataGridView1.Rows.Add(
                row["EmployeeID"],
                $"{row["Familia"]} {row["Name"]} {row["Otchestvo"]}",
                row["TabNumber"],
                row["Position"],
                row["Department"],
                $"{years} лет",
                row["Salary"],
                row["Phone"],
                row["Email"],
                row["Status"]
            );
        }
    }
}
