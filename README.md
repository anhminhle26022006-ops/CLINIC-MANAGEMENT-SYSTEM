🏥 Clinic Management System (HIS Mini)
📌 Course Project – Desktop Application Development

Built with C# WinForms + SQL Server

📖 Overview

Clinic Management System is a mini Hospital Information System (HIS) designed for outpatient clinic workflow simulation.

The system covers end-to-end medical processes including:

Patient registration
Appointment scheduling
Queue management
Medical examination (EMR)
Lab & Imaging workflow
Pharmacy dispensing
Billing & payment
Role-based access control

It is developed as a desktop application course project using a layered architecture.

🧠 Key Features

🟦 Reception Module
Patient registration
Appointment booking
Check-in management
Queue generation
Payment handling
🟩 Doctor Module
Patient examination
Medical records (EMR)
Lab & imaging requests
Prescription creation
Follow-up scheduling
🟨 Nurse Module
Vital signs input
Patient queue handling
Clinical data tracking
🟪 Technician Module
Lab test processing
MRI/X-Ray upload
Result management (PACS-like view)
🟧 Pharmacist Module
Prescription processing
Medicine dispensing
Inventory control
Pharmacy billing
🟥 Admin Module
User & role management
Employee management
Department & room configuration
System analytics & reports

🏗️ Architecture

The project follows a 3-layer architecture:

Presentation Layer (WinForms UI)
        ↓
Business Logic Layer (BUS)
        ↓
Data Access Layer (DAL)
        ↓
SQL Server Database

📦 Layers Description

DTO (Data Transfer Object)
Transfers data between layers
DAL (Data Access Layer)
Handles SQL queries & database operations
BUS (Business Logic Layer)
Processes business rules
UI (WinForms Forms)
User interface for all roles

🗄️ Database

SQL Server Database
Core tables:
Users, Roles
Patients, Employees
Appointments, Queue
MedicalRecords (EMR)
VitalSigns
LabRequests / ImagingRequests
Prescriptions
Payments
Medicines, Inventory

🔄 System Workflow

Reception
   ↓
Patient Check-in
   ↓
Nurse (Vital Signs)
   ↓
Doctor Examination
   ↓
Lab / Imaging (if needed)
   ↓
Doctor Diagnosis + Prescription
   ↓
Pharmacist Dispensing
   ↓
Payment
   ↓
Completed → Stored in Medical Records

👥 Role-Based Access

Role	Access
Reception	Appointment, check-in, payment
Doctor	Diagnosis, EMR, prescription
Nurse	Vital signs
Technician	Lab & imaging
Pharmacist	Pharmacy & billing
Admin	System management

💾 Technologies Used

C# WinForms (.NET Framework)
SQL Server
ADO.NET
Layered Architecture (DAL / BUS / DTO)
Mock Data Seeding (optional API integration)

⚙️ Features Highlights

Real-time queue simulation
Role-based authentication
Medical record (EMR) system
Lab & imaging workflow
Pharmacy management system
Payment processing simulation
Soft-delete & archival system

🚀 How to Run

Clone repository
Open .sln file in Visual Studio
Restore NuGet packages
Import SQL database script into SQL Server
Update connection string in App.config
Run project

📌 Notes

This is a simulation system for academic purposes
Not intended for real hospital deployment
Focus on workflow design + architecture + OOP principles

👨‍🎓 Author
Desktop Application Development Course Project
Lê Minh Anh
Lữ Võ Hoàng Phúc
Đinh Thị Anh Thư
Từ Trương Thanh Trúc
Nguyễn Đinh Thảo Nhi
