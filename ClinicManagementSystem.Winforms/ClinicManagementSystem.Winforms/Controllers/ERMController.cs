#nullable enable
using BUS.Services.Doctor;
using BUS.Services.ERM;
using DTO.Clinical.erm;
using System;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class ERMController
    {
        private readonly ERMService _service;

        public ERMController()
        {
            _service = new ERMService();
        }

        public Task<PatientERMDto> GetPatientERMAsync(Guid patientUuid)
        {
            return Task.Run(() =>
                _service.GetPatientERM(patientUuid));
        }
    }
}