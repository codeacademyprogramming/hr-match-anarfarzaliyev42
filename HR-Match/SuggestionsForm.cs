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
    public partial class SuggestionsForm : Form
    {
        Worker worker = null;
        public SuggestionsForm()
        {
            InitializeComponent();
        }
        public void GetWorker(Worker worker)
        {
            this.worker = worker;
        }
        private void SuggestionsForm_Load(object sender, EventArgs e)
        {
            using (HREntity db = new HREntity())
            {
                var advertisements = db.Advertisements.ToList();
                var cv = db.CurriculumVitaes.FirstOrDefault(x=>x.Id==worker.Id);
                var result = (
                    from a in advertisements
                    where
                    a.Catagory==cv.Catagory||
                    a.City==cv.City||
                    a.Education==cv.Education||
                    a.Experience==cv.Experience
                    select a
                    ).ToList();
                //, City = cv.City, Education = cv.Education, Experience = cv.Education
                if (result.Count != 0)
                {
                    var adColumns = (from a in result
                                     select new { a.AdvertisementName, a.CompanyName, a.Catagory, a.Education, a.Experience, a.Salary }).ToList();
                    dataGridView1.DataSource = adColumns;

                }
                else
                {
                    MessageBox.Show("Advertisement not found");
                }
               

            }
        }
    }
}
