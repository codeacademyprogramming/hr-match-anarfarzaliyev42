using HR_Match.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Match
{
    public partial class EmployerSearchForm : Form
    {
        Employer employer = null;
        public EmployerSearchForm()
        {
            InitializeComponent();
        }
        public void GetEmployer(Employer employer)
        {
            this.employer = employer;
        }
        private void EmployerSearchForm_Load(object sender, EventArgs e)
        {
            comboBoxBase.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxItem.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        List<Advertisement> advertisements = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> comboBoxes = new List<string>() { comboBoxBase.Text, comboBoxItem.Text };
            bool isEmpty = comboBoxes.TrueForAll(x => x != "");
            if (isEmpty)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                
                using (HREntity db = new HREntity())
                {
                    var currentEmployer = db.Employers.Find(employer.Id);
                    var employerAds = (from a in db.Advertisements
                                       where a.EmployerId == employer.Id
                                       select a).ToList();
                    advertisements = (from a in employerAds
                                      where a.Catagory == comboBoxItem.Text || a.City == comboBoxItem.Text
                                      || a.Education == comboBoxItem.Text || a.Experience == comboBoxItem.Text || a.Salary.ToString() == comboBoxItem.Text
                                      select a).ToList();
                    var adColumns = (from a in advertisements
                                     select new { a.AdvertisementName, a.CompanyName, a.Catagory, a.Education, a.Experience, a.Salary }).ToList();
                    dataGridView1.DataSource = adColumns;


                }
            



            }
            else
            {
                MessageBox.Show("Cannot be empty");
            }
        }

        private void comboBoxBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] catagoryItems = new string[] { "Hekim", "IT mutexessis", "Jurnalist", "Tercumeci" };
            string[] educationItems = new string[] { "Ali", "Natamam ali", "Orta" };
            string[] cityItems = new string[] { "Baki", "Gence", "Seki" };
            string[] salaryItems = new string[] { "200", "500", "700" };
            string[] experienceItems = new string[] { "1 ilden asagi", "1 ilden - 3 ile qeder", "3 ilden - 5 ile qeder", "5 ilden daha cox" };
            comboBoxItem.Items.Clear();
            switch (comboBoxBase.Text)
            {
                case "Kateqoriya":
                    comboBoxItem.Items.AddRange(catagoryItems);
                    break;
                case "Tehsil":
                    comboBoxItem.Items.AddRange(educationItems);
                    break;
                case "Seher":
                    comboBoxItem.Items.AddRange(cityItems);
                    break;
                case "Emek haqqi":
                    comboBoxItem.Items.AddRange(salaryItems);
                    break;
                case "Tecrube":
                    comboBoxItem.Items.AddRange(experienceItems);
                    break;
                default:
                    break;
            }
        }
    }
}
