using System.Collections.Generic;
using BUS.Services;
using DTO.Clinical.erm;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordBUS bus = new();

        public List<MedicalRecordDto> GetAll()
        {
            return bus.GetAllErmRecords();
        }
    }
}
