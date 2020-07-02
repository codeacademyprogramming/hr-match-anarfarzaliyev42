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
    
    public partial class EmployerMain : Form
    {
        Employer employer = null;
        public EmployerMain()
        {
            InitializeComponent();
        }
        
        public void GetEmployer(Employer employer)
        {
            this.employer = employer;
        }
        private void elanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAdvertisementForm addAdvertisement = new AddAdvertisementForm();
            addAdvertisement.GetEmployer(employer);
            addAdvertisement.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployerSearchForm employerSearch = new EmployerSearchForm();
            employerSearch.GetEmployer(employer);
            employerSearch.ShowDialog();
            
            
        }

        private void muracietlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployerAppliesForm appliesForm = new EmployerAppliesForm();
            appliesForm.GetEmployer(employer);

            appliesForm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
           
        }
    }
}
