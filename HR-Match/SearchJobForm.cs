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
    public partial class SearchJobForm : Form
    {
        Worker worker = null;
        public SearchJobForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }
        List<Advertisement> advertisements = null;
        public void GetAdList(List<Advertisement> advertisements)
        {
            this.advertisements = advertisements;
        }

        private void SearchJobForm_Load(object sender, EventArgs e)
        {

            var adColums = (from a in advertisements
                            select new { a.AdvertisementName,a.CompanyName, a.Catagory, a.City,a.Experience,a.PhoneNumber }).ToList();
            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();
            dgvBtn.HeaderText = "Apply";
            dgvBtn.Text = "Muraciet et";
            dgvBtn.UseColumnTextForButtonValue = true;

            dataGridView1.DataSource = adColums;
            dataGridView1.Columns.Add(dgvBtn);
            //foreach (var ad in advertisements)
            //{
            //    string[] data = new string[] { ad.AdvertisementName, ad.CompanyName, ad.Description, ad.City, ad.Salary.ToString(), ad.Age.ToString(), ad.Education, ad.Experience, ad.PhoneNumber };

            //}




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


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
                using (HREntity db=new HREntity())
                {
                    bool isWorkerApplied = db.WorkerAdvertisemets.ToList().Exists(x=>x.WorkerId==worker.Id&&x.AdvertisementId==clickedAd.Id);

                    if (isWorkerApplied)
                    {
                        MessageBox.Show($"You already applied to this advertisement","Info",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                    db.WorkerAdvertisemets.Add(new WorkerAdvertisement() { AdvertisementId = clickedAd.Id, WorkerId = worker.Id });
                    
;                  db.SaveChanges();
                    MessageBox.Show($"You succesfully applied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  
                }
             
             
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
