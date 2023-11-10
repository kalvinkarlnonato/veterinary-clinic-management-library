using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Library.Models
{
    public class DoctorModel
    {
        /// <summary>
        /// This will return the ID of the veterinarian
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// This returns the first name of the veterinarian
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Returns the last name of the veterinarian
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Returns the gender of the veterinarian
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// Returns the cellphone number of the veterinarian
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// Returns the address of the veterinarian
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// This will return a DateTime format of veterinarian's birthday
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Returns the Last name and First name of the veterinarian
        /// </summary>
        public int Age
        {
            get { return DateTime.Now.Year - Birthday.Year; }
        }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
