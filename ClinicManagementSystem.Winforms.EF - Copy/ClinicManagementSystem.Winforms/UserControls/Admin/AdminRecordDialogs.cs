using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public static class AdminRecordDialogs
    {
        private sealed class Option
        {
            public string Text { get; init; }
            public int Value { get; init; }

            public override string ToString()
            {
                return Text;
            }
        }

        public static void ShowUser(UserDTO user)
        {
            ShowDetails("Chi tiết tài khoản", new Dictionary<string, string>
            {
                ["Username"] = user.Username,
                ["Họ tên"] = user.Name,
                ["Vai trò"] = user.Role,
                ["Khoa/Phòng"] = user.DepartmentName,
                ["Email"] = user.Email,
                ["Trạng thái"] = user.IsActive ? "Đang hoạt động" : "Đã khóa"
            });
        }

        public static bool EditUser(UserDTO source, IEnumerable<string> roles, out UserDTO edited)
        {
            edited = null;
            using Form form = CreateForm("Sửa tài khoản", 520, 390);
            TableLayoutPanel layout = CreateEditorLayout(form, 6);

            TextBox txtName = AddText(layout, "Họ tên", source.Name);
            TextBox txtEmail = AddText(layout, "Email", source.Email);
            TextBox txtPassword = AddText(layout, "Mật khẩu", source.Password);
            ComboBox cboRole = AddCombo(layout, "Vai trò", roles.Select((role, index) => new Option { Text = role, Value = index }).ToList());
            SelectText(cboRole, source.Role);
            CheckBox chkActive = AddCheck(layout, "Trạng thái", "Đang hoạt động", source.IsActive);

            if (ShowEditor(form) != DialogResult.OK)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Họ tên và mật khẩu không được để trống.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            edited = new UserDTO
            {
                UserID = source.UserID,
                Username = source.Username,
                Password = txtPassword.Text.Trim(),
                Name = txtName.Text.Trim(),
                Role = ((Option)cboRole.SelectedItem).Text,
                Email = txtEmail.Text.Trim(),
                IsActive = chkActive.Checked,
                EmployeeID = source.EmployeeID,
                EmployeeUUID = source.EmployeeUUID,
                DepartmentID = source.DepartmentID,
                DepartmentName = source.DepartmentName
            };
            return true;
        }

        public static bool CreateUser(IEnumerable<string> roles, IReadOnlyList<DepartmentDTO> departments, out UserDTO created)
        {
            created = null;
            using Form form = CreateForm("Thêm tài khoản", 540, 470);
            TableLayoutPanel layout = CreateEditorLayout(form, 8);

            TextBox txtUsername = AddText(layout, "Username", "");
            TextBox txtPassword = AddText(layout, "Mật khẩu", "123456");
            TextBox txtName = AddText(layout, "Họ tên", "");
            TextBox txtEmail = AddText(layout, "Email", "");
            ComboBox cboRole = AddCombo(layout, "Vai trò", roles.Select((role, index) => new Option { Text = role, Value = index }).ToList());
            ComboBox cboDepartment = AddCombo(layout, "Khoa/Phòng", departments.Select(dept => new Option
            {
                Text = dept.DepartmentName,
                Value = dept.DepartmentID
            }).ToList());
            CheckBox chkActive = AddCheck(layout, "Trạng thái", "Đang hoạt động", true);

            if (ShowEditor(form) != DialogResult.OK)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text)
                || string.IsNullOrWhiteSpace(txtName.Text)
                || cboRole.SelectedItem == null
                || cboDepartment.SelectedItem == null)
            {
                MessageBox.Show("Username, mật khẩu, họ tên, vai trò và khoa/phòng không được để trống.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Option selectedDepartment = (Option)cboDepartment.SelectedItem;
            created = new UserDTO
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Name = txtName.Text.Trim(),
                Role = ((Option)cboRole.SelectedItem).Text,
                Email = txtEmail.Text.Trim(),
                IsActive = chkActive.Checked,
                DepartmentID = selectedDepartment.Value,
                DepartmentName = selectedDepartment.Text
            };
            return true;
        }

        public static void ShowEmployee(EmployeeDTO employee)
        {
            ShowDetails("Chi tiết nhân viên", new Dictionary<string, string>
            {
                ["Mã nhân viên"] = employee.EmployeeCode,
                ["Họ tên"] = employee.FullName,
                ["Vai trò"] = employee.RoleName,
                ["Khoa/Phòng"] = employee.DepartmentName,
                ["Ngày sinh"] = employee.DateOfBirth?.ToString("dd/MM/yyyy") ?? "",
                ["Giới tính"] = employee.Gender,
                ["CCCD"] = employee.CitizenId,
                ["Điện thoại"] = employee.Phone,
                ["Email"] = employee.Email,
                ["Địa chỉ"] = employee.Address,
                ["Trạng thái"] = employee.Status
            });
        }

        public static bool CreateEmployee(IReadOnlyList<string> roles, IReadOnlyList<DepartmentDTO> departments, out EmployeeDTO created)
        {
            created = null;
            using Form form = CreateForm("Thêm nhân viên", 580, 560);
            TableLayoutPanel layout = CreateEditorLayout(form, 10);

            TextBox txtCode = AddText(layout, "Mã nhân viên", "");
            TextBox txtName = AddText(layout, "Họ tên", "");
            ComboBox cboRole = AddCombo(layout, "Vai trò", roles.Select((role, index) => new Option { Text = role, Value = index }).ToList());
            ComboBox cboDepartment = AddCombo(layout, "Khoa/Phòng", departments.Select(dept => new Option
            {
                Text = dept.DepartmentName,
                Value = dept.DepartmentID
            }).ToList());
            ComboBox cboGender = AddCombo(layout, "Giới tính", new List<Option>
            {
                new Option { Text = "Nam", Value = 1 },
                new Option { Text = "Nữ", Value = 2 },
                new Option { Text = "Khác", Value = 3 }
            });
            TextBox txtPhone = AddText(layout, "Điện thoại", "");
            TextBox txtEmail = AddText(layout, "Email", "");
            TextBox txtAddress = AddText(layout, "Địa chỉ", "", true);
            ComboBox cboStatus = AddCombo(layout, "Trạng thái", new List<Option>
            {
                new Option { Text = "Active", Value = 1 },
                new Option { Text = "Inactive", Value = 0 }
            });

            if (ShowEditor(form) != DialogResult.OK)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || cboRole.SelectedItem == null || cboDepartment.SelectedItem == null)
            {
                MessageBox.Show("Họ tên, vai trò và khoa/phòng không được để trống.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Option selectedDepartment = (Option)cboDepartment.SelectedItem;
            created = new EmployeeDTO
            {
                EmployeeCode = txtCode.Text.Trim(),
                FullName = txtName.Text.Trim(),
                RoleName = ((Option)cboRole.SelectedItem).Text,
                DepartmentID = selectedDepartment.Value,
                DepartmentName = selectedDepartment.Text,
                Gender = ((Option)cboGender.SelectedItem).Text,
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                HireDate = DateTime.Today,
                Status = ((Option)cboStatus.SelectedItem).Text
            };
            return true;
        }

        public static bool EditEmployee(EmployeeDTO source, IReadOnlyList<string> roles, IReadOnlyList<DepartmentDTO> departments, out EmployeeDTO edited)
        {
            edited = null;
            using Form form = CreateForm("Sửa nhân viên", 580, 560);
            TableLayoutPanel layout = CreateEditorLayout(form, 9);

            TextBox txtName = AddText(layout, "Họ tên", source.FullName);
            ComboBox cboRole = AddCombo(layout, "Vai trò", roles.Select((role, index) => new Option { Text = role, Value = index }).ToList());
            SelectText(cboRole, source.RoleName);
            ComboBox cboDepartment = AddCombo(layout, "Khoa/Phòng", departments.Select(dept => new Option
            {
                Text = dept.DepartmentName,
                Value = dept.DepartmentID
            }).ToList());
            SelectValue(cboDepartment, source.DepartmentID);
            TextBox txtPhone = AddText(layout, "Điện thoại", source.Phone);
            TextBox txtEmail = AddText(layout, "Email", source.Email);
            TextBox txtAddress = AddText(layout, "Địa chỉ", source.Address, true);
            ComboBox cboStatus = AddCombo(layout, "Trạng thái", new List<Option>
            {
                new Option { Text = "Active", Value = 1 },
                new Option { Text = "Inactive", Value = 0 }
            });
            SelectText(
                cboStatus,
                string.Equals(source.Status, "Inactive", StringComparison.OrdinalIgnoreCase)
                    ? "Inactive"
                    : "Active");

            if (ShowEditor(form) != DialogResult.OK)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) || cboRole.SelectedItem == null || cboDepartment.SelectedItem == null)
            {
                MessageBox.Show("Họ tên, vai trò và khoa/phòng không được để trống.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Option selectedDepartment = (Option)cboDepartment.SelectedItem;
            edited = new EmployeeDTO
            {
                EmployeeID = source.EmployeeID,
                EmployeeUUID = source.EmployeeUUID,
                EmployeeCode = source.EmployeeCode,
                FullName = txtName.Text.Trim(),
                DateOfBirth = source.DateOfBirth,
                Gender = source.Gender,
                CitizenId = source.CitizenId,
                Address = txtAddress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HireDate = source.HireDate,
                Salary = source.Salary,
                RoleID = source.RoleID,
                RoleName = ((Option)cboRole.SelectedItem).Text,
                DepartmentID = selectedDepartment.Value,
                DepartmentName = selectedDepartment.Text,
                Status = ((Option)cboStatus.SelectedItem).Text,
                UserID = source.UserID
            };
            return true;
        }

        public static bool EditDepartment(DepartmentDTO source, bool isNew, out DepartmentDTO edited)
        {
            edited = null;
            using Form form = CreateForm(isNew ? "Thêm chuyên khoa" : "Sửa chuyên khoa", 500, 240);
            TableLayoutPanel layout = CreateEditorLayout(form, 2);
            TextBox txtName = AddText(layout, "Tên chuyên khoa", source?.DepartmentName);

            if (ShowEditor(form) != DialogResult.OK)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên chuyên khoa không được để trống.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            edited = new DepartmentDTO
            {
                DepartmentID = source?.DepartmentID ?? 0,
                DepartmentName = txtName.Text.Trim(),
                Description = source?.Description,
                IsActive = source?.IsActive ?? true
            };
            return true;
        }

        public static void ShowShift(EmployeeShiftDTO shift)
        {
            ShowDetails("Chi tiết ca trực", new Dictionary<string, string>
            {
                ["Nhân viên"] = shift.EmployeeName,
                ["Vai trò"] = shift.RoleName,
                ["Khoa/Phòng"] = shift.DepartmentName,
                ["Ngày làm"] = shift.WorkDate.ToString("dd/MM/yyyy"),
                ["Ca"] = shift.ShiftName,
                ["Giờ làm"] = $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}",
                ["Phòng"] = string.IsNullOrWhiteSpace(shift.RoomCode) ? "Chưa phân phòng" : shift.RoomCode,
                ["Trạng thái"] = shift.Status
            });
        }

        public static bool EditShift(
            EmployeeShiftDTO source,
            IReadOnlyList<EmployeeDTO> employees,
            IReadOnlyList<WorkShiftDTO> workShifts,
            IReadOnlyList<DepartmentDTO> departments,
            IReadOnlyList<RoomDTO> rooms,
            bool isNew,
            out EmployeeShiftDTO edited)
        {
            edited = null;
            using Form form = CreateForm(isNew ? "Thêm ca trực" : "Sửa ca trực", 560, 470);
            TableLayoutPanel layout = CreateEditorLayout(form, 7);

            ComboBox cboEmployee = AddCombo(layout, "Nhân viên", employees.Select(emp => new Option
            {
                Text = $"{emp.FullName} ({emp.RoleName})",
                Value = emp.EmployeeID
            }).ToList());
            SelectValue(cboEmployee, source.EmployeeID);

            ComboBox cboShift = AddCombo(layout, "Ca trực", workShifts.Select(shift => new Option
            {
                Text = $"{shift.ShiftName} ({shift.StartTime:hh\\:mm}-{shift.EndTime:hh\\:mm})",
                Value = shift.ShiftID
            }).ToList());
            SelectValue(cboShift, source.ShiftID);

            DateTimePicker dtpDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = source.WorkDate == DateTime.MinValue ? DateTime.Today : source.WorkDate.Date,
                Dock = DockStyle.Fill
            };
            AddControl(layout, "Ngày làm", dtpDate);

            ComboBox cboDepartment = AddCombo(layout, "Khoa/Phòng", departments.Select(dept => new Option
            {
                Text = dept.DepartmentName,
                Value = dept.DepartmentID
            }).ToList());
            SelectValue(cboDepartment, source.DepartmentID ?? employees.FirstOrDefault(emp => emp.EmployeeID == source.EmployeeID)?.DepartmentID ?? 0);

            List<Option> roomOptions = new List<Option> { new Option { Text = "Chưa phân phòng", Value = 0 } };
            roomOptions.AddRange(rooms.Select(room => new Option { Text = room.RoomCode, Value = room.RoomID }));
            ComboBox cboRoom = AddCombo(layout, "Phòng", roomOptions);
            SelectValue(cboRoom, source.RoomID ?? 0);

            ComboBox cboStatus = AddCombo(layout, "Trạng thái", new List<Option>
            {
                new Option { Text = "Approved", Value = 1 },
                new Option { Text = "Scheduled", Value = 2 },
                new Option { Text = "Cancelled", Value = 0 }
            });
            SelectText(cboStatus, string.IsNullOrWhiteSpace(source.Status) ? "Approved" : source.Status);

            if (ShowEditor(form) != DialogResult.OK)
            {
                return false;
            }

            if (cboEmployee.SelectedItem == null || cboShift.SelectedItem == null || cboDepartment.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên, ca trực và khoa/phòng.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Option selectedEmployee = (Option)cboEmployee.SelectedItem;
            Option selectedShift = (Option)cboShift.SelectedItem;
            Option selectedDepartment = (Option)cboDepartment.SelectedItem;
            Option selectedRoom = (Option)cboRoom.SelectedItem;
            EmployeeDTO employee = employees.FirstOrDefault(emp => emp.EmployeeID == selectedEmployee.Value);
            WorkShiftDTO workShift = workShifts.FirstOrDefault(shift => shift.ShiftID == selectedShift.Value);
            RoomDTO room = rooms.FirstOrDefault(item => item.RoomID == selectedRoom.Value);

            edited = new EmployeeShiftDTO
            {
                EmployeeShiftID = source.EmployeeShiftID,
                EmployeeID = selectedEmployee.Value,
                EmployeeName = employee?.FullName ?? "",
                RoleName = employee?.RoleName ?? "",
                ShiftID = selectedShift.Value,
                ShiftName = workShift?.ShiftName ?? "",
                WorkDate = dtpDate.Value.Date,
                StartTime = workShift?.StartTime ?? TimeSpan.Zero,
                EndTime = workShift?.EndTime ?? TimeSpan.Zero,
                DepartmentID = selectedDepartment.Value,
                DepartmentName = selectedDepartment.Text,
                RoomID = selectedRoom.Value == 0 ? null : selectedRoom.Value,
                RoomCode = room?.RoomCode ?? "",
                Status = ((Option)cboStatus.SelectedItem).Text
            };
            return true;
        }

        private static void ShowDetails(string title, IReadOnlyDictionary<string, string> rows)
        {
            using Form form = CreateForm(title, 560, Math.Min(620, 150 + rows.Count * 42));
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(18),
                ColumnCount = 2,
                RowCount = rows.Count + 1,
                AutoSize = true
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            foreach (KeyValuePair<string, string> row in rows)
            {
                Label key = new Label { Text = row.Key, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                Label value = new Label { Text = string.IsNullOrWhiteSpace(row.Value) ? "-" : row.Value, Dock = DockStyle.Fill, AutoSize = true };
                layout.Controls.Add(key);
                layout.Controls.Add(value);
            }

            Button btnClose = new Button { Text = "Đóng", DialogResult = DialogResult.OK, Width = 110, Height = 36 };
            FlowLayoutPanel footer = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            footer.Controls.Add(btnClose);
            layout.Controls.Add(new Label());
            layout.Controls.Add(footer);
            form.Controls.Add(layout);
            form.AcceptButton = btnClose;
            form.ShowDialog();
        }

        private static Form CreateForm(string title, int width, int height)
        {
            return new Form
            {
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                Font = new Font("Segoe UI", 10F),
                Width = width,
                Height = height,
                MinimizeBox = false,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };
        }

        private static TableLayoutPanel CreateEditorLayout(Form form, int rows)
        {
            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(18),
                ColumnCount = 2,
                RowCount = rows + 1
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            form.Controls.Add(layout);
            return layout;
        }

        private static TextBox AddText(TableLayoutPanel layout, string label, string value, bool multiline = false)
        {
            TextBox textBox = new TextBox
            {
                Text = value ?? "",
                Dock = DockStyle.Fill,
                Multiline = multiline,
                Height = multiline ? 70 : 32
            };
            AddControl(layout, label, textBox);
            return textBox;
        }

        private static ComboBox AddCombo(TableLayoutPanel layout, string label, List<Option> options)
        {
            ComboBox combo = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill,
                DataSource = options
            };
            AddControl(layout, label, combo);
            if (combo.Items.Count > 0 && combo.SelectedIndex < 0)
            {
                combo.SelectedIndex = 0;
            }
            return combo;
        }

        private static CheckBox AddCheck(TableLayoutPanel layout, string label, string text, bool isChecked)
        {
            CheckBox checkBox = new CheckBox { Text = text, Checked = isChecked, Dock = DockStyle.Fill };
            AddControl(layout, label, checkBox);
            return checkBox;
        }

        private static void AddControl(TableLayoutPanel layout, string label, Control control)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(new Label
            {
                Text = label,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            });
            layout.Controls.Add(control);
        }

        private static DialogResult ShowEditor(Form form)
        {
            FlowLayoutPanel footer = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 12, 0, 0)
            };
            Button btnSave = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Width = 110, Height = 36 };
            Button btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Width = 110, Height = 36 };
            footer.Controls.Add(btnSave);
            footer.Controls.Add(btnCancel);

            if (form.Controls[0] is TableLayoutPanel layout)
            {
                layout.Controls.Add(new Label());
                layout.Controls.Add(footer);
            }

            form.AcceptButton = btnSave;
            form.CancelButton = btnCancel;
            return form.ShowDialog();
        }

        private static void SelectValue(ComboBox combo, int value)
        {
            List<Option> options = combo.Items.Cast<Option>().ToList();
            int index = options.FindIndex(option => option.Value == value);
            SelectIndex(combo, index);
        }

        private static void SelectText(ComboBox combo, string text)
        {
            List<Option> options = combo.Items.Cast<Option>().ToList();
            int index = options.FindIndex(option =>
                string.Equals(option.Text, text, StringComparison.OrdinalIgnoreCase));
            SelectIndex(combo, index);
        }

        private static void SelectIndex(ComboBox combo, int requestedIndex)
        {
            if (combo.Items.Count == 0)
            {
                combo.SelectedIndex = -1;
                return;
            }

            combo.SelectedIndex = requestedIndex >= 0 && requestedIndex < combo.Items.Count
                ? requestedIndex
                : 0;
        }
    }
}
