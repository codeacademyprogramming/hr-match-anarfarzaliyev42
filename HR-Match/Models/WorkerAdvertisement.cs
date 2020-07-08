using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Match.Models
{
    public class WorkerAdvertisement
    {


        [Key,Column(Order = 1)]
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Key,Column(Order = 2)]
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
