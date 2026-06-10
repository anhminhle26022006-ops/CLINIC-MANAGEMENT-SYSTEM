using System.Collections.Generic;
using BUS.Services;
using DTO.Clinical.erm;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordBUS bus;

        public MedicalRecordController()
        {
            bus = new MedicalRecordBUS();
        }

        public List<MedicalRecordDto> GetAll()
        {
            return bus.GetAll();
        }
    }
}