#nullable enable
using System;
using System.Threading.Tasks;
using BUS.Services.ERM;
using DTO.Clinical.erm;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class ERMController
    {
        private readonly ERMBus _bus;

        public ERMController(ERMBus bus) => _bus = bus;

        public Task<PatientERMDto?> GetPatientERMAsync(Guid uuid)
        {
            // Forward to your existing bus/service. Keep name async to indicate async work.
            return _bus.GetPatientERM(uuid);
        }
    }
}