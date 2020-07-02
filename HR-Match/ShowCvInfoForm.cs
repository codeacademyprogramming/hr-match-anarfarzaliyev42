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
    public partial class ShowCvInfoForm : Form
    {
        Worker worker = null;
        public ShowCvInfoForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }
        private void ShowCvInfoForm_Load(object sender, EventArgs e)
        {
            using(HREntity db=new HREntity())
            {
                var cv = db.CurriculumVitaes.FirstOrDefault(x=>x.WorkerId==worker.Id);
                if (cv != null)
                {
                    tbxName.Text = cv.Name;
                    tbxName.Enabled = false;
                    tbxSurname.Text = cv.Surname;
                    tbxSurname.Enabled = false;
                    comboBoxGender.Text = cv.Gender;
                    comboBoxGender.Enabled = false;
                    tbxAge.Text = cv.Age.ToString();
                    tbxAge.Enabled = false;
                    comboBoxEducation.Text = cv.Education;
                    comboBoxEducation.Enabled = false;
                    comboBoxExperience.Text = cv.Experience;
                    comboBoxExperience.Enabled = false;
                    comboBoxCategory.Text = cv.Catagory;
                    comboBoxCategory.Enabled = false;
                    comboBoxCity.Text = cv.City;
                    comboBoxCity.Enabled = false;
                    tbxSalary.Text = cv.MinSalary.ToString();
                    tbxSalary.Enabled = false;
                    maskedPhoneNumber.Text = cv.PhoneNumber;
                    maskedPhoneNumber.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Not found, please add cv before");
                }
            }
        }
    }
}
