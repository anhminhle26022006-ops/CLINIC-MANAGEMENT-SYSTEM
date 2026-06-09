using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class ShiftInfoDTO
    {
        public string ShiftName { get; set; }

        public string DepartmentName { get; set; }

        public string RoomCode { get; set; }

        public bool IsOnDuty { get; set; }
    }
}
