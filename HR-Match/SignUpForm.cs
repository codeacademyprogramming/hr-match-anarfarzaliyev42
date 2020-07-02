using HR_Match.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Match
{
    public partial class SignUpForm : Form
    {
        string randomText=null;
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<string> inputs = new List<string>() { tbxUsername.Text.Trim(), tbxEmail.Text.Trim(), comboBoxStatus.Text,tbxPassword.Text.Trim(),
                tbxRePassword.Text.Trim(),tbxRandomText.Text, };
            bool isEmpty = inputs.TrueForAll(x => x != "");
            bool isSpace = inputs.TrueForAll(x => x != " ");
           
            
            if (isEmpty && isSpace)
            {
                
                    try
                    {
                        MailAddress mailAddress = new MailAddress(tbxEmail.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Email is not correct format", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        GenerateRandomText();
                        return;
                    }
                    if (tbxPassword.Text == tbxRePassword.Text)
                    {
                        string password = tbxPassword.Text;

                        if (password.Length <= 15)
                        {
                            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
                            bool isCorrectFormat = regex.IsMatch(password);

                            if (!isCorrectFormat)
                            {
                                MessageBox.Show("Password is not in correct format, Must be: en azi bir boyuk herf olmalidir,bir reqem, bir simvol (_+-/. ve s.),maksimum uzunluq 15 simvol", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                GenerateRandomText();
                                return;
                            }
                        }

                        else
                        {
                            MessageBox.Show("Password lentgh must be less than 15", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            GenerateRandomText();
                            return;
                        }
                        if (tbxRandomText.Text == randomText)
                        {

                            using (HREntity db = new HREntity())
                            {
                                //var users = db.Users.ToList();
                                //bool isUsernameExists= users.Exists(x=>x.Username.ToLower()==tbxUsername.Text.ToLower());
                                if (comboBoxStatus.Text == "Worker")
                                {
                                    var workers = db.Workers.ToList();
                                    bool isUsernameExists = workers.Exists(x => x.Username.ToLower() == tbxUsername.Text.ToLower());
                                    if (!isUsernameExists)
                                    {
                                        //User user = new User()
                                        //{
                                        //    Username = tbxUsername.Text,
                                        //    Email = tbxEmail.Text,
                                        //    Status = comboBoxStatus.Text,
                                        //    Password = tbxPassword.Text

                                        //};
                                        Worker worker = new Worker()
                                        {
                                            Username = tbxUsername.Text,
                                            Email = tbxEmail.Text,

                                            Password = tbxPassword.Text
                                        };
                                        db.Workers.Add(worker);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        MessageBox.Show("This username already taken, please choose another", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        GenerateRandomText();
                                        return;
                                    }
                                }
                                else if (comboBoxStatus.Text == "Employer")
                                {
                                    var employers = db.Employers.ToList();
                                    bool isUsernameExists = employers.Exists(x => x.Username.ToLower() == tbxUsername.Text.ToLower());
                                    if (!isUsernameExists)
                                    {
                                        //User user = new User()
                                        //{
                                        //    Username = tbxUsername.Text,
                                        //    Email = tbxEmail.Text,
                                        //    Status = comboBoxStatus.Text,
                                        //    Password = tbxPassword.Text

                                        //};
                                        Employer employer = new Employer()
                                        {
                                            Username = tbxUsername.Text,
                                            Email = tbxEmail.Text,
                                            Password = tbxPassword.Text
                                        };
                                        db.Employers.Add(employer);
                                        db.SaveChanges();
                                    }
                                    else
                                    {
                                        MessageBox.Show("This username already taken, please choose another", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        GenerateRandomText();
                                        return;
                                    }
                                }


                            }
                            MessageBox.Show("Sign up successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Entered 4 digit char code not valid", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords not same", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        GenerateRandomText();
                    }
               
               
            }
            else
            {
                MessageBox.Show("Cannot be empty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GenerateRandomText();
            }

            randomText = RandomString(4);
            lblRandomText.Text = randomText;

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            //tbxPassword.PasswordChar = '*';
            //tbxRePassword.PasswordChar = '*';
            GenerateRandomText();

            
        }
        //Random generator---------------------
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void GenerateRandomText()
        {
            randomText = RandomString(4);
            lblRandomText.Text = randomText;
        }

       

        private void tbxEmail_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("asdasdas");
        }
    }
}
