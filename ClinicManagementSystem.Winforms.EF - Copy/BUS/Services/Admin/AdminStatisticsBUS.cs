using System;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class AdminStatisticsBUS : IAdminStatisticsBUS
    {
        private readonly AdminStatisticsDAL dal = new AdminStatisticsDAL();

        public AdminStatisticsDTO GetStatistics(DateTime referenceDate)
        {
            DateTime safeDate = referenceDate == DateTime.MinValue ? DateTime.Today : referenceDate.Date;
            return dal.GetStatistics(safeDate) ?? new AdminStatisticsDTO();
        }
    }
}
