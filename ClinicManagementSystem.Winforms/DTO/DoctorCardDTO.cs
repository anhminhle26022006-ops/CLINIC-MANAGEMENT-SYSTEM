using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoctorCardDTO
    {
        public int DoctorID { get; set; }

        public string DoctorName { get; set; }

        public string RoomCode { get; set; }

        public string ShiftName { get; set; }

        public string Status { get; set; }

        public int CurrentPatients { get; set; }

        public int MaxPatients { get; set; }
    }
}
