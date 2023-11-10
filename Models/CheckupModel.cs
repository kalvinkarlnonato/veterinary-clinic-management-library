using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Library.Models
{
    public class CheckupModel
    {

        /// <summary>
        /// Represents the primary ID of checkup
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Represents the pet who need checkup
        /// </summary>
        public int PetID { get; set; }
        /// <summary>
        /// Represents the weight of the pet
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// Represents the temperature of the pet
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// Represents the Test conducted for the pet
        /// </summary>
        public string Test { get; set; }
        /// <summary>
        /// Represents the Complaint of the pet
        /// </summary>
        public string Complaint { get; set; }
        /// <summary>
        /// Represents the Findings of the procedure
        /// </summary>
        public string Findings { get; set; }
        /// <summary>
        /// Represents the result of the
        /// </summary>
        public string Result { get; set; }
        ///// <summary>
        ///// Represents the bill of the visit
        ///// </summary>
        public BillModel Bill { get; set; }
        public string WTT
        {
            get
            {
                return $"{Weight}/{Temperature}";
            }
        }

    }
}
