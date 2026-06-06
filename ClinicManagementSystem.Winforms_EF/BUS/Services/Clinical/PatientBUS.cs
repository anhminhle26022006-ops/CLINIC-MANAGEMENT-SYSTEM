using System;
using System.Collections.Generic;
using CMS.Core.Utils;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class PatientBUS
    {
        private readonly PatientDAL patientDAL = new();
        private readonly InsuranceDAL insuranceDAL = new();

        public List<PatientDTO> GetList()
        {
            return patientDAL.GetAll();
        }

        public List<PatientDTO> FilterList(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return GetList();

            return patientDAL.Search(term.Trim());
        }

        public bool CreatePatient(
            PatientDTO patient,
            PatientInsuranceDTO insurance)
        {
            int patientId = patientDAL.Add(patient);

            if (patientId <= 0)
                return false;

            insurance.PatientID = patientId;

            return insuranceDAL.Add(insurance);
        }

        public PatientDTO GetById(int id)
        {
            return patientDAL.GetById(id);
        }

        public bool UpdatePatient(PatientDTO patient)
        {
            if (patient == null)
                return false;

            if (string.IsNullOrWhiteSpace(patient.Name))
            {
                throw new ArgumentException(
                    "Tên bệnh nhân không được để trống.");
            }

            return patientDAL.Update(patient);
        }

        public int CountPatients()
        {
            return patientDAL.CountPatients();
        }

        public string GenerateNewPatientCode()
        {
            int nextId = patientDAL.GetNextPatientId();

            return IdGenerator.GeneratePatientCode(nextId);
        }
    }
}
