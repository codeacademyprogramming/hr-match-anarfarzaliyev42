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
    public partial class ShowDetailsOfSelectedAdForm : Form
    {
        Advertisement advertisement = null;
        Worker worker = null;
        public ShowDetailsOfSelectedAdForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }
        public void GetAdvertisement(Advertisement advertisement)
        {
            this.advertisement = advertisement;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (HREntity db = new HREntity())
            {
                
                    bool isWorkerApplied = db.WorkerAdvertisemets.ToList().Exists(x => x.WorkerId == worker.Id && x.AdvertisementId == advertisement.Id);
                    if (isWorkerApplied)
                    {
                        MessageBox.Show($"You already applied to this advertisement", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    db.WorkerAdvertisemets.Add(new WorkerAdvertisement() { AdvertisementId = advertisement.Id, WorkerId = worker.Id });

                    db.SaveChanges();
                    MessageBox.Show($"You succesfully applied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               


            }
        }

        private void ShowDetailsOfSelectedAdForm_Load(object sender, EventArgs e)
        {
            tbxAdName.Text = advertisement.AdvertisementName;
            tbxAdName.Enabled = false;
            tbxCompanyName.Text = advertisement.CompanyName;
            tbxCompanyName.Enabled = false;
            comboBoxCategory.Text = advertisement.Catagory;
            comboBoxCategory.Enabled = false;
            richTextBoxAboutWork.Text = advertisement.Description;
            richTextBoxAboutWork.Enabled = false;
            comboBoxCity.Text = advertisement.City;
            comboBoxCity.Enabled = false;
            tbxSalary.Text = advertisement.Salary.ToString();
            tbxSalary.Enabled = false;
            tbxAge.Text = advertisement.Age.ToString();
            tbxAge.Enabled = false;
            comboBoxEducation.Text = advertisement.Education;
            comboBoxEducation.Enabled = false;
            comboBoxExperience.Text = advertisement.Experience;
            comboBoxExperience.Enabled = false;
            maskedPhoneNumber.Text = advertisement.PhoneNumber;
            maskedPhoneNumber.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            //ShowAllAdvertisementsForm showAllAdvertisements = new ShowAllAdvertisementsForm();
            //showAllAdvertisements.GetWorker(worker);
           
            //showAllAdvertisements.ShowDialog();
            this.Hide();


        }
    }
}
