using HR_Match.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Match
{
    public partial class EmployerAppliesForm : Form
    {
        Employer employer = null;
      
        public EmployerAppliesForm()
        {
            InitializeComponent();
        }
        public void GetEmployer(Employer employer)
        {
            this.employer = employer;
        }
        List<CurriculumVitae> workerCvs = null;
        HREntity db = null;
        private void EmployerAppliesForm_Load(object sender, EventArgs e)
        {
            using (db=new HREntity())
            {
                //Get cvs of workers who applied to this employer's ads
                workerCvs = (from wa in db.WorkerAdvertisemets
                           join a in db.Advertisements
                           on
                           wa.AdvertisementId equals a.Id
                           where a.EmployerId == employer.Id
                           join cv in db.CurriculumVitaes
                           on wa.WorkerId equals cv.Id
                           select cv).ToList();

                var data = (from wa in db.WorkerAdvertisemets
                            join a in db.Advertisements
                            on
                            wa.AdvertisementId equals a.Id
                            where a.EmployerId==employer.Id
                            join wcv in db.CurriculumVitaes
                            on wa.WorkerId equals wcv.Id
                            select new { a.AdvertisementName, wcv.Name }).ToList();
                
                dataGridView1.DataSource = data;
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int rowIndex = 0;

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                //workerCvs[rowIndex].WorkerId
                //using (db=new HREntity())
                //{
                //    worker=(from w in db.Workers
                //            join wcv in workerCvs
                //            on w.Id equals wcv.WorkerId
                //            select w).ToList().FirstOrDefault(x=>x.Id == workerCvs[rowIndex].WorkerId);
                //}
                EmployerCandidateDetailsForm candidateDetails = new EmployerCandidateDetailsForm();
                candidateDetails.GetWorkerCv(workerCvs[rowIndex]);
                candidateDetails.ShowDialog();
                //MessageBox.Show($"Row:{e.RowIndex} Column:{e.ColumnIndex}");
            }
        }
    }
}
