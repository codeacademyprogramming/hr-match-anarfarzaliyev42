using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Match.Models
{
   public  class Employer
    {

        public Employer()
        {
            Advertisements = new List<Advertisement>();
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
        //[Column(TypeName = "nvarchar")]
        //[MaxLength(50)]
        //public string Status { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Password { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
