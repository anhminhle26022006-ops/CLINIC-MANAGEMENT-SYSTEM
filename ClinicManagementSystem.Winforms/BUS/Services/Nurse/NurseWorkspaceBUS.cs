using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class NurseWorkspaceBUS
    {
        private readonly NurseWorkspaceDAL dal = new NurseWorkspaceDAL();

        public List<NurseMedicalRecordDTO> SearchMedicalRecords(string term)
        {
            return dal.SearchMedicalRecords(term);
        }

        public List<NurseWorkAssignmentDTO> GetAssignments(int employeeId, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date > toDate.Date)
            {
                DateTime temp = fromDate;
                fromDate = toDate;
                toDate = temp;
            }

            return dal.GetAssignments(employeeId, fromDate.Date, toDate.Date);
        }

        public int CountOpenAssignments(int employeeId, DateTime workDate)
        {
            return GetAssignments(employeeId, workDate.Date, workDate.Date)
                .Count(a => !string.Equals(a.Status, "Done", StringComparison.OrdinalIgnoreCase)
                         && !string.Equals(a.Status, "Completed", StringComparison.OrdinalIgnoreCase)
                         && !string.Equals(a.Status, "Cancelled", StringComparison.OrdinalIgnoreCase));
        }
    }
}
