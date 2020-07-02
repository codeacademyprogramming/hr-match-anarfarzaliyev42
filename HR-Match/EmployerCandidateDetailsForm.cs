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
    public partial class EmployerCandidateDetailsForm : Form
    {
        CurriculumVitae cv = null;
        public EmployerCandidateDetailsForm()
        {
            InitializeComponent();
        }
        public void GetWorkerCv(CurriculumVitae cv)
        {
            this.cv = cv;
        }
        private void EmployerCandidateDetails_Load(object sender, EventArgs e)
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
    }
}
