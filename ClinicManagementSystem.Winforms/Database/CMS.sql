CREATE DATABASE CMS;
GO

USE CMS;
GO
CREATE TABLE Roles (
   RoleID INT PRIMARY KEY IDENTITY,
   RoleName NVARCHAR(100),
   Description NVARCHAR(255)
);

CREATE TABLE Users (
   UserID INT PRIMARY KEY IDENTITY,
   Username VARCHAR(100) UNIQUE,
   PasswordHash VARCHAR(255),
   Email VARCHAR(255) UNIQUE,
   RoleID INT,
   IsActive BIT DEFAULT 1,
   CreatedAt DATETIME DEFAULT GETDATE(),

   FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE Sessions (
   SessionID INT PRIMARY KEY IDENTITY,
   UserID INT,
   Token VARCHAR(255),
   ExpiredAt DATETIME,

   FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
CREATE TABLE Departments (
   DepartmentID INT PRIMARY KEY IDENTITY,
   DepartmentName NVARCHAR(255)
);

CREATE TABLE Rooms (
   RoomID INT PRIMARY KEY IDENTITY,
   RoomCode VARCHAR(50) UNIQUE,
   DepartmentID INT,
   Status NVARCHAR(50),

   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY,
    EmployeeUUID UNIQUEIDENTIFIER
        NOT NULL DEFAULT NEWID(),
    EmployeeCode VARCHAR(50)
        UNIQUE NOT NULL,
    FullName NVARCHAR(255)
        NOT NULL,
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    CitizenId VARCHAR(20)
        UNIQUE,
    Address NVARCHAR(500),
    Phone VARCHAR(20),
    Email VARCHAR(255)
        UNIQUE,
    HireDate DATE,
    Salary DECIMAL(18,2),
    RoleID INT NOT NULL,
    DepartmentID INT NOT NULL,
    Status NVARCHAR(50)
        DEFAULT N'Active',
    UserID INT,
    FOREIGN KEY (RoleID)
        REFERENCES Roles(RoleID),
    FOREIGN KEY (DepartmentID)
        REFERENCES Departments(DepartmentID),
    FOREIGN KEY (UserID)
        REFERENCES Users(UserID)
);

CREATE TABLE Patients (
   PatientID INT PRIMARY KEY IDENTITY,
   PatientCode VARCHAR(50) UNIQUE,
   FullName NVARCHAR(255),
   Gender NVARCHAR(20),
   DOB DATE,
   Phone VARCHAR(20),
   Address NVARCHAR(500),
   BloodType NVARCHAR(10),
   Allergy NVARCHAR(MAX),
   CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE PatientInsurance (
    InsuranceID INT PRIMARY KEY IDENTITY,

    PatientID INT,

    InsuranceNumber VARCHAR(100),

    Provider NVARCHAR(255),

    EffectiveDate DATE,
    ExpiryDate DATE,

    FOREIGN KEY (PatientID)
        REFERENCES Patients(PatientID)
);

CREATE TABLE Appointments (
   AppointmentID INT PRIMARY KEY IDENTITY,
   PatientID INT,
   DoctorID INT,
   DepartmentID INT,
   RoomID INT,
   AppointmentDate DATETIME,
   CreatedAt DATETIME DEFAULT GETDATE(),
   Status NVARCHAR(50),

   FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
   FOREIGN KEY (DoctorID) REFERENCES Employees(EmployeeID),
   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
   FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);

CREATE TABLE Encounters (
   EncounterID INT PRIMARY KEY IDENTITY,
   AppointmentID INT,
   PatientID INT,
   DoctorID INT,
   StartTime DATETIME,
   EndTime DATETIME,
   CreatedAt DATETIME DEFAULT GETDATE(),
   Status NVARCHAR(50),

   FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID),
   FOREIGN KEY (PatientID)
   REFERENCES Patients(PatientID),

FOREIGN KEY (DoctorID)
   REFERENCES Employees(EmployeeID)
);

CREATE TABLE Services (
   ServiceID INT PRIMARY KEY IDENTITY,
   ServiceName NVARCHAR(255),
   Price DECIMAL(18,2),
   DepartmentID INT,
   FOREIGN KEY (DepartmentID)
   REFERENCES Departments(DepartmentID)
);

CREATE TABLE EncounterServices (
    EncounterServiceID INT PRIMARY KEY IDENTITY,

    EncounterID INT NOT NULL,
    ServiceID INT NOT NULL,

    Quantity INT DEFAULT 1,
    UnitPrice DECIMAL(18,2),

    OrderedBy INT NULL,
    OrderedAt DATETIME DEFAULT GETDATE(),

    Status NVARCHAR(50) DEFAULT N'Pending',

    FOREIGN KEY (EncounterID)
        REFERENCES Encounters(EncounterID),

    FOREIGN KEY (ServiceID)
        REFERENCES Services(ServiceID),

    FOREIGN KEY (OrderedBy)
        REFERENCES Employees(EmployeeID)
);

CREATE TABLE DoctorSchedules (
    ScheduleID INT PRIMARY KEY IDENTITY,

    DoctorID INT,

    WorkDate DATE,

    StartTime TIME,
    EndTime TIME,

    RoomID INT,

    FOREIGN KEY (DoctorID)
        REFERENCES Employees(EmployeeID),

    FOREIGN KEY (RoomID)
        REFERENCES Rooms(RoomID)
);

CREATE TABLE PatientQueues (
   QueueID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Priority NVARCHAR(50),
   Status NVARCHAR(50),
   CurrentStep NVARCHAR(50),

   FOREIGN KEY (EncounterID)
      REFERENCES Encounters(EncounterID)
);
CREATE TABLE MedicalRecords (
   RecordID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   ChiefComplaint NVARCHAR(MAX),
   Symptoms NVARCHAR(MAX),
   Diagnosis NVARCHAR(MAX),
   ICDCode NVARCHAR(50),
   Conclusion NVARCHAR(MAX),
   Notes NVARCHAR(MAX),
   CreatedAt DATETIME DEFAULT GETDATE(),

   FOREIGN KEY (EncounterID) REFERENCES Encounters(EncounterID)
);

CREATE TABLE MedicalRecordFiles (
    FileID INT PRIMARY KEY IDENTITY,

    RecordID INT NOT NULL,

    FileType NVARCHAR(50),
    FileURL NVARCHAR(MAX),

    UploadedAt DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (RecordID)
        REFERENCES MedicalRecords(RecordID)
);

CREATE TABLE VitalSigns (
   VitalID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Temperature DECIMAL(4,1),
   BloodPressure VARCHAR(20),
   HeartRate INT,
   SPO2 INT,
   Weight DECIMAL(5,2),
   Notes NVARCHAR(MAX),
   CreatedAt DATETIME DEFAULT GETDATE(),

   FOREIGN KEY (EncounterID) REFERENCES Encounters(EncounterID)
);
CREATE TABLE LabRequests (
   LabID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   TestType NVARCHAR(255),
   Status NVARCHAR(50),
   CreatedAt DATETIME DEFAULT GETDATE(),
   FOREIGN KEY (EncounterID)
      REFERENCES Encounters(EncounterID),

   FOREIGN KEY (DoctorID)
      REFERENCES Employees(EmployeeID)
);

CREATE TABLE LabResults (
   ResultID INT PRIMARY KEY IDENTITY,
   LabID INT,
   ResultText NVARCHAR(MAX),
   FileURL NVARCHAR(MAX),
   CompletedAt DATETIME,
   FOREIGN KEY (LabID)
   REFERENCES LabRequests(LabID)
);
CREATE TABLE ImagingServices (
    ImagingServiceID INT PRIMARY KEY IDENTITY,
    ServiceCode VARCHAR(50),
    ServiceName NVARCHAR(255),
    Modality NVARCHAR(50),
    Price DECIMAL(18,2),
    IsActive BIT DEFAULT 1
);
CREATE TABLE ImagingRequests (
   ImagingRequestID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   ImagingServiceID INT,
   BodyPart NVARCHAR(100),
   CreatedAt DATETIME DEFAULT GETDATE(),
   Priority NVARCHAR(50),
   Status NVARCHAR(50),

   FOREIGN KEY (EncounterID)
      REFERENCES Encounters(EncounterID),

   FOREIGN KEY (DoctorID)
      REFERENCES Employees(EmployeeID),

   FOREIGN KEY (ImagingServiceID)
      REFERENCES ImagingServices(ImagingServiceID)
);

CREATE TABLE ImagingResults (
   ImagingResultID INT PRIMARY KEY IDENTITY,
   ImagingRequestID INT,
   ResultText NVARCHAR(MAX),
   ImageURL NVARCHAR(MAX),
   PDFURL NVARCHAR(MAX),
   TechnicianNote NVARCHAR(MAX),
   CompletedAt DATETIME,

   FOREIGN KEY (ImagingRequestID)
      REFERENCES ImagingRequests(ImagingRequestID)
);
CREATE TABLE ImagingFiles (
    FileID INT PRIMARY KEY IDENTITY,
    ImagingResultID INT,
    FileType NVARCHAR(50),
    FileURL NVARCHAR(MAX),

    FOREIGN KEY (ImagingResultID)
       REFERENCES ImagingResults(ImagingResultID)
);
CREATE TABLE Medicines (
   MedicineID INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(255),
   Unit NVARCHAR(50),
   Price DECIMAL(18,2),
   Stock INT,
   BatchNumber NVARCHAR(100),
   ExpiryDate DATE
);

CREATE TABLE Prescriptions (
   PrescriptionID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   Status NVARCHAR(50),
   CreatedAt DATETIME DEFAULT GETDATE(),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID),

FOREIGN KEY (DoctorID)
   REFERENCES Employees(EmployeeID)
);

CREATE TABLE PrescriptionDetails (
   DetailID INT PRIMARY KEY IDENTITY,
   PrescriptionID INT,
   MedicineID INT,
   Quantity INT,
   Dosage NVARCHAR(100),
   FOREIGN KEY (PrescriptionID)
   REFERENCES Prescriptions(PrescriptionID),

FOREIGN KEY (MedicineID)
   REFERENCES Medicines(MedicineID)
);
CREATE TABLE Dispense (
   DispenseID INT PRIMARY KEY IDENTITY,
   PrescriptionID INT,
   PharmacistID INT,
   TotalAmount DECIMAL(18,2),
   Status NVARCHAR(50),
   FOREIGN KEY (PrescriptionID)
   REFERENCES Prescriptions(PrescriptionID),

FOREIGN KEY (PharmacistID)
   REFERENCES Employees(EmployeeID)
);

CREATE TABLE QueueHistory (
    HistoryID INT PRIMARY KEY IDENTITY,

    QueueID INT,

    StepName NVARCHAR(100),

    StartTime DATETIME,
    EndTime DATETIME,

    EmployeeID INT NULL,

    FOREIGN KEY (QueueID)
        REFERENCES PatientQueues(QueueID),

    FOREIGN KEY (EmployeeID)
        REFERENCES Employees(EmployeeID)
);

CREATE TABLE Payments (
   PaymentID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Amount DECIMAL(18,2),
   Method NVARCHAR(50),
   Status NVARCHAR(50),
   PaidAt DATETIME,
   PatientID INT,
   CreatedAt DATETIME DEFAULT GETDATE(),

FOREIGN KEY (PatientID)
REFERENCES Patients(PatientID),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);

CREATE TABLE PaymentDetails (
    PaymentDetailID INT PRIMARY KEY IDENTITY,

    PaymentID INT NOT NULL,

    ItemType NVARCHAR(50),
    ItemID INT,

    Description NVARCHAR(255),

    Quantity INT,
    UnitPrice DECIMAL(18,2),

    Amount DECIMAL(18,2),

    FOREIGN KEY (PaymentID)
        REFERENCES Payments(PaymentID)
);

CREATE TABLE Invoices (
   InvoiceID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   PatientID INT,
   Total DECIMAL(18,2),
   Status NVARCHAR(50),
   CreatedAt DATETIME DEFAULT GETDATE(),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID),

FOREIGN KEY (PatientID)
   REFERENCES Patients(PatientID)
);

CREATE TABLE InvoiceDetails (
   DetailID INT PRIMARY KEY IDENTITY,
   InvoiceID INT,
   ServiceID INT,
   Quantity INT,
   Price DECIMAL(18,2),
   FOREIGN KEY (InvoiceID)
   REFERENCES Invoices(InvoiceID),

FOREIGN KEY (ServiceID)
   REFERENCES Services(ServiceID)
);
CREATE TABLE Files (
   FileID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   FileType NVARCHAR(50),
   FileURL NVARCHAR(MAX),
   UploadedAt DATETIME DEFAULT GETDATE(),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);
CREATE TABLE FollowUps (
   FollowUpID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   FollowUpDate DATETIME,
   Status NVARCHAR(50),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);

CREATE TABLE Transfers (
   TransferID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Reason NVARCHAR(MAX),
   Severity NVARCHAR(50),
   Status NVARCHAR(50),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);
CREATE TABLE Shifts (
   ShiftID INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(100),
   StartTime TIME,
   EndTime TIME
);

CREATE TABLE EmployeeShifts (
   ID INT PRIMARY KEY IDENTITY,
   EmployeeID INT,
   ShiftID INT,
   WorkDate DATE,

   FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
   FOREIGN KEY (ShiftID)
   REFERENCES Shifts(ShiftID)
);
CREATE TABLE Notifications (
   NotificationID INT PRIMARY KEY IDENTITY,
   UserID INT,
   Message NVARCHAR(MAX),
   IsRead BIT DEFAULT 0,
   FOREIGN KEY (UserID)
   REFERENCES Users(UserID)
);

CREATE TABLE AuditLogs (
   LogID INT PRIMARY KEY IDENTITY,
   UserID INT,
   Action NVARCHAR(100),
   TableName NVARCHAR(100),
   CreatedAt DATETIME DEFAULT GETDATE(),
   FOREIGN KEY (UserID)
   REFERENCES Users(UserID)
);

CREATE TABLE AuditLogDetails (
    DetailID INT PRIMARY KEY IDENTITY,

    LogID INT,

    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),

    FOREIGN KEY (LogID)
        REFERENCES AuditLogs(LogID)
);

CREATE TABLE PatientIdentifiers (
    IdentifierID INT PRIMARY KEY IDENTITY,
    PatientID INT,
    SourceSystem NVARCHAR(100),
    IdentifierType NVARCHAR(100),
    IdentifierValue NVARCHAR(255),

    FOREIGN KEY (PatientID)
        REFERENCES Patients(PatientID),

    UNIQUE(SourceSystem, IdentifierValue)
);

/* =========================
   UUID FOR BUSINESS ENTITIES
   ========================= */

/* Patients */
ALTER TABLE Patients
ADD PatientUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Patients
ADD CONSTRAINT UQ_Patients_UUID
UNIQUE (PatientUUID);


/* Employees */
ALTER TABLE Employees
ADD EmployeeUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Employees
ADD CONSTRAINT UQ_Employees_UUID
UNIQUE (EmployeeUUID);


/* Appointments */
ALTER TABLE Appointments
ADD AppointmentUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Appointments
ADD CONSTRAINT UQ_Appointments_UUID
UNIQUE (AppointmentUUID);


/* Encounters */
ALTER TABLE Encounters
ADD EncounterUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Encounters
ADD CONSTRAINT UQ_Encounters_UUID
UNIQUE (EncounterUUID);


/* MedicalRecords */
ALTER TABLE MedicalRecords
ADD RecordUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE MedicalRecords
ADD CONSTRAINT UQ_MedicalRecords_UUID
UNIQUE (RecordUUID);


/* Prescriptions */
ALTER TABLE Prescriptions
ADD PrescriptionUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Prescriptions
ADD CONSTRAINT UQ_Prescriptions_UUID
UNIQUE (PrescriptionUUID);


/* Payments */
ALTER TABLE Payments
ADD PaymentUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Payments
ADD CONSTRAINT UQ_Payments_UUID
UNIQUE (PaymentUUID);


/* Invoices */
ALTER TABLE Invoices
ADD InvoiceUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Invoices
ADD CONSTRAINT UQ_Invoices_UUID
UNIQUE (InvoiceUUID);

/* Lab Requests */
ALTER TABLE LabRequests
ADD LabRequestUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE LabRequests
ADD CONSTRAINT UQ_LabRequests_UUID
UNIQUE (LabRequestUUID);


/* Imaging Requests */
ALTER TABLE ImagingRequests
ADD ImagingRequestUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE ImagingRequests
ADD CONSTRAINT UQ_ImagingRequests_UUID
UNIQUE (ImagingRequestUUID);


/* Patient Queues */
ALTER TABLE PatientQueues
ADD QueueUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE PatientQueues
ADD CONSTRAINT UQ_PatientQueues_UUID
UNIQUE (QueueUUID);


/* Dispense */
ALTER TABLE Dispense
ADD DispenseUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Dispense
ADD CONSTRAINT UQ_Dispense_UUID
UNIQUE (DispenseUUID);


/* FollowUps */
ALTER TABLE FollowUps
ADD FollowUpUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE FollowUps
ADD CONSTRAINT UQ_FollowUps_UUID
UNIQUE (FollowUpUUID);


/* Transfers */
ALTER TABLE Transfers
ADD TransferUUID UNIQUEIDENTIFIER
    NOT NULL
    DEFAULT NEWID();

ALTER TABLE Transfers
ADD CONSTRAINT UQ_Transfers_UUID
UNIQUE (TransferUUID);

INSERT INTO Departments(DepartmentName)
VALUES
(N'Tiếp nhận'),
(N'Khám tổng quát'),
(N'Nhi khoa'),
(N'Sản phụ khoa'),
(N'Tai Mũi Họng'),
(N'Răng Hàm Mặt'),
(N'Da liễu'),
(N'Mắt'),
(N'Xét nghiệm'),
(N'Chẩn đoán hình ảnh'),
(N'Nhà thuốc'),
(N'Hành chính');

INSERT INTO Rooms(RoomCode, DepartmentID, Status)
VALUES

('GP-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Khám tổng quát'),
 'Available'),

('PED-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhi khoa'),
 'Available'),

('OBS-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Sản phụ khoa'),
 'Available'),

('ENT-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tai Mũi Họng'),
 'Available'),

('DEN-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Răng Hàm Mặt'),
 'Available'),

('DER-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Da liễu'),
 'Available'),

('EYE-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Mắt'),
 'Available'),

('LAB-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Xét nghiệm'),
 'Available'),

('IMG-01',
 (SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Chẩn đoán hình ảnh'),
 'Available');

INSERT INTO Roles(RoleName, Description)
VALUES
('Admin','System Administrator'),
('Receptionist','Manage appointments'),
('Doctor','Doctor'),
('Nurse','Nurse'),
('Pharmacist','Pharmacist'),
('Technician','Lab / Imaging Technician');

INSERT INTO Users
(
    Username,
    PasswordHash,
    Email,
    RoleID
)
VALUES

(
    'admin',
    '123456',
    'admin@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Admin')
),

(
    'reception',
    '123456',
    'reception@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Receptionist')
),

(
    'doctor_gp',
    '123456',
    'doctor.gp@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'doctor_ped',
    '123456',
    'doctor.ped@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'doctor_obs',
    '123456',
    'doctor.obs@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'doctor_ent',
    '123456',
    'doctor.ent@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'doctor_den',
    '123456',
    'doctor.den@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'doctor_der',
    '123456',
    'doctor.der@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'doctor_eye',
    '123456',
    'doctor.eye@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
),

(
    'nurse',
    '123456',
    'nurse@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Nurse')
),

(
    'pharmacist',
    '123456',
    'pharmacist@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Pharmacist')
),

(
    'tech',
    '123456',
    'tech@cms.local',
    (SELECT RoleID FROM Roles WHERE RoleName='Technician')
);

INSERT INTO Employees
(
    EmployeeCode,
    FullName,
    DateOfBirth,
    Gender,
    CitizenId,
    Address,
    Phone,
    Email,
    HireDate,
    Salary,
    RoleID,
    DepartmentID,
    Status,
    UserID
)
VALUES

(
'EMP001',
N'Admin System',
'1985-01-15',
N'Nam',
'079085000001',
N'Quận 1, TP.HCM',
'090000001',
'admin@clinic.vn',
'2020-01-01',
30000000,
(SELECT RoleID FROM Roles WHERE RoleName='Admin'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Hành chính'),
'Active',
(SELECT UserID FROM Users WHERE Username='admin')
),

(
'EMP002',
N'Nguyễn Lễ Tân',
'1995-05-10',
N'Nữ',
'079095000002',
N'Quận 3, TP.HCM',
'090000002',
'reception@clinic.vn',
'2023-01-10',
10000000,
(SELECT RoleID FROM Roles WHERE RoleName='Receptionist'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tiếp nhận'),
'Active',
(SELECT UserID FROM Users WHERE Username='reception')
),

(
'EMP003',
N'BS Trần Minh',
'1980-03-20',
N'Nam',
'079080000003',
N'Quận 7, TP.HCM',
'090000003',
'doctor.gp@clinic.vn',
'2018-06-01',
35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Khám tổng quát'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_gp')
),

(
'EMP004',
N'BS Nguyễn Hoàng',
'1982-07-15',
N'Nam',
'079082000004',
N'Thủ Đức, TP.HCM',
'090000004',
'doctor.ped@clinic.vn',
'2019-01-15',
35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhi khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_ped')
),

(
'EMP005',
N'BS Lê Thanh',
'1984-09-25',
N'Nữ',
'079084000005',
N'Quận 10, TP.HCM',
'090000005',
'doctor.obs@clinic.vn',
'2019-08-01',
38000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Sản phụ khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_obs')
),

(
'EMP006',
N'BS Võ Minh',
'1981-04-12',
N'Nam',
'079081000006',
N'Tân Bình, TP.HCM',
'090000006',
'doctor.ent@clinic.vn',
'2018-11-01',
35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tai Mũi Họng'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_ent')
),

(
'EMP007',
N'BS Trương Anh',
'1983-12-05',
N'Nam',
'079083000007',
N'Bình Thạnh, TP.HCM',
'090000007',
'doctor.den@clinic.vn',
'2020-03-01',
35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Răng Hàm Mặt'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_den')
),

(
'EMP008',
N'BS Phạm Duy',
'1986-02-18',
N'Nữ',
'079086000008',
N'Phú Nhuận, TP.HCM',
'090000008',
'doctor.der@clinic.vn',
'2021-01-01',
35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Da liễu'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_der')
),

(
'EMP009',
N'BS Nguyễn Ngọc',
'1987-06-30',
N'Nữ',
'079087000009',
N'Gò Vấp, TP.HCM',
'090000009',
'doctor.eye@clinic.vn',
'2021-05-01',
35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Mắt'),
'Active',
(SELECT UserID FROM Users WHERE Username='doctor_eye')
),

(
'EMP010',
N'YT Lê Lan',
'1994-10-20',
N'Nữ',
'079094000010',
N'Quận 12, TP.HCM',
'090000010',
'nurse@clinic.vn',
'2023-02-01',
12000000,
(SELECT RoleID FROM Roles WHERE RoleName='Nurse'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Khám tổng quát'),
'Active',
(SELECT UserID FROM Users WHERE Username='nurse')
),

(
'EMP011',
N'DS Phạm Hùng',
'1990-08-15',
N'Nam',
'079090000011',
N'Bình Tân, TP.HCM',
'090000011',
'pharmacist@clinic.vn',
'2022-01-01',
15000000,
(SELECT RoleID FROM Roles WHERE RoleName='Pharmacist'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhà thuốc'),
'Active',
(SELECT UserID FROM Users WHERE Username='pharmacist')
),

(
'EMP012',
N'KTV Võ Phúc',
'1992-11-25',
N'Nam',
'079092000012',
N'Hóc Môn, TP.HCM',
'090000012',
'tech@clinic.vn',
'2022-05-01',
14000000,
(SELECT RoleID FROM Roles WHERE RoleName='Technician'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Xét nghiệm'),
'Active',
(SELECT UserID FROM Users WHERE Username='tech')
);


INSERT INTO DoctorSchedules
(
DoctorID,
WorkDate,
StartTime,
EndTime,
RoomID
)
VALUES

(
3,
GETDATE(),
'08:00',
'17:00',
1
),

(
4,
GETDATE(),
'08:00',
'17:00',
2
),

(
5,
GETDATE(),
'08:00',
'17:00',
3
),

(
6,
GETDATE(),
'08:00',
'17:00',
4
),

(
7,
GETDATE(),
'08:00',
'17:00',
5
),

(
8,
GETDATE(),
'08:00',
'17:00',
6
),

(
9,
GETDATE(),
'08:00',
'17:00',
7
);

INSERT INTO Services
(ServiceName, Price, DepartmentID)
VALUES

(N'Khám tổng quát',100000,2),
(N'Khám nhi',120000,3),
(N'Khám sản',150000,4),
(N'Khám tai mũi họng',120000,5),
(N'Khám răng hàm mặt',130000,6),
(N'Khám da liễu',150000,7),
(N'Khám mắt',120000,8);

INSERT INTO Medicines
(
Name,
Unit,
Price,
Stock,
BatchNumber,
ExpiryDate
)
VALUES

(N'Paracetamol 500mg',N'Viên',2000,1000,'PAR001','2028-12-31'),
(N'Amoxicillin 500mg',N'Viên',3000,500,'AMX001','2028-12-31'),
(N'Vitamin C',N'Viên',1000,1000,'VTC001','2028-12-31');

INSERT INTO Patients
(
    PatientCode,
    FullName,
    Gender,
    DOB,
    Phone,
    Address,
    BloodType,
    Allergy
)
VALUES

(
    'PT001',
    N'Nguyễn Văn A',
    N'Nam',
    '2000-01-01',
    '0901111111',
    N'HCM',
    'A+',
    N'Không'
),

(
    'PT002',
    N'Trần Thị B',
    N'Nữ',
    '1998-05-20',
    '0902222222',
    N'HCM',
    'B+',
    N'Penicillin'
),

(
    'PT003',
    N'Lê Văn C',
    N'Nam',
    '2010-03-15',
    '0903333333',
    N'HCM',
    'O+',
    N'Hải sản'
),

(
    'PT004',
    N'Phạm Thị D',
    N'Nữ',
    '1995-07-10',
    '0904444444',
    N'HCM',
    'AB+',
    N'Phấn hoa'
),

(
    'PT005',
    N'Nguyễn Văn E',
    N'Nam',
    '1988-12-01',
    '0905555555',
    N'HCM',
    'O-',
    N'Không'
);



