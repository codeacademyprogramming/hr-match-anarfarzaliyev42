using HR_Match.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Match
{
    class HREntity:DbContext
    {
        public HREntity()
            :base("name=DefaultConnection")
        {

        }

        //public DbSet<User> Users { get; set; }
        public DbSet<WorkerAdvertisement> WorkerAdvertisemets { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
    }
}
