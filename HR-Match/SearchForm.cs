using HR_Match.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Match
{

    public partial class SearchForm : Form
    {
        Worker worker = null;
        public SearchForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        DataGridViewButtonColumn dgvBtn = null;
        private void SearchForm_Load(object sender, EventArgs e)
        {
            comboBoxBase.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxItem.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvBtn = new DataGridViewButtonColumn();
            dgvBtn.HeaderText = "Apply";
            dgvBtn.Text = "Muraciet et";
            dgvBtn.UseColumnTextForButtonValue = true;
           
        }
        List<Advertisement> advertisements = null;
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> comboBoxes = new List<string>() {comboBoxBase.Text,comboBoxItem.Text };
            bool isEmpty = comboBoxes.TrueForAll(x=>x!="");
            if (isEmpty)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                
                using (HREntity db = new HREntity())
                {

                    advertisements = (from a in db.Advertisements
                                      where a.Catagory == comboBoxItem.Text || a.City == comboBoxItem.Text
                                      || a.Education == comboBoxItem.Text || a.Experience == comboBoxItem.Text || a.Salary.ToString() == comboBoxItem.Text
                                      select a).ToList();
                    var adColumns = (from a in advertisements
                                     select new { a.AdvertisementName, a.CompanyName, a.Catagory, a.Education, a.Experience, a.Salary }).ToList();
                    dataGridView1.DataSource = adColumns;
                    

                }
                dataGridView1.Columns.Add(dgvBtn);



            }
            else
            {
                MessageBox.Show("Cannot be empty");
            }
            
            
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int rowIndex = 0;
            if (e.ColumnIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                rowIndex = e.RowIndex;

                Advertisement clickedAd = advertisements[rowIndex];
                using (HREntity db = new HREntity())
                {
                    var isWorkerAddedCv = db.CurriculumVitaes.ToList().Exists(x => x.Id == worker.Id);
                    if (isWorkerAddedCv)
                    {
                        bool isWorkerApplied = db.WorkerAdvertisemets.ToList().Exists(x => x.WorkerId == worker.Id && x.AdvertisementId == clickedAd.Id);
                        if (isWorkerApplied)
                        {
                            MessageBox.Show($"You already applied to this advertisement", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        db.WorkerAdvertisemets.Add(new WorkerAdvertisement() { AdvertisementId = clickedAd.Id, WorkerId = worker.Id });

                        db.SaveChanges();
                        MessageBox.Show($"You succesfully applied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Firstly you must add cv");
                    }
                 

                }

              
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
