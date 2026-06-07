using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class PatientBUS
    {
        private readonly PatientDAL dal = new PatientDAL();

        public List<PatientDTO> GetList()
        {
            return dal.GetAll();
        }

        public List<PatientDTO> FilterList(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return GetList();
            }
            return dal.Search(term.Trim());
        }

        public bool CreatePatient(PatientDTO patient)
        {
            if (patient == null) return false;
            if (string.IsNullOrWhiteSpace(patient.PatientCode) || string.IsNullOrWhiteSpace(patient.Name))
            {
                throw new ArgumentException("Mã bệnh nhân và Tên bệnh nhân là bắt buộc.");
            }
            return dal.Add(patient) > 0;
        }
    }
}
