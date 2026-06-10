using BUS.Interfaces;
using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using DTO;
using System;

namespace BUS.Services
{
    public class AdminStatisticsBUS : IAdminStatisticsBUS
    {
        private readonly AdminStatisticsDAL _dal;

        // Constructor nhận CMSDbContext
        public AdminStatisticsBUS(CMSDbContext context)
        {
            _dal = new AdminStatisticsDAL(context);
        }

        public AdminStatisticsDTO GetStatistics(DateTime referenceDate)
        {
            DateTime safeDate = referenceDate == DateTime.MinValue ? DateTime.Today : referenceDate.Date;
            return _dal.GetStatistics(safeDate) ?? new AdminStatisticsDTO();
        }
    }
}