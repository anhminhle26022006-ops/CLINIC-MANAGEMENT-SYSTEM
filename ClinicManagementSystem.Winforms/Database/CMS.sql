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
    CitizenId VARCHAR(20),
    Address NVARCHAR(500),
    Phone VARCHAR(20),
    Email VARCHAR(255),
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

CREATE UNIQUE INDEX UX_Employees_CitizenId_NotNull
ON Employees(CitizenId)
WHERE CitizenId IS NOT NULL;

CREATE UNIQUE INDEX UX_Employees_Email_NotNull
ON Employees(Email)
WHERE Email IS NOT NULL;

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
   Height DECIMAL(5,2),
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
   BodyPart NVARCHAR(500),
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
   Frequency NVARCHAR(100),
   Instruction NVARCHAR(500),
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
-- EmployeeUUID is already defined in CREATE TABLE Employees, so we only add the UNIQUE constraint
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

 INSERT INTO Shifts (Name, StartTime, EndTime)
VALUES 
(N'Ca sáng', '07:00', '11:00'),
(N'Ca chiều', '13:00', '17:00'),
(N'Ca tối', '17:00', '21:00');

INSERT INTO Roles(RoleName, Description)
VALUES
('Admin','System Administrator'),
('Receptionist','Manage appointments'),
('Doctor','Doctor'),
('Nurse','Nurse'),
('Pharmacist','Pharmacist'),
('Technician','Lab / Imaging Technician');

INSERT INTO Users (Username, PasswordHash, Email, RoleID)
VALUES
-- Admin (2)
('admin1','123456','admin1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Admin')),
('admin2','123456','admin2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Admin')),

-- Receptionist (2)
('reception1','123456','reception1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Receptionist')),
('reception2','123456','reception2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Receptionist')),

-- Doctors (16 người = 8 chuyên khoa × 2)
('gp1','123456','gp1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('gp2','123456','gp2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

('ped1','123456','ped1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('ped2','123456','ped2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

('obs1','123456','obs1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('obs2','123456','obs2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

('ent1','123456','ent1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('ent2','123456','ent2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

('den1','123456','den1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('den2','123456','den2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

('der1','123456','der1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('der2','123456','der2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

('eye1','123456','eye1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),
('eye2','123456','eye2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Doctor')),

-- Nurse (2)
('nurse1','123456','nurse1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Nurse')),
('nurse2','123456','nurse2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Nurse')),

-- Pharmacist (2)
('pharma1','123456','pharma1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Pharmacist')),
('pharma2','123456','pharma2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Pharmacist')),

-- Technician (2)
('tech1','123456','tech1@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Technician')),
('tech2','123456','tech2@cms.local', (SELECT RoleID FROM Roles WHERE RoleName='Technician'));

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
-- ================= ADMIN =================
(
'ADM001', N'Admin 1','1985-01-01',N'Nam','100000000001',N'HCM','0900000001','admin1@cms.local','2020-01-01',30000000,
(SELECT RoleID FROM Roles WHERE RoleName='Admin'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Hành chính'),
'Active',
(SELECT UserID FROM Users WHERE Username='admin1')
),
(
'ADM002', N'Admin 2','1986-02-02',N'Nữ','100000000002',N'HCM','0900000002','admin2@cms.local','2020-01-01',30000000,
(SELECT RoleID FROM Roles WHERE RoleName='Admin'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Hành chính'),
'Active',
(SELECT UserID FROM Users WHERE Username='admin2')
),

-- ================= RECEPTION =================
(
'REC001', N'Tiếp tân 1','1995-01-01',N'Nữ','200000000001',N'HCM','0900000003','reception1@cms.local','2023-01-01',10000000,
(SELECT RoleID FROM Roles WHERE RoleName='Receptionist'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tiếp nhận'),
'Active',
(SELECT UserID FROM Users WHERE Username='reception1')
),
(
'REC002', N'Tiếp tân 2','1996-02-02',N'Nữ','200000000002',N'HCM','0900000004','reception2@cms.local','2023-01-01',10000000,
(SELECT RoleID FROM Roles WHERE RoleName='Receptionist'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tiếp nhận'),
'Active',
(SELECT UserID FROM Users WHERE Username='reception2')
),

-- ================= NURSE =================
(
'NUR001', N'Điều dưỡng 1','1994-03-03',N'Nữ','300000000001',N'HCM','0900000005','nurse1@cms.local','2023-01-01',12000000,
(SELECT RoleID FROM Roles WHERE RoleName='Nurse'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Khám tổng quát'),
'Active',
(SELECT UserID FROM Users WHERE Username='nurse1')
),
(
'NUR002', N'Điều dưỡng 2','1993-04-04',N'Nữ','300000000002',N'HCM','0900000006','nurse2@cms.local','2023-01-01',12000000,
(SELECT RoleID FROM Roles WHERE RoleName='Nurse'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhi khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='nurse2')
),

-- ================= PHARMACIST =================
(
'PHA001', N'Dược sĩ 1','1990-05-05',N'Nam','400000000001',N'HCM','0900000007','pharma1@cms.local','2022-01-01',15000000,
(SELECT RoleID FROM Roles WHERE RoleName='Pharmacist'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhà thuốc'),
'Active',
(SELECT UserID FROM Users WHERE Username='pharma1')
),
(
'PHA002', N'Dược sĩ 2','1991-06-06',N'Nữ','400000000002',N'HCM','0900000008','pharma2@cms.local','2022-01-01',15000000,
(SELECT RoleID FROM Roles WHERE RoleName='Pharmacist'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhà thuốc'),
'Active',
(SELECT UserID FROM Users WHERE Username='pharma2')
),

-- ================= TECHNICIAN =================
(
'TEC001', N'KTV 1','1992-07-07',N'Nam','500000000001',N'HCM','0900000009','tech1@cms.local','2022-01-01',14000000,
(SELECT RoleID FROM Roles WHERE RoleName='Technician'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Xét nghiệm'),
'Active',
(SELECT UserID FROM Users WHERE Username='tech1')
),
(
'TEC002', N'KTV 2','1993-08-08',N'Nữ','500000000002',N'HCM','0900000010','tech2@cms.local','2022-01-01',14000000,
(SELECT RoleID FROM Roles WHERE RoleName='Technician'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Xét nghiệm'),
'Active',
(SELECT UserID FROM Users WHERE Username='tech2')
),

-- ================= DOCTORS =================
(
'DOC_GP1', N'BS GP 1','1980-01-01',N'Nam','600000000001',N'HCM','0900000011','gp1@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Khám tổng quát'),
'Active',
(SELECT UserID FROM Users WHERE Username='gp1')
),
(
'DOC_GP2', N'BS GP 2','1981-02-02',N'Nữ','600000000002',N'HCM','0900000012','gp2@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Khám tổng quát'),
'Active',
(SELECT UserID FROM Users WHERE Username='gp2')
),

(
'DOC_PED1', N'BS Nhi 1','1982-03-03',N'Nữ','600000000003',N'HCM','0900000013','ped1@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhi khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='ped1')
),
(
'DOC_PED2', N'BS Nhi 2','1983-04-04',N'Nam','600000000004',N'HCM','0900000014','ped2@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Nhi khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='ped2')
),

(
'DOC_OBS1', N'BS Sản 1','1984-05-05',N'Nữ','600000000005',N'HCM','0900000015','obs1@cms.local','2018-01-01',38000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Sản phụ khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='obs1')
),
(
'DOC_OBS2', N'BS Sản 2','1985-06-06',N'Nữ','600000000006',N'HCM','0900000016','obs2@cms.local','2018-01-01',38000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Sản phụ khoa'),
'Active',
(SELECT UserID FROM Users WHERE Username='obs2')
),

(
'DOC_ENT1', N'BS ENT 1','1986-07-07',N'Nam','600000000007',N'HCM','0900000017','ent1@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tai Mũi Họng'),
'Active',
(SELECT UserID FROM Users WHERE Username='ent1')
),
(
'DOC_ENT2', N'BS ENT 2','1987-08-08',N'Nữ','600000000008',N'HCM','0900000018','ent2@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Tai Mũi Họng'),
'Active',
(SELECT UserID FROM Users WHERE Username='ent2')
),

(
'DOC_DEN1', N'BS RHM 1','1988-09-09',N'Nam','600000000009',N'HCM','0900000019','den1@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Răng Hàm Mặt'),
'Active',
(SELECT UserID FROM Users WHERE Username='den1')
),
(
'DOC_DEN2', N'BS RHM 2','1989-10-10',N'Nữ','600000000010',N'HCM','0900000020','den2@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Răng Hàm Mặt'),
'Active',
(SELECT UserID FROM Users WHERE Username='den2')
),

(
'DOC_DER1', N'BS Da 1','1990-11-11',N'Nữ','600000000011',N'HCM','0900000021','der1@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Da liễu'),
'Active',
(SELECT UserID FROM Users WHERE Username='der1')
),
(
'DOC_DER2', N'BS Da 2','1991-12-12',N'Nam','600000000012',N'HCM','0900000022','der2@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Da liễu'),
'Active',
(SELECT UserID FROM Users WHERE Username='der2')
),

(
'DOC_EYE1', N'BS Mắt 1','1982-01-02',N'Nữ','600000000013',N'HCM','0900000023','eye1@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Mắt'),
'Active',
(SELECT UserID FROM Users WHERE Username='eye1')
),
(
'DOC_EYE2', N'BS Mắt 2','1983-02-03',N'Nam','600000000014',N'HCM','0900000024','eye2@cms.local','2018-01-01',35000000,
(SELECT RoleID FROM Roles WHERE RoleName='Doctor'),
(SELECT DepartmentID FROM Departments WHERE DepartmentName=N'Mắt'),
'Active',
(SELECT UserID FROM Users WHERE Username='eye2'));


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

-- ADMIN
INSERT INTO EmployeeShifts VALUES
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='ADM001'), 1, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='ADM002'), 1, GETDATE());

-- RECEPTION
INSERT INTO EmployeeShifts VALUES
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='REC001'), 1, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='REC001'), 2, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='REC002'), 1, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='REC002'), 2, GETDATE());

-- NURSE
INSERT INTO EmployeeShifts VALUES
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='NUR001'), 1, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='NUR002'), 1, GETDATE());

-- PHARMACIST
INSERT INTO EmployeeShifts VALUES
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='PHA001'), 3, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='PHA002'), 3, GETDATE());

-- TECHNICIAN
INSERT INTO EmployeeShifts VALUES
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='TEC001'), 2, GETDATE()),
((SELECT EmployeeID FROM Employees WHERE EmployeeCode='TEC002'), 2, GETDATE());

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
(N'Vitamin C',N'Viên',1000,1000,'VTC001','2028-12-31'),
(N'Ibuprofen 400mg',N'Viên',2500,800,'IBU001','2028-12-31'),
(N'Cefixime 200mg',N'Viên',5000,600,'CFX001','2028-12-31'),
(N'Omeprazole 20mg',N'Viên',3000,700,'OMP001','2028-12-31'),
(N'Loratadine 10mg',N'Viên',2000,900,'LOR001','2028-12-31');

INSERT INTO Patients
(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
VALUES
('BN20051',N'Nguyễn Minh Khôi',N'Nam','1998-03-12','0901000001',N'Quận 1, TP.HCM','O+',N'Không có'),
('BN20052',N'Lê Thị Hồng Nhung',N'Nữ','1995-07-21','0901000002',N'Quận 3, TP.HCM','A+',N'Phấn hoa'),
('BN20053',N'Trần Quốc Huy',N'Nam','2000-11-05','0901000003',N'Quận 7, TP.HCM','B+',N'Đậu phộng'),
('BN20054',N'Phạm Ngọc Lan',N'Nữ','1988-01-18','0901000004',N'Thủ Đức, TP.HCM','O-',N'Không có'),
('BN20055',N'Võ Thành Đạt',N'Nam','1993-09-09','0901000005',N'Bình Thạnh, TP.HCM','AB+',N'Sulfa'),
('BN20056',N'Đặng Minh Tâm',N'Nữ','1979-04-02','0901000006',N'Quận 10, TP.HCM','A-',N'Trứng'),
('BN20057',N'Bùi Gia Huy',N'Nam','1996-06-15','0901000007',N'Quận 12, TP.HCM','O+',N'Không có'),
('BN20058',N'Phan Thảo Vy',N'Nữ','2001-02-28','0901000008',N'Gò Vấp, TP.HCM','B-',N'Phấn hoa'),
('BN20059',N'Lê Hoàng Nam',N'Nam','1985-12-10','0901000009',N'Tân Bình, TP.HCM','AB-',N'Hải sản'),
('BN20060',N'Trần Thu Trang',N'Nữ','1999-08-08','0901000010',N'Quận 4, TP.HCM','O+',N'Không có'),

('BN20061',N'Nguyễn Văn Khoa',N'Nam','1992-03-03','0901000011',N'Bình Chánh, TP.HCM','A+',N'Đậu nành'),
('BN20062',N'Võ Thị Kim Ngân',N'Nữ','1987-07-19','0901000012',N'Hóc Môn, TP.HCM','B+',N'Sữa bò'),
('BN20063',N'Phạm Quốc Bảo',N'Nam','2003-01-25','0901000013',N'Quận 6, TP.HCM','O-',N'Không có'),
('BN20064',N'Lê Thị Mai',N'Nữ','1970-05-11','0901000014',N'Thủ Đức, TP.HCM','A-',N'Sulfa'),
('BN20065',N'Trần Minh Đức',N'Nam','1995-09-30','0901000015',N'Quận 8, TP.HCM','AB+',N'Phấn hoa'),
('BN20066',N'Đỗ Ngọc Hân',N'Nữ','1982-11-22','0901000016',N'Quận 11, TP.HCM','O+',N'Không có'),
('BN20067',N'Nguyễn Hoàng Phúc',N'Nam','1997-04-14','0901000017',N'Quận 9, TP.HCM','B+',N'Đậu phộng'),
('BN20068',N'Phan Thị Yến',N'Nữ','2000-10-05','0901000018',N'Bình Tân, TP.HCM','A+',N'Hải sản'),
('BN20069',N'Lý Gia Hưng',N'Nam','1989-06-07','0901000019',N'Quận 5, TP.HCM','O-',N'Không có'),
('BN20070',N'Hoàng Thị Linh',N'Nữ','1991-12-12','0901000020',N'Quận 2, TP.HCM','AB+',N'Phấn hoa'),

('BN20071',N'Nguyễn Tấn Phát',N'Nam','1994-03-18','0901000021',N'Gò Vấp, TP.HCM','A-',N'Sulfa'),
('BN20072',N'Lê Thị Bích',N'Nữ','1980-09-09','0901000022',N'Tân Phú, TP.HCM','B+',N'Trứng'),
('BN20073',N'Trần Gia Bảo',N'Nam','2002-11-11','0901000023',N'Quận 7, TP.HCM','O+',N'Không có'),
('BN20074',N'Phạm Thị Ngọc',N'Nữ','1975-01-01','0901000024',N'Quận 3, TP.HCM','A+',N'Đậu nành'),
('BN20075',N'Bùi Văn Long',N'Nam','1983-04-20','0901000025',N'Quận 12, TP.HCM','AB-',N'Hải sản'),
('BN20076',N'Đặng Thị Hoa',N'Nữ','1998-08-28','0901000026',N'Bình Thạnh, TP.HCM','O-',N'Không có'),
('BN20077',N'Nguyễn Quốc Việt',N'Nam','1990-02-14','0901000027',N'Thủ Đức, TP.HCM','B+',N'Sulfa'),
('BN20078',N'Lê Thanh Tùng',N'Nam','1993-06-25','0901000028',N'Quận 1, TP.HCM','A+',N'Phấn hoa'),
('BN20079',N'Phan Thị Kim',N'Nữ','1986-10-10','0901000029',N'Quận 6, TP.HCM','O+',N'Không có'),
('BN20080',N'Võ Minh Quân',N'Nam','2001-05-05','0901000030',N'Quận 10, TP.HCM','AB+',N'Đậu phộng'),

('BN20081',N'Nguyễn Thị Thảo',N'Nữ','1999-09-19','0901000031',N'Quận 4, TP.HCM','A-',N'Hải sản'),
('BN20082',N'Trần Văn Hải',N'Nam','1988-12-21','0901000032',N'Quận 8, TP.HCM','B-',N'Không có'),
('BN20083',N'Phạm Gia Huy',N'Nam','1996-07-07','0901000033',N'Gò Vấp, TP.HCM','O+',N'Sulfa'),
('BN20084',N'Lê Thị Xuân',N'Nữ','1972-03-30','0901000034',N'Hóc Môn, TP.HCM','A+',N'Phấn hoa'),
('BN20085',N'Đỗ Văn Minh',N'Nam','1981-11-11','0901000035',N'Quận 11, TP.HCM','AB-',N'Không có'),
('BN20086',N'Nguyễn Thị Hạnh',N'Nữ','1997-02-22','0901000036',N'Tân Bình, TP.HCM','O-',N'Đậu nành'),
('BN20087',N'Bùi Quốc Thái',N'Nam','1992-06-06','0901000037',N'Quận 9, TP.HCM','A+',N'Trứng'),
('BN20088',N'Phan Minh Anh',N'Nữ','2004-04-04','0901000038',N'Quận 2, TP.HCM','B+',N'Không có'),
('BN20089',N'Võ Thị Ngọc',N'Nữ','1984-08-18','0901000039',N'Quận 5, TP.HCM','O+',N'Hải sản'),
('BN20090',N'Trần Văn Phúc',N'Nam','1990-10-30','0901000040',N'Bình Tân, TP.HCM','AB+',N'Sulfa'),

('BN20091',N'Lê Gia Bảo',N'Nam','1998-01-09','0901000041',N'Quận 7, TP.HCM','A-',N'Không có'),
('BN20092',N'Nguyễn Thị Lan Anh',N'Nữ','1995-05-15','0901000042',N'Quận 3, TP.HCM','O-',N'Phấn hoa'),
('BN20093',N'Phạm Văn Hùng',N'Nam','1987-07-27','0901000043',N'Quận 6, TP.HCM','B+',N'Đậu phộng'),
('BN20094',N'Đặng Thị Ngọc Mai',N'Nữ','2000-12-12','0901000044',N'Thủ Đức, TP.HCM','A+',N'Không có'),
('BN20095',N'Hoàng Văn Khoa',N'Nam','1993-03-23','0901000045',N'Quận 12, TP.HCM','O+',N'Sulfa');

INSERT INTO Encounters
(AppointmentID, PatientID, DoctorID, StartTime, EndTime, Status)
SELECT 
NULL,
P.PatientID,
D.EmployeeID,
DATEADD(MINUTE, ABS(CHECKSUM(NEWID())) % 480, GETDATE()),
NULL,
'Completed'
FROM Patients P
CROSS APPLY (
    SELECT TOP 1 EmployeeID
    FROM Employees E
    WHERE E.RoleID = (SELECT RoleID FROM Roles WHERE RoleName='Doctor')
    ORDER BY NEWID()
) D;

INSERT INTO VitalSigns (EncounterID, Temperature, BloodPressure, HeartRate, SPO2, Weight, Height, Notes)
SELECT 
E.EncounterID,
36 + (ABS(CHECKSUM(NEWID())) % 20) / 10.0,
'120/80',
60 + ABS(CHECKSUM(NEWID())) % 40,
95 + ABS(CHECKSUM(NEWID())) % 5,
50 + ABS(CHECKSUM(NEWID())) % 40,
150 + ABS(CHECKSUM(NEWID())) % 40,
N'Sinh hiệu ổn định'
FROM Encounters E;

INSERT INTO MedicalRecords (EncounterID, ChiefComplaint, Symptoms, Diagnosis, ICDCode, Conclusion, Notes)
SELECT 
EncounterID,
N'Đau đầu',
N'Chóng mặt, mệt mỏi',
N'Viêm đường hô hấp nhẹ',
'J06.9',
N'Theo dõi ngoại trú',
N'Không biến chứng'
FROM Encounters;

INSERT INTO Prescriptions (EncounterID, DoctorID, Status)
SELECT EncounterID, DoctorID, 'Issued'
FROM Encounters;

INSERT INTO PrescriptionDetails (PrescriptionID, MedicineID, Quantity, Dosage, Frequency, Instruction)
SELECT 
P.PrescriptionID,
M.MedicineID,
2,
N'1 viên/lần',
N'2 lần/ngày',
N'Uống sau ăn'
FROM Prescriptions P
CROSS APPLY (
    SELECT TOP 1 MedicineID
    FROM Medicines
    ORDER BY NEWID()
) M;

INSERT INTO LabRequests (EncounterID, DoctorID, TestType, Status)
SELECT 
EncounterID,
DoctorID,
N'Xét nghiệm máu tổng quát',
'Completed'
FROM Encounters;

INSERT INTO LabResults (LabID, ResultText, CompletedAt)
SELECT 
LabID,
N'Chỉ số bình thường',
GETDATE()
FROM LabRequests;

WITH Ranked AS (
    SELECT 
        E.EncounterID,
        E.DoctorID,
        ROW_NUMBER() OVER (PARTITION BY E.DoctorID ORDER BY NEWID()) rn
    FROM Encounters E
)
INSERT INTO PatientQueues (EncounterID, Priority, Status, CurrentStep)
SELECT 
EncounterID,
'Normal',
'Waiting',
N'Chờ khám'
FROM Ranked
WHERE rn <= 5;

INSERT INTO Invoices (EncounterID, PatientID, Total, Status)
SELECT 
E.EncounterID,
E.PatientID,
500000,
'Unpaid'
FROM Encounters E;

INSERT INTO Payments (EncounterID, Amount, Method, Status, PaidAt, PatientID)
SELECT 
EncounterID,
500000,
'Cash',
'Paid',
GETDATE(),
PatientID
FROM Encounters;




