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
    public partial class AddCVForm : Form
    {

        Worker worker = null;
        public AddCVForm()
        {
            InitializeComponent();
        }
        public void GetUser(Worker worker)
        {
            this.worker = worker;
        }
        private void AddCVForm_Load(object sender, EventArgs e)
        {
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxExperience.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            
            using (HREntity db = new HREntity())
            {
                var curriculumVitaes = db.CurriculumVitaes.ToList();
              
                CurriculumVitae cv = curriculumVitaes.FirstOrDefault(x=>x.Id==worker.Id);
                if (cv!=null)
                {
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                    tbxName.Text = cv.Name;
                    tbxSurname.Text = cv.Surname;
                    tbxAge.Text = cv.Age.ToString();
                    tbxSalary.Text = cv.MinSalary.ToString();
                    comboBoxCategory.Text = cv.Catagory;
                    comboBoxCity.Text = cv.City;
                    comboBoxEducation.Text = cv.Education;
                    comboBoxExperience.Text = cv.Experience;
                    comboBoxGender.Text = cv.Gender;
                    maskedPhoneNumber.Text = cv.PhoneNumber;
                }
                else
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = false;
                }
            }
         
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
           
            if (ValidateInputs())
            {
                using (HREntity db = new HREntity())
                {
                    CurriculumVitae cv = new CurriculumVitae()
                    {
                        Name=tbxName.Text.Trim(),
                        Surname=tbxSurname.Text.Trim(),
                        Gender=comboBoxGender.Text,
                        Age=Convert.ToInt32(tbxAge.Text.Trim()),
                        Education=comboBoxEducation.Text,
                        Experience=comboBoxExperience.Text,
                        Catagory=comboBoxCategory.Text,
                        City=comboBoxCity.Text,
                        MinSalary=Convert.ToDecimal(tbxSalary.Text),
                        PhoneNumber=maskedPhoneNumber.Text,
    
                    };

                    db.Workers.Find(worker.Id).CurriculumVitae = cv;
                    db.SaveChanges();

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot be empty");
            }


        }

        private void tbxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void tbxSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (ValidateInputs())
            {
                using (HREntity db = new HREntity())
                {
                    var cv = db.CurriculumVitaes.FirstOrDefault(x=>x.Id==worker.Id);
                    cv.Name = tbxName.Text;
                    cv.Surname = tbxSurname.Text;
                    cv.Age = Convert.ToInt32(tbxAge.Text);
                    cv.MinSalary = Convert.ToDecimal(tbxSalary.Text);
                    cv.Catagory = comboBoxCategory.Text;
                    cv.City = comboBoxCity.Text;
                    cv.Education = comboBoxEducation.Text;
                    cv.Experience = comboBoxExperience.Text;
                    cv.Gender = comboBoxGender.Text;
                    cv.PhoneNumber = maskedPhoneNumber.Text;
                    db.SaveChanges();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Cannot be empty");
            }
          

        }
        public bool ValidateInputs()
        {
            List<string> inputs = new List<string>() { tbxName.Text.Trim(), tbxSurname.Text.Trim(), comboBoxGender.Text, tbxAge.Text, comboBoxEducation.Text, comboBoxExperience.Text, comboBoxCategory.Text, comboBoxCity.Text, tbxSalary.Text, maskedPhoneNumber.Text };
            bool isEmpty = inputs.TrueForAll(x => x != "");
            bool isSpace = inputs.TrueForAll(x => x != " ");
            int maskedInputLength = maskedPhoneNumber.Text.Trim().Length;
            string maskedInputText = maskedPhoneNumber.Text;
            bool isAllNumber = true;
            for (int i = 0; i < maskedInputText.Length; i++)
            {

                if (maskedInputText[i].ToString() == " " && i != 6)
                {
                    isAllNumber = false;
                    break;
                }
            }
            return isEmpty && isSpace && isAllNumber;
        }
    }
}
