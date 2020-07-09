using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Match.Models
{
   public class Worker
    {

        public Worker()
        {
            WorkerAdvertisements = new List<WorkerAdvertisement>();
        }
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Email { get; set; }
       
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Password { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
        public ICollection<WorkerAdvertisement> WorkerAdvertisements { get; set; }
    }
}
