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
    public partial class WorkerMain : Form
    {
        Worker worker = null;
        public WorkerMain()
        {
            InitializeComponent();
        }
        public void GetUser(Worker worker)
        {
            this.worker = worker;
        }
        private void cvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCVForm addCVForm = new AddCVForm();
            addCVForm.GetUser(worker);
            addCVForm.ShowDialog();
        }

        private void isAxtarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<Advertisement> advertisements = new List<Advertisement>();
            using (HREntity db=new HREntity())
            {
                var isWorkerAddedCv = db.CurriculumVitaes.ToList().Exists(x=>x.WorkerId==worker.Id);
                if (isWorkerAddedCv)
                {
                    var result = (from cv in db.CurriculumVitaes
                                  where cv.WorkerId == worker.Id
                                  join a in db.Advertisements
                                  on new { Catagory = cv.Catagory, City = cv.City, Education = cv.Education, Experience = cv.Education }
                                  equals
                                  new { Catagory = a.Catagory, City = a.City, Education = a.Education, Experience = a.Education }
                                  select a).ToList();
                    if (result.Count != 0)
                    {
                        SearchJobForm searchJobForm = new SearchJobForm();
                        searchJobForm.GetAdList(result);
                        searchJobForm.GetWorker(worker);
                        searchJobForm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Advertisement not found");
                    }
                }
                else
                {
                    MessageBox.Show("Firstly you must add cv");
                }
                //bool isAdExists = false;
                //var workerCv = db.CurriculumVitaes.FirstOrDefault(x=>x.WorkerId==worker.Id);

                //var advertisemetColumns = from data in db.Advertisements.ToList()
                //                          select data;

                
                //foreach (var ad in advertisemetColumns)
                //{
                //    if (workerCv.Catagory==ad.Catagory&&workerCv.City==ad.City&&workerCv.Education==ad.Education&&workerCv.Experience==ad.Experience)
                //    {
                //        advertisements.Add(ad);
                //        isAdExists = true;
                //    }
                   
                //}
                //if (isAdExists)
                //{

                //    SearchJobForm searchJobForm = new SearchJobForm();
                //    searchJobForm.GetAdList(advertisements);
                //    searchJobForm.ShowDialog();
                    
                //}
                //else
                //{
                //    MessageBox.Show("Advertisement not found");
                //}
                

            }
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.GetWorker(worker);
            searchForm.ShowDialog();
        }

        private void melumatlariGosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HREntity db = new HREntity())
            {
                var isWorkerAddedCv = db.CurriculumVitaes.ToList().Exists(x => x.WorkerId == worker.Id);
                if (isWorkerAddedCv)
                {
                    ShowCvInfoForm showCvInfoForm = new ShowCvInfoForm();
                    showCvInfoForm.GetWorker(worker);
                    showCvInfoForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Firstly you must add cv");
                }
            }
        }

        private void butunElanlariGosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllAdvertisementsForm showAllAdvertisementsForm = new ShowAllAdvertisementsForm();
            showAllAdvertisementsForm.GetWorker(worker);
            showAllAdvertisementsForm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
            WelcomeForm welcomeForm = new WelcomeForm();
            
            welcomeForm.ShowDialog();
            
        }

        private void muracietOlunmusElanlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppliedAdvertisementsForm appliedAdvertisements = new AppliedAdvertisementsForm();
            appliedAdvertisements.GetWorker(worker);
            appliedAdvertisements.ShowDialog();
        }

        private void teklisflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HREntity db=new HREntity())
            {
                var isWorkerAddedCv = db.CurriculumVitaes.ToList().Exists(x => x.WorkerId == worker.Id);
                if (isWorkerAddedCv)
                {

                    SuggestionsForm suggestionsForm = new SuggestionsForm();
                    suggestionsForm.GetWorker(worker);
                    suggestionsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Firstly you must add cv");
                }
            }
           
            
        }
    }
}
