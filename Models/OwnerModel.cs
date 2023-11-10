using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Library.Models
{
    public class OwnerModel
    {
        /// <summary>
        /// Represents the primary ID of clients
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Represents the first name of the costumer
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Represents the last name of the costumer
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the costumer home address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Represents the cellphone number to contact the costumer
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// Represents the date of the registration
        /// </summary>
        public DateTime DateRegistered { get; set; }
        /// <summary>
        /// Defines all pets of the costumer
        /// </summary>
        public List<PetModel> Pets { get; set; } = new List<PetModel>();
        /// <summary>
        /// Returns the full name of client
        /// </summary>
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        /// <summary>
        /// Returns pet species only in comma seperated
        /// </summary>
        public string PetSpecies
        {
            get { return string.Join(",", Pets.Select(p => p.Species)); }
        }
    }
}
