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
   RoomCode VARCHAR(50),
   DepartmentID INT,
   Status NVARCHAR(50),

   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Employees (
   EmployeeID INT PRIMARY KEY IDENTITY,
   EmployeeCode VARCHAR(50),
   FullName NVARCHAR(255),
   RoleName NVARCHAR(100),
   DepartmentID INT,
   Phone VARCHAR(20),
   Status NVARCHAR(50),

   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
CREATE TABLE Patients (
   PatientID INT PRIMARY KEY IDENTITY,
   PatientCode VARCHAR(50),
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
   FOREIGN KEY (DoctorID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE Encounters (
   EncounterID INT PRIMARY KEY IDENTITY,
   AppointmentID INT,
   PatientID INT,
   DoctorID INT,
   StartTime DATETIME,
   EndTime DATETIME,
   Status NVARCHAR(50),

   FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
);

CREATE TABLE Queue (
   QueueID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Priority NVARCHAR(50),
   Status NVARCHAR(50),
   CurrentStep NVARCHAR(50),

   FOREIGN KEY (EncounterID) REFERENCES Encounters(EncounterID)
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
);
CREATE TABLE ImagingRequests (
   ImagingID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   Type NVARCHAR(100),
   Status NVARCHAR(50)
);

CREATE TABLE ImagingResults (
   ResultID INT PRIMARY KEY IDENTITY,
   ImagingID INT,
   ImageURL NVARCHAR(MAX),
   PDFURL NVARCHAR(MAX),
   Notes NVARCHAR(MAX)
);
CREATE TABLE Medicines (
   MedicineID INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(255),
   Unit NVARCHAR(50),
   Price DECIMAL(18,2),
   Stock INT
);

CREATE TABLE Prescriptions (
   PrescriptionID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   DoctorID INT,
   Status NVARCHAR(50)
);

CREATE TABLE PrescriptionDetails (
   DetailID INT PRIMARY KEY IDENTITY,
   PrescriptionID INT,
   MedicineID INT,
   Quantity INT,
   Dosage NVARCHAR(100)
);
CREATE TABLE Dispense (
   DispenseID INT PRIMARY KEY IDENTITY,
   PrescriptionID INT,
   PharmacistID INT,
   TotalAmount DECIMAL(18,2),
   Status NVARCHAR(50)
);

CREATE TABLE Payments (
   PaymentID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Amount DECIMAL(18,2),
   Method NVARCHAR(50),
   Status NVARCHAR(50),
   PaidAt DATETIME
);
CREATE TABLE Services (
   ServiceID INT PRIMARY KEY IDENTITY,
   ServiceName NVARCHAR(255),
   Price DECIMAL(18,2),
   DepartmentID INT
);

CREATE TABLE Invoices (
   InvoiceID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   PatientID INT,
   Total DECIMAL(18,2),
   Status NVARCHAR(50)
);

CREATE TABLE InvoiceDetails (
   DetailID INT PRIMARY KEY IDENTITY,
   InvoiceID INT,
   ServiceID INT,
   Quantity INT,
   Price DECIMAL(18,2)
);
CREATE TABLE Files (
   FileID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   FileType NVARCHAR(50),
   FileURL NVARCHAR(MAX),
   UploadedAt DATETIME DEFAULT GETDATE()
);
CREATE TABLE FollowUps (
   FollowUpID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   FollowUpDate DATETIME,
   Status NVARCHAR(50)
);

CREATE TABLE Transfers (
   TransferID INT PRIMARY KEY IDENTITY,
   EncounterID INT,
   Reason NVARCHAR(MAX),
   Severity NVARCHAR(50),
   Status NVARCHAR(50)
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

   FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
CREATE TABLE Notifications (
   NotificationID INT PRIMARY KEY IDENTITY,
   UserID INT,
   Message NVARCHAR(MAX),
   IsRead BIT DEFAULT 0
);

CREATE TABLE AuditLogs (
   LogID INT PRIMARY KEY IDENTITY,
   UserID INT,
   Action NVARCHAR(100),
   TableName NVARCHAR(100),
   CreatedAt DATETIME DEFAULT GETDATE()
);
