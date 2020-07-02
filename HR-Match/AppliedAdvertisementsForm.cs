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
    public partial class AppliedAdvertisementsForm : Form
    {
        Worker worker = null;
        public AppliedAdvertisementsForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }
        List<Advertisement> appliedAdvertisements = null;
        private void AppliedAdvertisements_Load(object sender, EventArgs e)
        {
            using (HREntity db=new HREntity())
            {
                appliedAdvertisements = (from wa in db.WorkerAdvertisemets
                                         where wa.WorkerId == worker.Id
                                         join a in db.Advertisements
                                         
                                         on wa.AdvertisementId equals a.Id
                                        
                                         select a
                                         ).ToList();

            }
            var adColumns = (from a in appliedAdvertisements
                             select new { a.AdvertisementName, a.CompanyName, a.Catagory, a.Education, a.Experience, a.Salary }).ToList();
           
            dataGridView1.DataSource = adColumns;
        }
    }
}
