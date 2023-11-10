using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Library.Models
{
    public class PetModel
    {
        /// <summary>
        /// Represents the primary ID of pet
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Represents the owner of the pet
        /// </summary>
        public int OwnerID { get; set; }
        /// <summary>
        /// Represents the pet name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the type of the pet
        /// </summary>
        public string Species { get; set; }
        /// <summary>
        /// Base on species, this is the breed of the pet
        /// </summary>
        public string Breed { get; set; }
        /// <summary>
        /// Defines the color of the pet
        /// </summary>
        public string ColorMarking { get; set; }
        /// <summary>
        /// Represents the birthday of pet
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Represents the gender of the pet
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// Represents the date of the visit
        /// </summary>
        public DateTime DateVisit { get; set; }
        /// <summary>
        /// Represents the date of next visit
        /// </summary>
        public DateTime NextVisit { get; set; }
        /// <summary>
        /// This will be the list of Checkups of this pet
        /// </summary>
        public List<CheckupModel> Checkups { get; set; } = new List<CheckupModel>();
    }
}
