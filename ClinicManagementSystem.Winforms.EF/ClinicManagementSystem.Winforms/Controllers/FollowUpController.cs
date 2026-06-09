using System.Collections.Generic;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class FollowUpController
    {
        private readonly FollowUpBUS followUpBus =
            new();

        private readonly EncounterBUS encounterBus =
            new();

        private readonly Patient_RecepBUS patientBus =
            new();

        private readonly Employee_RecepBUS employeeBus =
            new();

        private readonly MedicalRecordBUS medicalRecordBus =
            new();

        public List<FollowUpCardDTO>
            GetProcessingFollowUps()
        {
            var followUps =
                followUpBus
                .GetProcessingFollowUps();

            return BuildCardData(
                followUps);
        }

        public List<FollowUpCardDTO>
            GetCompletedFollowUps()
        {
            var followUps =
                followUpBus
                .GetCompletedFollowUps();

            return BuildCardData(
                followUps);
        }

        private List<FollowUpCardDTO>
            BuildCardData(
                List<FollowUpDTO> followUps)
        {
            List<FollowUpCardDTO> result =
                new();

            foreach (var followUp in followUps)
            {
                var encounter =
                    encounterBus.GetById(
                        followUp.EncounterID);

                if (encounter == null)
                    continue;

                var patient =
                    patientBus.GetById(
                        encounter.PatientID);

                var doctor =
                    employeeBus.GetById(
                        encounter.DoctorID);

                var record =
                    medicalRecordBus
                    .GetByEncounterId(
                        encounter.EncounterID);

                result.Add(
                    new FollowUpCardDTO
                    {
                        FollowUpID =
                            followUp.FollowUpID,

                        FollowUpDate =
                            followUp.FollowUpDate,

                        Status =
                            followUp.Status,

                        PatientCode =
                            patient?.PatientCode,

                        PatientName =
                            patient?.Name,

                        DoctorName =
                            doctor?.FullName,

                        Diagnosis =
                            record?.Diagnosis
                    });
            }

            return result;
        }

        public bool UpdateStatus(
    int followUpId,
    string status)
        {
            return followUpBus
                .UpdateStatus(
                    followUpId,
                    status);
        }
    }
}
