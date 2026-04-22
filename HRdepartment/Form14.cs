using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HRdepartment
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Form3 f3 = new Form3("кадровик", Form3.CurrentUserID);
            f3.Show();
            f3.Close();

            Form7 f7 = new Form7("кадровик", Form3.CurrentUserID);
            f7.Show();
            f7.Close();

            Form10 f10 = new Form10("кадровик", Form3.CurrentUserID);
            f10.Show();
            f10.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            LoadEmployeesWithExperienceMore5Years();
            LoadViolationsStatistics();
            LoadVacationSchedule();
        }

        private void LoadEmployeesWithExperienceMore5Years()
        {
            if (Form3.EmployeesData == null)
            {
                MessageBox.Show("Данные сотрудников не загружены!");
                return;
            }

            DataTable employees = Form3.EmployeesData;
            DateTime today = DateTime.Now;

            textBox1.Clear();

            foreach (DataRow row in employees.Rows)
            {
                DateTime hireDate = (DateTime)row["HireDate"];
                int years = today.Year - hireDate.Year;
                if (today < hireDate.AddYears(years)) years--;

                if (years > 5)
                {
                    string fullName = $"{row["Familia"]} {row["Name"]} {row["Otchestvo"]}";
                    string department = row["Department"].ToString();
                    textBox1.AppendText($"{fullName} - {department} (стаж: {years} лет)\r\n");
                }
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Нет сотрудников со стажем более 5 лет";
            }
        }

        // 2. Статистика нарушений по отделам (Chart1)
        private void LoadViolationsStatistics()
        {
            if (Form3.EmployeesData == null || Form10.ViolationsData == null)
            {
                MessageBox.Show("Данные нарушений не загружены!");
                return;
            }

            DataTable employees = Form3.EmployeesData;
            DataTable violations = Form10.ViolationsData;

            // Считаем нарушения по отделам
            Dictionary<string, int> violationsByDepartment = new Dictionary<string, int>();

            foreach (DataRow emp in employees.Rows)
            {
                string department = emp["Department"].ToString();
                if (!violationsByDepartment.ContainsKey(department))
                {
                    violationsByDepartment[department] = 0;
                }
            }

            foreach (DataRow viol in violations.Rows)
            {
                int empID = (int)viol["EmployeeID"];
                DataRow[] empRows = employees.Select($"EmployeeID = {empID}");
                if (empRows.Length > 0)
                {
                    string department = empRows[0]["Department"].ToString();
                    if (violationsByDepartment.ContainsKey(department))
                    {
                        violationsByDepartment[department]++;
                    }
                }
            }

            // Очищаем Chart
            chart1.Series.Clear();
            Series series = new Series("Нарушения");
            series.ChartType = SeriesChartType.Column;

            foreach (var item in violationsByDepartment)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart1.Series.Add(series);
            chart1.Titles.Clear();
            chart1.Titles.Add("Статистика нарушений по отделам");
        }

        // 3. График отпусков по отделам (Chart2)
        private void LoadVacationSchedule()
        {
            if (Form3.EmployeesData == null || Form7.VacationsData == null)
            {
                MessageBox.Show("Данные отпусков не загружены!");
                return;
            }

            DataTable employees = Form3.EmployeesData;
            DataTable vacations = Form7.VacationsData;
            DateTime today = DateTime.Now;

            // Считаем сколько сотрудников в отпуске сейчас по отделам
            Dictionary<string, int> vacationsByDepartment = new Dictionary<string, int>();

            foreach (DataRow emp in employees.Rows)
            {
                string department = emp["Department"].ToString();
                if (!vacationsByDepartment.ContainsKey(department))
                {
                    vacationsByDepartment[department] = 0;
                }
            }

            foreach (DataRow vac in vacations.Rows)
            {
                DateTime start = (DateTime)vac["StartDate"];
                DateTime end = (DateTime)vac["EndDate"];

                if (today >= start && today <= end)
                {
                    int empID = (int)vac["EmployeeID"];
                    DataRow[] empRows = employees.Select($"EmployeeID = {empID}");
                    if (empRows.Length > 0)
                    {
                        string department = empRows[0]["Department"].ToString();
                        if (vacationsByDepartment.ContainsKey(department))
                        {
                            vacationsByDepartment[department]++;
                        }
                    }
                }
            }

            // Очищаем Chart
            chart2.Series.Clear();
            Series series = new Series("В отпуске");
            series.ChartType = SeriesChartType.Column;

            foreach (var item in vacationsByDepartment)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart2.Series.Add(series);
            chart2.Titles.Clear();
            chart2.Titles.Add("График отпусков по отделам (текущие)");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Нет сотрудников со стажем более 5 лет")
            {
                MessageBox.Show("Нет данных для экспорта!");
                return;
            }

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            worksheet.Cells[1, 1] = "Сотрудники со стажем более 5 лет";
            worksheet.Cells[1, 1].Font.Bold = true;
            worksheet.Cells[1, 1].Font.Size = 14;

            string[] lines = textBox1.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                worksheet.Cells[i + 3, 1] = lines[i];
            }

            worksheet.Columns.AutoFit();
            MessageBox.Show("Экспорт в Excel выполнен!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Нет сотрудников со стажем более 5 лет")
            {
                MessageBox.Show("Нет данных для экспорта!");
                return;
            }

            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = true;
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();

            Microsoft.Office.Interop.Word.Paragraph title = doc.Content.Paragraphs.Add();
            title.Range.Text = "Сотрудники со стажем более 5 лет";
            title.Range.Font.Bold = 1;
            title.Range.Font.Size = 16;
            title.Range.InsertParagraphAfter();

            Microsoft.Office.Interop.Word.Paragraph list = doc.Content.Paragraphs.Add();
            list.Range.Text = textBox1.Text;
            list.Range.InsertParagraphAfter();

            MessageBox.Show("Экспорт в Word выполнен!");
        }
    }
}
