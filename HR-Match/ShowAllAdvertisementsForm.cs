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
    public partial class ShowAllAdvertisementsForm : Form
    {
        Worker worker = null;
        
        public ShowAllAdvertisementsForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }

        List<Advertisement> advertisements = null;
      
        private void ShowAllAdvertisementsForm_Load(object sender, EventArgs e)
        {

            using (HREntity db = new HREntity())
            {
                advertisements = db.Advertisements.ToList();

            }
            var adColums = (from a in advertisements
                            select a.Catagory).ToList();
            //DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();
            //dgvBtn.HeaderText = "Ad number";

            //dgvBtn.UseColumnTextForButtonValue = true;
            
            dataGridView1.Columns.Add("Number", "Number");
         
            dataGridView1.DataSource = adColums.Select(x => new { Name = x }).ToList(); ;
            dataGridView1.Columns[0].Width = 50;



        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells["Number"].Value = (e.RowIndex + 1).ToString();
                
                
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int rowIndex = 0;
           
            if (e.ColumnIndex == 0 && e.RowIndex>=0)
            {
                rowIndex = e.RowIndex;
               
                
                ShowDetailsOfSelectedAdForm showDetails = new ShowDetailsOfSelectedAdForm();
                showDetails.GetAdvertisement(advertisements[rowIndex]);
                showDetails.GetWorker(worker);
                showDetails.ShowDialog();


            }
        }
    }
}
