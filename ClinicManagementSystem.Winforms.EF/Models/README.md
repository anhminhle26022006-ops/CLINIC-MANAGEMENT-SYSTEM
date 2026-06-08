# Models

`Models` chua domain entity gan voi schema trong `Database/CMS.sql`.

Quy uoc:

- Khong tao model rieng cho role neu DB khong co bang rieng. `Admin`, `Doctor`, `Nurse`, `Pharmacist`, `Technician`, `Receptionist` deu la `Employee` + `Role`.
- DTO phuc vu UI/API/BUS co the dat theo man hinh hoac use case, nhung Models nen giu theo entity DB.
- ID trong Models dung ten cot DB hien tai, vi du `EmployeeID`, `PatientID`, `DepartmentID`.
- Status trong Models de `string` vi DB dang luu `NVARCHAR`; dung constants trong `Core.Constants` o tang BUS/UI khi can so sanh.

Folder chinh:

- `Auth`: user, role, session, notification.
- `Staff`: employee chung cho moi role nhan su.
- `Facility`: department, room.
- `Scheduling`: shift, employee shift, doctor schedule.
- `Patients`: patient, insurance, identifier.
- `Clinical`: appointment, encounter, queue, record, vital sign, follow-up, transfer.
- `Diagnostics`: lab va imaging.
- `Pharmacy`: medicine, prescription, dispense.
- `Billing`: payment, invoice.
- `Admin`: audit log.
