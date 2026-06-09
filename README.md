<h1 align="center">🏥 Clinic Management System</h1>
<h3 align="center">HIS Mini — Hospital Information System Simulation</h3>

<p align="center">
  <img src="https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows" />
  <img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp" />
  <img src="https://img.shields.io/badge/UI-WinForms-512BD4?style=for-the-badge&logo=dotnet" />
  <img src="https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver" />
  <img src="https://img.shields.io/badge/Type-Course%20Project-orange?style=for-the-badge" />
</p>

---

## 📖 Tổng quan

**Clinic Management System** là một hệ thống thông tin phòng khám thu nhỏ (**HIS Mini**), mô phỏng toàn bộ quy trình khám chữa bệnh ngoại trú — từ đăng ký bệnh nhân, khám bệnh, xét nghiệm, chẩn đoán hình ảnh, kê đơn thuốc, cho đến thanh toán và lưu hồ sơ bệnh án điện tử.

Dự án được xây dựng bằng **C# WinForms (.NET Framework)** với kiến trúc phân tầng rõ ràng, phục vụ mục đích học thuật trong môn **Lập trình ứng dụng Desktop**.

---

## ✨ Tính năng nổi bật

| # | Tính năng | Mô tả |
|---|-----------|-------|
| 1 | 🔐 Phân quyền theo vai trò | Mỗi nhân viên đăng nhập đúng module theo vai trò |
| 2 | 🗂️ Hồ sơ bệnh án điện tử (EMR) | Lưu trữ đầy đủ lịch sử khám, chẩn đoán, đơn thuốc |
| 3 | 🧪 Xét nghiệm & Chẩn đoán hình ảnh | Xử lý kết quả Lab, upload MRI/X-Ray (PACS-like) |
| 4 | 💊 Quản lý nhà thuốc | Cấp phát thuốc, kiểm soát tồn kho, thanh toán |
| 5 | 📋 Hàng chờ thông minh | Tạo và quản lý hàng chờ khám theo thời gian thực |
| 6 | 💳 Thanh toán | Xử lý thanh toán, tích hợp mô phỏng cổng thanh toán |
| 7 | 📊 Thống kê & Báo cáo | Báo cáo tổng hợp dành cho Admin |
| 8 | 🗑️ Soft-delete | Xoá mềm và lưu trữ dữ liệu an toàn |

---

## 🧩 Các module chức năng

<details>
<summary><b>🟦 Module Lễ tân (Reception)</b></summary>

- Đăng ký bệnh nhân mới / cũ
- Đặt lịch hẹn khám
- Check-in và tạo hàng chờ
- Xử lý thanh toán viện phí
- Nhắc lịch hẹn tự động

</details>

<details>
<summary><b>🟩 Module Bác sĩ (Doctor)</b></summary>

- Xem danh sách bệnh nhân chờ khám
- Tiếp nhận và khám bệnh
- Lập hồ sơ bệnh án điện tử (EMR)
- Yêu cầu xét nghiệm / chẩn đoán hình ảnh
- Kê đơn thuốc
- Đặt lịch tái khám

</details>

<details>
<summary><b>🟨 Module Y tá (Nurse)</b></summary>

- Đo và nhập chỉ số sinh hiệu (huyết áp, mạch, nhiệt độ, cân nặng…)
- Quản lý hàng chờ bệnh nhân
- Theo dõi dữ liệu lâm sàng

</details>

<details>
<summary><b>🟪 Module Kỹ thuật viên (Technician)</b></summary>

- Tiếp nhận phiếu xét nghiệm / chẩn đoán hình ảnh từ bác sĩ
- Nhập và xử lý kết quả xét nghiệm (Lab)
- Upload ảnh MRI / X-Ray (giao diện dạng PACS)
- Quản lý và trả kết quả cho bác sĩ

</details>

<details>
<summary><b>🟧 Module Dược sĩ (Pharmacist)</b></summary>

- Tiếp nhận và xử lý đơn thuốc từ bác sĩ
- Cấp phát thuốc cho bệnh nhân
- Quản lý danh mục thuốc và tồn kho
- Xuất hóa đơn nhà thuốc

</details>

<details>
<summary><b>🟥 Module Quản trị (Admin)</b></summary>

- Quản lý tài khoản & phân quyền nhân viên
- Quản lý danh mục chuyên khoa, phòng khám
- Quản lý ca trực
- Xem thống kê và báo cáo hệ thống

</details>

---

## 🏗️ Kiến trúc hệ thống

Dự án tuân theo kiến trúc **3 tầng (3-Layer Architecture)** kết hợp mô hình **DTO**:

```
┌─────────────────────────────────────────┐
│        Presentation Layer               │
│         (WinForms UI Forms)             │
└──────────────┬──────────────────────────┘
               │  gọi xuống
┌──────────────▼──────────────────────────┐
│       Business Logic Layer (BUS)        │
│    Xử lý nghiệp vụ & kiểm tra logic     │
└──────────────┬──────────────────────────┘
               │  gọi xuống
┌──────────────▼──────────────────────────┐
│      Data Access Layer (DAL)            │
│   Thực thi truy vấn SQL, ADO.NET        │
└──────────────┬──────────────────────────┘
               │  kết nối
┌──────────────▼──────────────────────────┐
│         SQL Server Database             │
│        (CMS.sql — schema đầy đủ)        │
└─────────────────────────────────────────┘

         ↕ Dữ liệu truyền qua ↕
      DTO (Data Transfer Objects)
```

### 📦 Mô tả các tầng

| Tầng | Thư mục | Vai trò |
|------|---------|---------|
| **UI** | `ClinicManagementSystem.Winforms/` | Giao diện WinForms từng vai trò |
| **BUS** | `BUS/Services/` | Xử lý nghiệp vụ, validate dữ liệu |
| **DAL** | `DAL/Repositories/` | Truy vấn SQL Server qua ADO.NET |
| **DTO** | `DTO/` | Đối tượng truyền dữ liệu giữa các tầng |
| **Database** | `Database/CMS.sql` | Script tạo schema và dữ liệu mẫu |

---

## 🗄️ Cơ sở dữ liệu

**SQL Server** — Schema chính gồm các nhóm bảng:

```
👤 Người dùng & Nhân viên
   ├── Users, Roles
   └── Employees

🏥 Bệnh nhân & Lịch khám
   ├── Patients
   ├── Appointments
   └── Queue

📋 Hồ sơ lâm sàng
   ├── MedicalRecords (EMR)
   ├── VitalSigns
   ├── LabRequests / LabResults
   └── ImagingRequests / ImagingResults

💊 Nhà thuốc & Thanh toán
   ├── Prescriptions / PrescriptionItems
   ├── Medicines, Inventory
   └── Payments / Invoices
```

---

## 🔄 Quy trình nghiệp vụ

```
  [Lễ tân] Đăng ký / Đặt lịch
        │
        ▼
  [Lễ tân] Check-in → Tạo hàng chờ
        │
        ▼
  [Y tá] Đo & nhập chỉ số sinh hiệu
        │
        ▼
  [Bác sĩ] Khám bệnh, lập EMR
        │
        ├──────────────────────────────┐
        ▼                              ▼
  [Kỹ thuật viên]              [Bác sĩ] Chẩn đoán
  Xét nghiệm / CĐHA            + Kê đơn thuốc
        │                              │
        └──────────────────────────────┘
                       │
                       ▼
           [Dược sĩ] Cấp phát thuốc
                       │
                       ▼
             [Lễ tân] Thanh toán
                       │
                       ▼
         ✅ Hoàn tất → Lưu vào EMR
```

---

## 👥 Phân quyền hệ thống

| Vai trò | Quyền truy cập |
|---------|---------------|
| **Lễ tân** | Đăng ký bệnh nhân, đặt lịch, check-in, thanh toán |
| **Bác sĩ** | Khám bệnh, EMR, yêu cầu xét nghiệm, kê đơn |
| **Y tá** | Nhập sinh hiệu, quản lý hàng chờ |
| **Kỹ thuật viên** | Xử lý xét nghiệm, upload CĐHA, trả kết quả |
| **Dược sĩ** | Cấp phát thuốc, quản lý kho, xuất hóa đơn |
| **Quản trị viên** | Toàn quyền: nhân viên, phân quyền, thống kê |

---

## 💾 Công nghệ sử dụng

| Thành phần | Chi tiết |
|------------|----------|
| Ngôn ngữ | C# (.NET Framework) |
| Giao diện | Windows Forms (WinForms) |
| Cơ sở dữ liệu | Microsoft SQL Server |
| Truy cập dữ liệu | ADO.NET |
| Kiến trúc | 3-Layer + DTO Pattern |
| IDE | Visual Studio |
| Khác | Mock data seeding, API integration (optional) |

---

## 🚀 Hướng dẫn cài đặt & chạy

### Yêu cầu hệ thống
- Visual Studio 2019 trở lên
- .NET Framework 4.7.2+
- Microsoft SQL Server (LocalDB / Express / Full)
- SQL Server Management Studio (SSMS) *(khuyến nghị)*

### Các bước thực hiện

```bash
# 1. Clone repository
git clone https://github.com/anhminhle26022006-ops/CLINIC-MANAGEMENT-SYSTEM.git

# 2. Mở solution
#    Mở file ClinicManagementSystem.Winforms.sln trong Visual Studio

# 3. Restore NuGet packages
#    Visual Studio sẽ tự động restore khi mở solution

# 4. Import database
#    Mở SQL Server Management Studio
#    Chạy script: Database/CMS.sql

# 5. Cập nhật connection string
#    Mở App.config
#    Sửa <connectionStrings> cho đúng với SQL Server instance của bạn

# 6. Build & Run
#    Nhấn F5 hoặc chọn Debug > Start Debugging
```

---

## 📌 Lưu ý

> ⚠️ Đây là **dự án học thuật** — không dùng cho môi trường bệnh viện thực tế.

- Tập trung vào thiết kế quy trình nghiệp vụ, kiến trúc phần mềm và lập trình hướng đối tượng (OOP)
- Dữ liệu trong hệ thống là dữ liệu mô phỏng (mock data)
- Một số tính năng thanh toán được tích hợp ở mức mô phỏng (simulation)

---

## 👨‍🎓 Nhóm thực hiện

> 📚 **Môn học:** Lập trình ứng dụng Desktop
> 🏫 **Trường:** Đại học Kinh tế TP.HCM (UEH)

| STT | Họ và tên |
|-----|-----------|
| 1 | Lê Minh Anh |
| 2 | Lữ Võ Hoàng Phúc |
| 3 | Đinh Thị Anh Thư |
| 4 | Từ Trương Thanh Trúc |
| 5 | Nguyễn Đinh Thảo Nhi |

---

<p align="center">
  <i>Built with ❤️ by the team — UEH Desktop Application Development Course</i>
</p>
