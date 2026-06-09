# Entity Framework Core conversion notes

This copy keeps the existing WinForms, BUS, DTO, Models, Core and ServicesExternal projects so the UI contract stays compatible with the original application.

## What changed

- Added Entity Framework Core SQL Server to `DAL/DAL.csproj`.
- Added `DAL/DataContext/ClinicDbContext.cs`.
- Mapped all model classes to the existing CMS database tables and primary keys from `Database/CMS.sql`.
- Converted the main DAL repositories from manual `DatabaseHelper` queries to EF Core:
  - `Auth/UserDAL.cs`
  - `Clinical/PatientDAL.cs`
  - `Clinical/ServiceRequestDAL.cs`
  - `Facility/DepartmentDAL.cs`
  - `Facility/RoomDAL.cs`
  - `Scheduling/EmployeeShiftDAL.cs`
  - `Scheduling/WorkShiftDAL.cs`
  - `Staff/EmployeeDAL.cs`
  - `Technician/TechnicianRequestDAL.cs`

## Why DTO and BUS were kept

The WinForms screens and BUS interfaces still use DTO types directly. Removing `DTO` or `BUS` would break compilation and require a larger UI refactor. The ORM change is therefore applied at the DAL/database access layer while preserving the existing UI-facing structure.

## Remaining legacy SQL

`DatabaseHelper` is still present for database bootstrap, schema helper checks, the technician seed tool, and the external API sync code. These are integration/setup paths rather than the main repository CRUD paths converted above.
