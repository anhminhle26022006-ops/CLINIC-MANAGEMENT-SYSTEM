# Clinic Management System - Backend Development & Structure Guide

This guide explains the project structure and architectural rules for the **DTO**, **DAL**, and **BUS** projects in this solution. Follow these conventions when adding new files to maintain a clean, organized codebase.

---

## 📂 Project Structure Overview

The backend is organized around **domains** rather than flat directories. The core domains are:

1. **`Auth`** - Authentication, authorization, session management, roles, and permissions.
2. **`Clinical`** - Clinical data, encounters, vital signs, prescriptions, medical records, and payments.
3. **`Facility`** - Clinics, departments, rooms, inventory, and supplier info.
4. **`Integrations`** - Syncing tools, external API integrations.
5. **`Scheduling`** - Appointments, doctor schedules, and shifts.
6. **`Staff`** - Employee profiles, receptionist/doctor/nurse lists.
7. **`Technician`** - Technical services, imaging request workflows, and technician-specific views.

---

## 🛠️ Where to Place New Files

When creating a new entity or feature, you will typically create files in three projects: **DTO**, **DAL**, and **BUS**.

### 1. DTO Project (`DTO.csproj`)
Data Transfer Objects (DTOs) contain simple data properties without business logic.
* **Rule**: Place them in `DTO/[DomainName]/` and keep their namespace as `namespace DTO`.
* **Example Folders**:
  * `DTO/Clinical/Payments/` - Payment and Billing DTOs.
  * `DTO/Clinical/Prescription/` - Medicine and Prescription DTOs.
  * `DTO/Clinical/Queue/` - Patient and Doctor Queue DTOs.
  * `DTO/Clinical/ERM/` - Electronic Record Management history DTOs.
  * `DTO/Facility/` - Department, Room, and Inventory DTOs.

### 2. DAL Project (`DAL.csproj`)
Data Access Layer (DAL) handles raw database operations using SQL/stored procedures.
* **Rule 1 (Interfaces)**: Place repository interfaces under `DAL/Interfaces/[DomainName]/`.
  * *Namespace*: `namespace DAL.Interfaces`
* **Rule 2 (Repositories)**: Place SQL-based repositories under `DAL/Repositories/[DomainName]/`.
  * *Namespace*: `namespace DAL.Repositories`
* **Example**:
  * Interface: `DAL/Interfaces/Staff/IEmployeeDAL.cs`
  * Repository: `DAL/Repositories/Staff/EmployeeDAL.cs`

### 3. BUS Project (`BUS.csproj`)
Business Logic Layer (BUS) acts as the bridge between the UI and DAL, handling validations and transaction orchestration.
* **Rule 1 (Interfaces)**: Place service interfaces under `BUS/Interfaces/[DomainName]/`.
  * *Namespace*: `namespace BUS.Interfaces`
* **Rule 2 (Services)**: Place business services under `BUS/Services/[DomainName]/`.
  * *Namespace*: `namespace BUS.Services`
* **Example**:
  * Interface: `BUS/Interfaces/Staff/IEmployeeBUS.cs`
  * Service: `BUS/Services/Staff/EmployeeBUS.cs`

---

## 📝 Naming Conventions

Maintain consistent suffix naming for all classes:

| Layer | Class Suffix | Interface Prefix | Example Implementation |
| :--- | :--- | :--- | :--- |
| **DTO** | `DTO` / `Dto` | *None* | `PatientDTO` / `VitalSignDto` |
| **DAL** | `DAL` / `Repository` | `I` | `EncounterDAL : IEncounterDAL` |
| **BUS** | `BUS` / `Service` | `I` | `EncounterBUS : IEncounterBUS` |

---

## ⚡ Architectural Principles & Checklist

1. **Keep Namespaces Consistent**: To avoid compilation errors when moving files, keep namespaces general (e.g., use `namespace DTO` for all DTO subfolders, `namespace DAL.Repositories` for repositories).
2. **Never Put Files at the Project Root**: Flat files at the root of `DTO`, `DAL`, or `BUS` make the codebase cluttered. Always assign a file to one of the 7 core domains.
3. **No Direct DAL Calls from UI**: The Windows Forms UI must *always* call the **BUS** layer. The BUS layer calls the **DAL** layer.
4. **Use DatabaseHelper Safely**: Implement parameterized queries or SQL parameters (`SqlParameter[]`) to prevent SQL injection.
