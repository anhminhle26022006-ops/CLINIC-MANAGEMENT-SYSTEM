# Clinic Management System - Winforms UI Development Guide

This guide explains the architecture, directory structure, and UI component standards for the main user interface project: **`ClinicManagementSystem.Winforms`**.

---

## 📂 UI Project Folder Structure

The front-end is divided into specific folders based on their role and lifecycle in the application:

```
ClinicManagementSystem.Winforms/
├── Mainforms/        # Top-level window frames for each user role
├── UserControls/     # Role-specific component screens
├── Forms/            # Workflow dialogs and popup modal windows
├── Shareforms/       # Shared reusable forms and views across multiple roles
└── Controllers/      # UI Controllers coordinating UI state and BUS/DTO logic
```

### 1. `Mainforms/`
* **Role**: These are the top-level window frames (`Form`) containing sidebar menus, navigation logic, and host panels. There is exactly one main form for each role.
* **Key Components**:
  * `AdminMainform.cs`
  * `DoctorMainform.cs`
  * `NurseMainform.cs`
  * `ReceptionistMainform.cs`
  * `PharmacistMainform.cs`
  * `TechnicianMainform.cs`
* **Convention**: Do not put business logic or complex database queries here. Their only role is to route menu clicks and load the correct `UserControl` into the main content panel.

### 2. `UserControls/`
* **Role**: These are custom controls (`UserControl`) that make up the actual dashboards and functional pages loaded inside the `Mainforms` panels.
* **Organization**: Grouped into subdirectories by user role:
  * `UserControls/Admin/`
  * `UserControls/Doctor/`
  * `UserControls/Nurse/`
  * `UserControls/Reception/`
  * `UserControls/Pharmacist/`
  * `UserControls/Technician/`

### 3. `Forms/`
* **Role**: Standalone popups, login screens, or detail-heavy wizard windows (`Form`) that block input (modals) or act as standalone workflows.
* **Example**: Login screen (`LoginForm.cs`), Prescription editor popup, etc.

### 4. 🔗 `Shareforms/` (Shared Views)
* **What is it?**: This folder contains UI elements (both `Form` and `UserControl` types) that are **generic and shared across multiple different roles**.
* **Why separates them?**: Instead of duplicating calendar elements, shift requests, or employee profiles for doctors, nurses, and technicians, we centralize them here.
* **Key Components**:
  * `Shareforms/WorkingShifts/` (e.g., `ucDayView.cs`, `ucWeekView.cs`, `ucMonthView.cs`, `ShiftRequestForm.cs`) - Calendar components used by different roles to manage shifts.
* **Rule**: If a form or control is needed by more than one user role UI, it **must** be placed in `Shareforms` instead of `UserControls` or `Forms`.

### 5. `Controllers/`
* **Role**: Coordinating logic. Controllers handle actions, UI event routing, and map raw data from DTOs to UI lists. They keep UI code-behind files clean of heavy orchestration logic.

---

## 🎨 UI Guidelines & Best Practices

1. **Keep Code-Behind (`.cs`) Clean**: Avoid direct SQL calls or complex loop transformations in event handlers. Delegated actions should call the `Controllers` or the `BUS` layer.
2. **Modals & Dialogs**: Always call modal forms using `.ShowDialog()` rather than `.Show()` to block parent inputs and manage focus/cleanup correctly.
3. **Responsive Flow Layouts**: 
   * Use `TableLayoutPanel` and `FlowLayoutPanel` for dynamic components (like calendar cells or list tiles).
   * Apply anchor properties (`Top, Bottom, Left, Right`) or docking (`Dock = Fill`) to controls so they scale gracefully when users maximize the window.
4. **Resources & Assets**: Keep images, icons, and logo assets centralized in the `Properties/Resources.resx` file to prevent hardcoded file paths that break in deployment.
