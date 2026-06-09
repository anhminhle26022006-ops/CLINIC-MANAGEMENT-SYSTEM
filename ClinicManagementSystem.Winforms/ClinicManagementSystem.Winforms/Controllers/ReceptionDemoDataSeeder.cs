using System;
using DAL.DataContext;

namespace ClinicManagementSystem.Winforms.Controllers
{
    internal static class ReceptionDemoDataSeeder
    {
        private static bool seeded;

        public static void EnsureSeeded()
        {
            if (seeded)
            {
                return;
            }

            try
            {
                DatabaseHelper.ExecuteNonQuery(Sql);
                seeded = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Reception demo seed failed: " + ex);
            }
        }

        private const string Sql = @"
;WITH NextDays AS
(
    SELECT TOP (14) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS DayOffset
    FROM sys.all_objects
),
DoctorRooms AS
(
    SELECT
        e.EmployeeID,
        e.DepartmentID,
        room.RoomID
    FROM Employees e
    INNER JOIN Roles role ON e.RoleID = role.RoleID
    CROSS APPLY
    (
        SELECT TOP 1 r.RoomID
        FROM Rooms r
        WHERE r.DepartmentID = e.DepartmentID
          AND ISNULL(r.Status, 'Available') = 'Available'
        ORDER BY r.RoomCode
    ) room
    WHERE role.RoleName = 'Doctor'
      AND ISNULL(e.Status, N'Active') <> N'Inactive'
)
INSERT INTO DoctorSchedules(DoctorID, WorkDate, StartTime, EndTime, RoomID)
SELECT
    dr.EmployeeID,
    DATEADD(DAY, nd.DayOffset, CAST(GETDATE() AS DATE)),
    CAST('08:00' AS time),
    CAST('17:30' AS time),
    dr.RoomID
FROM DoctorRooms dr
CROSS JOIN NextDays nd
WHERE NOT EXISTS
(
    SELECT 1
    FROM DoctorSchedules ds
    WHERE ds.DoctorID = dr.EmployeeID
      AND CAST(ds.WorkDate AS date) = DATEADD(DAY, nd.DayOffset, CAST(GETDATE() AS DATE))
);

IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientCode = 'BNTESTPAY01')
BEGIN
    INSERT INTO Patients(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
    VALUES ('BNTESTPAY01', N'Test Thanh Toán PayOS 01', N'Nam', '1994-05-12', '0909000001', N'TP.HCM', 'O+', N'Không có');
END;

IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientCode = 'BNTESTPAY02')
BEGIN
    INSERT INTO Patients(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
    VALUES ('BNTESTPAY02', N'Test Thanh Toán PayOS 02', N'Nữ', '1997-09-21', '0909000002', N'TP.HCM', 'A+', N'Không có');
END;

IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientCode = 'BNTESTFU01')
BEGIN
    INSERT INTO Patients(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
    VALUES ('BNTESTFU01', N'Test Nhắc Tái Khám 01', N'Nữ', '1989-02-18', '0909000003', N'TP.HCM', 'B+', N'Không có');
END;

DECLARE @DoctorId INT = (SELECT TOP 1 e.EmployeeID FROM Employees e INNER JOIN Roles r ON e.RoleID = r.RoleID WHERE r.RoleName = 'Doctor' ORDER BY e.EmployeeID);
DECLARE @DepartmentId INT = (SELECT DepartmentID FROM Employees WHERE EmployeeID = @DoctorId);
DECLARE @RoomId INT = (SELECT TOP 1 RoomID FROM Rooms WHERE DepartmentID = @DepartmentId ORDER BY RoomID);

IF @DoctorId IS NOT NULL AND @DepartmentId IS NOT NULL AND @RoomId IS NOT NULL
BEGIN
    DECLARE @PayPatient1 INT = (SELECT PatientID FROM Patients WHERE PatientCode = 'BNTESTPAY01');
    DECLARE @PayPatient2 INT = (SELECT PatientID FROM Patients WHERE PatientCode = 'BNTESTPAY02');
    DECLARE @FollowPatient INT = (SELECT PatientID FROM Patients WHERE PatientCode = 'BNTESTFU01');

    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE PatientID = @PayPatient1 AND CAST(AppointmentDate AS date) = CAST(GETDATE() AS date))
    BEGIN
        INSERT INTO Appointments(PatientID, DoctorID, DepartmentID, RoomID, AppointmentDate, Status)
        VALUES (@PayPatient1, @DoctorId, @DepartmentId, @RoomId, DATEADD(HOUR, 9, CAST(CAST(GETDATE() AS date) AS datetime)), 'Completed');
    END;

    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE PatientID = @PayPatient2 AND CAST(AppointmentDate AS date) = CAST(GETDATE() AS date))
    BEGIN
        INSERT INTO Appointments(PatientID, DoctorID, DepartmentID, RoomID, AppointmentDate, Status)
        VALUES (@PayPatient2, @DoctorId, @DepartmentId, @RoomId, DATEADD(MINUTE, 30, DATEADD(HOUR, 10, CAST(CAST(GETDATE() AS date) AS datetime))), 'Completed');
    END;

    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE PatientID = @FollowPatient AND CAST(AppointmentDate AS date) = DATEADD(DAY, -7, CAST(GETDATE() AS date)))
    BEGIN
        INSERT INTO Appointments(PatientID, DoctorID, DepartmentID, RoomID, AppointmentDate, Status)
        VALUES (@FollowPatient, @DoctorId, @DepartmentId, @RoomId, DATEADD(DAY, -7, DATEADD(HOUR, 8, CAST(CAST(GETDATE() AS date) AS datetime))), 'Completed');
    END;

    INSERT INTO Encounters(AppointmentID, PatientID, DoctorID, StartTime, EndTime, Status)
    SELECT a.AppointmentID, a.PatientID, a.DoctorID, a.AppointmentDate, DATEADD(MINUTE, 25, a.AppointmentDate), 'Completed'
    FROM Appointments a
    WHERE a.PatientID IN (@PayPatient1, @PayPatient2, @FollowPatient)
      AND NOT EXISTS (SELECT 1 FROM Encounters e WHERE e.AppointmentID = a.AppointmentID);

    INSERT INTO MedicalRecords(EncounterID, ChiefComplaint, Symptoms, Diagnosis, ICDCode, Conclusion, Notes)
    SELECT e.EncounterID, N'Khám demo', N'Sốt nhẹ, mệt mỏi', N'Viêm hô hấp trên', 'J06.9', N'Theo dõi và tái khám', N'Dữ liệu demo lễ tân'
    FROM Encounters e
    WHERE e.PatientID IN (@PayPatient1, @PayPatient2, @FollowPatient)
      AND NOT EXISTS (SELECT 1 FROM MedicalRecords mr WHERE mr.EncounterID = e.EncounterID);

    INSERT INTO Payments(EncounterID, PatientID, Amount, Method, Status, PaidAt)
    SELECT e.EncounterID, e.PatientID,
           CASE WHEN e.PatientID = @PayPatient1 THEN 450000 ELSE 680000 END,
           '', 'Pending', NULL
    FROM Encounters e
    WHERE e.PatientID IN (@PayPatient1, @PayPatient2)
      AND NOT EXISTS (SELECT 1 FROM Payments p WHERE p.EncounterID = e.EncounterID);

    INSERT INTO PaymentDetails(PaymentID, ItemType, ItemID, Description, Quantity, UnitPrice, Amount)
    SELECT p.PaymentID, N'Exam', NULL, N'Phí khám chuyên khoa', 1, 250000, 250000
    FROM Payments p
    WHERE p.PatientID IN (@PayPatient1, @PayPatient2)
      AND NOT EXISTS (SELECT 1 FROM PaymentDetails pd WHERE pd.PaymentID = p.PaymentID);

    INSERT INTO PaymentDetails(PaymentID, ItemType, ItemID, Description, Quantity, UnitPrice, Amount)
    SELECT p.PaymentID, N'Service', NULL, N'Dịch vụ xét nghiệm demo', 1, p.Amount - 250000, p.Amount - 250000
    FROM Payments p
    WHERE p.PatientID IN (@PayPatient1, @PayPatient2)
      AND p.Amount > 250000
      AND (SELECT COUNT(*) FROM PaymentDetails pd WHERE pd.PaymentID = p.PaymentID) < 2;

    INSERT INTO FollowUps(EncounterID, FollowUpDate, Status)
    SELECT e.EncounterID, DATEADD(DAY, 3, CAST(GETDATE() AS date)), 'Upcoming'
    FROM Encounters e
    WHERE e.PatientID = @FollowPatient
      AND NOT EXISTS (SELECT 1 FROM FollowUps f WHERE f.EncounterID = e.EncounterID);

    INSERT INTO FollowUps(EncounterID, FollowUpDate, Status)
    SELECT TOP 1 e.EncounterID, DATEADD(DAY, -1, CAST(GETDATE() AS date)), 'Overdue'
    FROM Encounters e
    WHERE e.PatientID = @PayPatient1
      AND NOT EXISTS (SELECT 1 FROM FollowUps f WHERE f.EncounterID = e.EncounterID);

    ;WITH DemoFollowUpPatients AS
    (
        SELECT *
        FROM (VALUES
            ('BNTESTFU02', N'Test Tái Khám 02', N'Nam', '1991-01-12', '0909000102', 1, 'Upcoming', N'Viêm họng cấp'),
            ('BNTESTFU03', N'Test Tái Khám 03', N'Nữ', '1988-03-24', '0909000103', 2, 'Upcoming', N'Đau dạ dày'),
            ('BNTESTFU04', N'Test Tái Khám 04', N'Nam', '1979-07-08', '0909000104', 4, 'Upcoming', N'Tăng huyết áp'),
            ('BNTESTFU05', N'Test Tái Khám 05', N'Nữ', '1995-11-18', '0909000105', 6, 'Upcoming', N'Viêm da cơ địa'),
            ('BNTESTFU06', N'Test Tái Khám 06', N'Nam', '1984-04-30', '0909000106', -1, 'Overdue', N'Đau lưng'),
            ('BNTESTFU07', N'Test Tái Khám 07', N'Nữ', '1992-06-14', '0909000107', -2, 'Overdue', N'Viêm xoang'),
            ('BNTESTFU08', N'Test Tái Khám 08', N'Nam', '1976-09-03', '0909000108', -4, 'Overdue', N'Rối loạn lipid máu'),
            ('BNTESTFU09', N'Test Tái Khám 09', N'Nữ', '1986-12-26', '0909000109', -5, 'Overdue', N'Đái tháo đường type 2'),
            ('BNTESTFU10', N'Test Tái Khám 10', N'Nam', '1998-02-07', '0909000110', -3, 'Reminded', N'Viêm phế quản'),
            ('BNTESTFU11', N'Test Tái Khám 11', N'Nữ', '1990-10-11', '0909000111', -6, 'Reminded', N'Thiếu máu nhẹ'),
            ('BNTESTFU12', N'Test Tái Khám 12', N'Nam', '1981-05-19', '0909000112', -8, 'Completed', N'Sỏi thận'),
            ('BNTESTFU13', N'Test Tái Khám 13', N'Nữ', '1974-08-22', '0909000113', -9, 'Completed', N'Đục thủy tinh thể'),
            ('BNTESTFU14', N'Test Tái Khám 14', N'Nam', '1993-01-29', '0909000114', 3, 'Upcoming', N'Viêm amidan'),
            ('BNTESTFU15', N'Test Tái Khám 15', N'Nữ', '1987-07-17', '0909000115', -7, 'Reminded', N'Đau nửa đầu')
        ) v(PatientCode, FullName, Gender, DOB, Phone, FollowOffset, FollowStatus, Diagnosis)
    )
    INSERT INTO Patients(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
    SELECT PatientCode, FullName, Gender, DOB, Phone, N'TP.HCM', 'O+', N'Không có'
    FROM DemoFollowUpPatients dp
    WHERE NOT EXISTS (SELECT 1 FROM Patients p WHERE p.PatientCode = dp.PatientCode);

    ;WITH DemoFollowUpPatients AS
    (
        SELECT ROW_NUMBER() OVER (ORDER BY PatientCode) AS SortNo, *
        FROM (VALUES
            ('BNTESTFU02', 1, 'Upcoming', N'Viêm họng cấp'),
            ('BNTESTFU03', 2, 'Upcoming', N'Đau dạ dày'),
            ('BNTESTFU04', 4, 'Upcoming', N'Tăng huyết áp'),
            ('BNTESTFU05', 6, 'Upcoming', N'Viêm da cơ địa'),
            ('BNTESTFU06', -1, 'Overdue', N'Đau lưng'),
            ('BNTESTFU07', -2, 'Overdue', N'Viêm xoang'),
            ('BNTESTFU08', -4, 'Overdue', N'Rối loạn lipid máu'),
            ('BNTESTFU09', -5, 'Overdue', N'Đái tháo đường type 2'),
            ('BNTESTFU10', -3, 'Reminded', N'Viêm phế quản'),
            ('BNTESTFU11', -6, 'Reminded', N'Thiếu máu nhẹ'),
            ('BNTESTFU12', -8, 'Completed', N'Sỏi thận'),
            ('BNTESTFU13', -9, 'Completed', N'Đục thủy tinh thể'),
            ('BNTESTFU14', 3, 'Upcoming', N'Viêm amidan'),
            ('BNTESTFU15', -7, 'Reminded', N'Đau nửa đầu')
        ) v(PatientCode, FollowOffset, FollowStatus, Diagnosis)
    )
    INSERT INTO Appointments(PatientID, DoctorID, DepartmentID, RoomID, AppointmentDate, Status)
    SELECT p.PatientID,
           @DoctorId,
           @DepartmentId,
           @RoomId,
           DATEADD(MINUTE, dp.SortNo * 17, DATEADD(DAY, -10, DATEADD(HOUR, 8, CAST(CAST(GETDATE() AS date) AS datetime)))),
           'Completed'
    FROM DemoFollowUpPatients dp
    INNER JOIN Patients p ON p.PatientCode = dp.PatientCode
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM Appointments a
        WHERE a.PatientID = p.PatientID
          AND a.DoctorID = @DoctorId
          AND a.Status = 'Completed'
    );

    ;WITH DemoFollowUpPatients AS
    (
        SELECT PatientCode
        FROM (VALUES
            ('BNTESTFU02'), ('BNTESTFU03'), ('BNTESTFU04'), ('BNTESTFU05'), ('BNTESTFU06'),
            ('BNTESTFU07'), ('BNTESTFU08'), ('BNTESTFU09'), ('BNTESTFU10'), ('BNTESTFU11'),
            ('BNTESTFU12'), ('BNTESTFU13'), ('BNTESTFU14'), ('BNTESTFU15')
        ) v(PatientCode)
    )
    INSERT INTO Encounters(AppointmentID, PatientID, DoctorID, StartTime, EndTime, Status)
    SELECT a.AppointmentID, a.PatientID, a.DoctorID, a.AppointmentDate, DATEADD(MINUTE, 25, a.AppointmentDate), 'Completed'
    FROM DemoFollowUpPatients dp
    INNER JOIN Patients p ON p.PatientCode = dp.PatientCode
    INNER JOIN Appointments a ON a.PatientID = p.PatientID AND a.DoctorID = @DoctorId
    WHERE NOT EXISTS (SELECT 1 FROM Encounters e WHERE e.AppointmentID = a.AppointmentID);

    ;WITH DemoFollowUpPatients AS
    (
        SELECT *
        FROM (VALUES
            ('BNTESTFU02', N'Viêm họng cấp'),
            ('BNTESTFU03', N'Đau dạ dày'),
            ('BNTESTFU04', N'Tăng huyết áp'),
            ('BNTESTFU05', N'Viêm da cơ địa'),
            ('BNTESTFU06', N'Đau lưng'),
            ('BNTESTFU07', N'Viêm xoang'),
            ('BNTESTFU08', N'Rối loạn lipid máu'),
            ('BNTESTFU09', N'Đái tháo đường type 2'),
            ('BNTESTFU10', N'Viêm phế quản'),
            ('BNTESTFU11', N'Thiếu máu nhẹ'),
            ('BNTESTFU12', N'Sỏi thận'),
            ('BNTESTFU13', N'Đục thủy tinh thể'),
            ('BNTESTFU14', N'Viêm amidan'),
            ('BNTESTFU15', N'Đau nửa đầu')
        ) v(PatientCode, Diagnosis)
    )
    INSERT INTO MedicalRecords(EncounterID, ChiefComplaint, Symptoms, Diagnosis, ICDCode, Conclusion, Notes)
    SELECT e.EncounterID, N'Tái khám demo', N'Theo dõi sau điều trị', dp.Diagnosis, 'Z09', N'Hẹn tái khám', N'Dữ liệu demo nhắc lịch tái khám'
    FROM DemoFollowUpPatients dp
    INNER JOIN Patients p ON p.PatientCode = dp.PatientCode
    INNER JOIN Encounters e ON e.PatientID = p.PatientID AND e.DoctorID = @DoctorId
    WHERE NOT EXISTS (SELECT 1 FROM MedicalRecords mr WHERE mr.EncounterID = e.EncounterID);

    ;WITH DemoFollowUpPatients AS
    (
        SELECT *
        FROM (VALUES
            ('BNTESTFU02', 1, 'Upcoming'),
            ('BNTESTFU03', 2, 'Upcoming'),
            ('BNTESTFU04', 4, 'Upcoming'),
            ('BNTESTFU05', 6, 'Upcoming'),
            ('BNTESTFU06', -1, 'Overdue'),
            ('BNTESTFU07', -2, 'Overdue'),
            ('BNTESTFU08', -4, 'Overdue'),
            ('BNTESTFU09', -5, 'Overdue'),
            ('BNTESTFU10', -3, 'Reminded'),
            ('BNTESTFU11', -6, 'Reminded'),
            ('BNTESTFU12', -8, 'Completed'),
            ('BNTESTFU13', -9, 'Completed'),
            ('BNTESTFU14', 3, 'Upcoming'),
            ('BNTESTFU15', -7, 'Reminded')
        ) v(PatientCode, FollowOffset, FollowStatus)
    )
    INSERT INTO FollowUps(EncounterID, FollowUpDate, Status)
    SELECT e.EncounterID, DATEADD(DAY, dp.FollowOffset, CAST(GETDATE() AS date)), dp.FollowStatus
    FROM DemoFollowUpPatients dp
    INNER JOIN Patients p ON p.PatientCode = dp.PatientCode
    INNER JOIN Encounters e ON e.PatientID = p.PatientID AND e.DoctorID = @DoctorId
    WHERE NOT EXISTS (SELECT 1 FROM FollowUps f WHERE f.EncounterID = e.EncounterID);
END;
";
    }
}
