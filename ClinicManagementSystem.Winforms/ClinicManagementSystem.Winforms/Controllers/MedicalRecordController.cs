using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Services.Doctor;
using DTO.Clinical.erm;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class MedicalRecordController
    {
        private readonly MedicalHistoryService _service;

        public MedicalRecordController()
        {
            _service = new MedicalHistoryService();
        }

        public List<MedicalRecordDto> GetAll()
        {
            return _service.GetAll();
        }
    }
}
