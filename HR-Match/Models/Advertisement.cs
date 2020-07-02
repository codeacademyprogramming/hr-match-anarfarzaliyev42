using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR_Match.Models
{
    public class Advertisement
    {

        public Advertisement()
        {
            Workers = new List<Worker>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string AdvertisementName { get; set; }
       
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Catagory { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string City { get; set; }
       
        public decimal Salary { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Education { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string Experience { get; set; }
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        public ICollection<Worker> Workers { get; set; }


    }
}
