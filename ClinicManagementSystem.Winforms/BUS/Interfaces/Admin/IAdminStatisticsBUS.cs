using System;
using DTO;

namespace BUS.Interfaces
{
    public interface IAdminStatisticsBUS
    {
        AdminStatisticsDTO GetStatistics(DateTime referenceDate);
    }
}
