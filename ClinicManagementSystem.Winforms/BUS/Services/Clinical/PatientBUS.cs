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
    }
}