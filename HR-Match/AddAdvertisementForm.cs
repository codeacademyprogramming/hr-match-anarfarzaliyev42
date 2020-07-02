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
    public partial class AddAdvertisementForm : Form
    {
        Employer employer = null;
        public AddAdvertisementForm()
        {
            InitializeComponent();
        }
        public void GetEmployer(Employer employer)
        {
            this.employer = employer;
        }
        private void AddAdvertisementForm_Load(object sender, EventArgs e)
        {
            comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxExperience.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                using (HREntity db = new HREntity())
                {
                    Advertisement advertisement = new Advertisement()
                    {
                        AdvertisementName = tbxAdName.Text.Trim(),
                        CompanyName = tbxCompanyName.Text.Trim(),
                        Age = Convert.ToInt32(tbxAge.Text.Trim()),
                        Catagory = comboBoxCategory.Text,
                        City = comboBoxCity.Text,
                        Description = richTextBoxAboutWork.Text.Trim(),
                        Education = comboBoxEducation.Text,
                        Experience = comboBoxExperience.Text,
                        PhoneNumber = maskedPhoneNumber.Text,
                        Salary = Convert.ToDecimal(tbxSalary.Text)
                    };
                    
                    var currentEmployer=db.Employers.FirstOrDefault(x=>x.Id==employer.Id);
                    currentEmployer.Advertisements.Add(advertisement);
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
            List<string> inputs = new List<string>() { tbxAdName.Text.Trim(), tbxCompanyName.Text.Trim(), comboBoxCity.Text, tbxAge.Text, comboBoxEducation.Text, comboBoxExperience.Text, comboBoxCategory.Text, comboBoxCity.Text, tbxSalary.Text, maskedPhoneNumber.Text };
            bool isEmpty = inputs.TrueForAll(x => x != "");
            bool isSpace = inputs.TrueForAll(x => x != " ");
            
            int maskedInputLength = maskedPhoneNumber.Text.Trim().Length;
            string maskedInputText = maskedPhoneNumber.Text;
            bool isAllNumber= true;
           
            
            for (int i = 0; i < maskedInputText.Length; i++)
            {
                
                if (maskedInputText[i].ToString()==" "&&i!=6)
                {
                    isAllNumber = false;
                    break;
                }
            }
            
           
            return isEmpty && isSpace && isAllNumber;
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
    }
}
