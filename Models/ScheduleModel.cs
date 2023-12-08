using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCMS.Library.Models
{
    public class ScheduleModel
    {
        /// <summary>
        /// This is the identifier of schedules of the doctor
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// This will be the foreign doctors id
        /// </summary>
        public int DoctorId { get; set; }
        /// <summary>
        /// This is the schedule of the doctor set by the admin
        /// </summary>
        public DateTime Schedule { get; set; }
    }
}
