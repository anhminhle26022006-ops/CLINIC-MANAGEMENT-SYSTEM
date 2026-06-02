-- Script to create HealthCareDB database and schema for MOMO_QR_DANANG (3-Tier)
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'HealthCareDB')
BEGIN
    CREATE DATABASE HealthCareDB;
END
GO

USE HealthCareDB;
GO

-- 1. Users Table
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;
GO
CREATE TABLE dbo.Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Role VARCHAR(50) NOT NULL, -- Admin, Doctor, Technician, Receptionist
    Email VARCHAR(100) NULL
);
GO

-- 2. Patients Table
IF OBJECT_ID('dbo.Patients', 'U') IS NOT NULL
    DROP TABLE dbo.Patients;
GO
CREATE TABLE dbo.Patients (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    PatientCode VARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
    Gender NVARCHAR(20) NOT NULL, -- Nam, Nữ
    Phone VARCHAR(20) NULL,
    Address NVARCHAR(250) NULL
);
GO

-- 3. Doctors Table
IF OBJECT_ID('dbo.Doctors', 'U') IS NOT NULL
    DROP TABLE dbo.Doctors;
GO
CREATE TABLE dbo.Doctors (
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    DoctorCode VARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL,
    Department NVARCHAR(100) NOT NULL
);
GO

-- 4. Requests Table (Imaging / Lab Requests)
IF OBJECT_ID('dbo.Requests', 'U') IS NOT NULL
    DROP TABLE dbo.Requests;
GO
CREATE TABLE dbo.Requests (
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    RequestCode VARCHAR(50) NOT NULL UNIQUE,
    PatientID INT NOT NULL FOREIGN KEY REFERENCES dbo.Patients(PatientID),
    DoctorID INT NOT NULL FOREIGN KEY REFERENCES dbo.Doctors(DoctorID),
    ServiceType NVARCHAR(100) NOT NULL, -- e.g. Chụp MRI, Chụp X-quang, Xét nghiệm máu, Điện tâm đồ
    RequestNote NVARCHAR(500) NULL,
    Priority NVARCHAR(50) NOT NULL DEFAULT N'Thường', -- Ưu tiên, Thường, Ưu tiên cao
    RequestDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL DEFAULT N'Chờ xử lý', -- Chờ xử lý, Đang xử lý, Hoàn thành
    ResultFile VARCHAR(500) NULL, -- Local relative path or Base64 string for scans/MRI images
    ResultPDF VARCHAR(500) NULL, -- Local relative path for uploaded result PDF reports
    LabValues NVARCHAR(MAX) NULL -- JSON or custom text values for lab results (e.g. Glucose: 5.6, WBC: 7.2)
);
GO

-- 5. Shifts Table (Technician Shifts)
IF OBJECT_ID('dbo.Shifts', 'U') IS NOT NULL
    DROP TABLE dbo.Shifts;
GO
CREATE TABLE dbo.Shifts (
    ShiftID INT IDENTITY(1,1) PRIMARY KEY,
    ShiftDate DATE NOT NULL,
    ShiftName NVARCHAR(50) NOT NULL, -- Sáng, Chiều
    Room NVARCHAR(50) NOT NULL, -- e.g. P.101, P.102
    Department NVARCHAR(100) NOT NULL, -- e.g. Khoa Nội, Khoa Tim mạch, Chẩn đoán hình ảnh
    Status NVARCHAR(50) NOT NULL DEFAULT N'Đã đăng ký', -- Đã đăng ký, Chờ xác nhận
    TechnicianName NVARCHAR(100) NOT NULL DEFAULT N'Lữ Võ Hoàng Phúc'
);
GO
