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
   
    public partial class SignInForm : Form
    {
       
        public SignInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> inputs = new List<string>() { tbxUsername.Text.Trim(),tbxPassword.Text.Trim(),comboBoxLoginAs.Text };
            bool isEmpty = inputs.TrueForAll(x => x != "");
            bool isSpace = inputs.TrueForAll(x => x != " ");

            if (isEmpty && isSpace)
            {
                using (HREntity db=new HREntity())
                {
                    if (comboBoxLoginAs.Text == "Worker")
                    {
                        Worker worker = db.Workers.FirstOrDefault(x => x.Username == tbxUsername.Text && x.Password == tbxPassword.Text);
                        if (worker != null)
                        {
                            WorkerMain workerMain = new WorkerMain();
                            workerMain.GetUser(worker);
                            workerMain.ShowDialog();
                           
                        }
                        else
                        {
                            MessageBox.Show("User not Found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else if (comboBoxLoginAs.Text == "Employer")
                    {
                        Employer employer = db.Employers.FirstOrDefault(x => x.Username == tbxUsername.Text && x.Password == tbxPassword.Text);
                        if (employer != null)
                        {
                            EmployerMain employerMain = new EmployerMain();
                            employerMain.GetEmployer(employer);
                            employerMain.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("User not Found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Cannot be empty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           
            }
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            comboBoxLoginAs.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
