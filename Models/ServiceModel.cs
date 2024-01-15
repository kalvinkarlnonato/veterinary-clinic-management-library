using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Library.Models
{
    public class ServiceModel
    {
        public int ID { get; set; }
        public int DocID { get; set; }
        public int OwnerID { get; set; }
        public int PetID { get; set; }
        public string Service { get; set; }
        public string Weight { get; set; }
        public string Temperature { get; set; }
        public string Against { get; set; }
        public string Manufacturer { get; set; }
        public string Complaint { get; set; }
        public string Findings { get; set; }
        public string Test { get; set; }
        public string LaboratoryResult { get; set; }
        public DateTime? NextVisit { get; set; }
        public DateTime DateServed { get; set; }
        public double Bills { get; set; }

    }
}
