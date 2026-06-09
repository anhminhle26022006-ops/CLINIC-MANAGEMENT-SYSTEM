using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class WorkShiftDAL : IWorkShiftDAL
    {
        public List<WorkShiftDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Shifts"))
            {
                return new List<WorkShiftDTO>();
            }

            string query = "SELECT ShiftID, Name AS ShiftName, StartTime, EndTime FROM Shifts ORDER BY StartTime";
            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        public WorkShiftDTO GetById(int shiftId)
        {
            if (!SchemaHelper.TableExists("Shifts") || shiftId <= 0)
            {
                return null;
            }

            string query = "SELECT ShiftID, Name AS ShiftName, StartTime, EndTime FROM Shifts WHERE ShiftID = @ShiftID";
            List<WorkShiftDTO> list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@ShiftID", shiftId)
            }));
            return list.Count > 0 ? list[0] : null;
        }

        public WorkShiftDTO GetByName(string shiftName)
        {
            if (!SchemaHelper.TableExists("Shifts") || string.IsNullOrWhiteSpace(shiftName))
            {
                return null;
            }

            string query = "SELECT ShiftID, Name AS ShiftName, StartTime, EndTime FROM Shifts WHERE Name = @ShiftName";
            List<WorkShiftDTO> list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@ShiftName", shiftName.Trim())
            }));
            return list.Count > 0 ? list[0] : null;
        }

        public int GetOrCreateShiftId(string shiftName)
        {
            WorkShiftDTO existing = GetByName(shiftName);
            if (existing != null)
            {
                return existing.ShiftID;
            }

            if (!SchemaHelper.TableExists("Shifts"))
            {
                return 0;
            }

            TimeSpan start;
            TimeSpan end;
            GetDefaultTime(shiftName, out start, out end);

            string query = @"
                INSERT INTO Shifts(Name, StartTime, EndTime)
                OUTPUT inserted.ShiftID
                VALUES(@ShiftName, @StartTime, @EndTime)";
            object result = DatabaseHelper.ExecuteScalar(query, new[]
            {
                new SqlParameter("@ShiftName", shiftName.Trim()),
                new SqlParameter("@StartTime", start),
                new SqlParameter("@EndTime", end)
            });
            return Convert.ToInt32(result);
        }

        public bool Exists(int shiftId)
        {
            return GetById(shiftId) != null;
        }

        private static void GetDefaultTime(string shiftName, out TimeSpan start, out TimeSpan end)
        {
            string normalized = (shiftName ?? "").Trim().ToLowerInvariant();
            if (normalized.Contains("chiều") || normalized.Contains("chieu"))
            {
                start = new TimeSpan(13, 0, 0);
                end = new TimeSpan(17, 0, 0);
                return;
            }

            if (normalized.Contains("tối") || normalized.Contains("toi"))
            {
                start = new TimeSpan(17, 30, 0);
                end = new TimeSpan(21, 0, 0);
                return;
            }

            start = new TimeSpan(7, 0, 0);
            end = new TimeSpan(11, 30, 0);
        }

        private static List<WorkShiftDTO> Map(DataTable table)
        {
            List<WorkShiftDTO> list = new List<WorkShiftDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new WorkShiftDTO
                {
                    ShiftID = Convert.ToInt32(row["ShiftID"]),
                    ShiftName = row["ShiftName"].ToString(),
                    StartTime = row["StartTime"] != DBNull.Value ? (TimeSpan)row["StartTime"] : TimeSpan.Zero,
                    EndTime = row["EndTime"] != DBNull.Value ? (TimeSpan)row["EndTime"] : TimeSpan.Zero
                });
            }
            return list;
        }
    }
}
