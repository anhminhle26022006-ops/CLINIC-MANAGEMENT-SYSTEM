using DTO;
using DAL;

namespace BUS
{
    public class VitalSignsBUS
    {
        private VitalSignsDAL vitalDAL =
            new VitalSignsDAL();

        public bool SaveVitalSigns(
            VitalSignsDTO dto)
        {
            ValidateVitalSigns(dto);

            return vitalDAL.InsertVitalSigns(
                dto);
        }

        public int? GetLatestEncounterIdByPatient(int patientId)
        {
            if (patientId <= 0)
            {
                return null;
            }

            return vitalDAL.GetLatestEncounterIdByPatient(patientId);
        }

        private void ValidateVitalSigns(
            VitalSignsDTO dto)
        {
            if (dto.EncounterID <= 0)
            {
                throw new Exception(
                    "Encounter is required.");
            }

            if (dto.Temperature < 35 ||
                dto.Temperature > 42)
            {
                throw new Exception(
                    "Temperature invalid.");
            }

            if (dto.SPO2 < 0 ||
                dto.SPO2 > 100)
            {
                throw new Exception(
                    "SPO2 invalid.");
            }

            if (dto.HeartRate < 30 ||
                dto.HeartRate > 220)
            {
                throw new Exception(
                    "Heart rate invalid.");
            }

            if (dto.Weight <= 0)
            {
                throw new Exception(
                    "Weight invalid.");
            }
        }
    }
}
