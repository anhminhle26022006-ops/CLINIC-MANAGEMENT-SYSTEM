CREATE TABLE Roles (
   RoleID INT PRIMARY KEY IDENTITY,
   RoleName NVARCHAR(100),
   Description NVARCHAR(255)
);

CREATE TABLE Users (
   UserID INT PRIMARY KEY IDENTITY,
   Username VARCHAR(100) UNIQUE,
   PasswordHash VARCHAR(255),
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
   EmployeeCode VARCHAR(50) UNIQUE,
   FullName NVARCHAR(255),
   RoleID INT,
   DepartmentID INT,
   Phone VARCHAR(20),
   Status NVARCHAR(50),

   FOREIGN KEY (RoleID) REFERENCES Roles(RoleID),
   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
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
CREATE TABLE Appointments (
   AppointmentID INT PRIMARY KEY IDENTITY,
   PatientID INT,
   DoctorID INT,
   DepartmentID INT,
   RoomID INT,
   AppointmentDate DATETIME,
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
   Status NVARCHAR(50),

   FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID),
   FOREIGN KEY (PatientID)
   REFERENCES Patients(PatientID),

FOREIGN KEY (DoctorID)
   REFERENCES Employees(EmployeeID)
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
   Status NVARCHAR(50)
);

CREATE TABLE LabResults (
   ResultID INT PRIMARY KEY IDENTITY,
   LabID INT,
   ResultText NVARCHAR(MAX),
   FileURL NVARCHAR(MAX),
   CompletedAt DATETIME
   FOREIGN KEY (LabID)
   REFERENCES LabRequests(LabID)
);
CREATE TABLE ImagingRequests (
   ImagingRequestID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   ImagingServiceID INT,
   BodyPart NVARCHAR(100),
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
   ExpiryDate DATE,
);

CREATE TABLE Prescriptions (
   PrescriptionID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   Status NVARCHAR(50)
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
   Dosage NVARCHAR(100)
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
   Status NVARCHAR(50)
   FOREIGN KEY (PrescriptionID)
   REFERENCES Prescriptions(PrescriptionID),

FOREIGN KEY (PharmacistID)
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

FOREIGN KEY (PatientID)
REFERENCES Patients(PatientID),
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);
CREATE TABLE Services (
   ServiceID INT PRIMARY KEY IDENTITY,
   ServiceName NVARCHAR(255),
   Price DECIMAL(18,2),
   DepartmentID INT
   FOREIGN KEY (DepartmentID)
   REFERENCES Departments(DepartmentID)
);

CREATE TABLE Invoices (
   InvoiceID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   PatientID INT,
   Total DECIMAL(18,2),
   Status NVARCHAR(50)
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
   Price DECIMAL(18,2)
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
   UploadedAt DATETIME DEFAULT GETDATE()
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);
CREATE TABLE FollowUps (
   FollowUpID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   FollowUpDate DATETIME,
   Status NVARCHAR(50)
   FOREIGN KEY (EncounterID)
   REFERENCES Encounters(EncounterID)
);

CREATE TABLE Transfers (
   TransferID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Reason NVARCHAR(MAX),
   Severity NVARCHAR(50),
   Status NVARCHAR(50)
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
   IsRead BIT DEFAULT 0
   FOREIGN KEY (UserID)
   REFERENCES Users(UserID)
);

CREATE TABLE AuditLogs (
   LogID INT PRIMARY KEY IDENTITY,
   UserID INT,
   Action NVARCHAR(100),
   TableName NVARCHAR(100),
   CreatedAt DATETIME DEFAULT GETDATE()
   FOREIGN KEY (UserID)
   REFERENCES Users(UserID)
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
CREATE TABLE ImagingServices (
    ImagingServiceID INT PRIMARY KEY IDENTITY,
    ServiceCode VARCHAR(50),
    ServiceName NVARCHAR(255),
    Modality NVARCHAR(50),
    Price DECIMAL(18,2),
    IsActive BIT DEFAULT 1
);