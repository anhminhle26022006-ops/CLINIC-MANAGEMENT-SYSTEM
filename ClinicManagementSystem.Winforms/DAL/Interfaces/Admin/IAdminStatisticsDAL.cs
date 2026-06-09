using System;
using DTO;

namespace DAL.Interfaces
{
    public interface IAdminStatisticsDAL
    {
        AdminStatisticsDTO GetStatistics(DateTime referenceDate);
    }
}
