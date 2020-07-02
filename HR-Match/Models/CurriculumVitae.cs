using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Match.Models
{
    public class CurriculumVitae
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        public string Gender { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Education { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Experience { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Catagory { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string City { get; set; }
        
        public decimal MinSalary { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public int WorkerId { get; set; }
      


    }
}
