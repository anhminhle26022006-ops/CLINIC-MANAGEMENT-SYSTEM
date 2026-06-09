using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftRequestManagement : UserControl
    {
        private readonly EmployeeBUS employeeBUS = new EmployeeBUS(new DAL.Repositories.EmployeeDAL());
        private readonly EmployeeShiftBUS employeeShiftBUS = new EmployeeShiftBUS();
        private readonly WorkShiftBUS workShiftBUS = new WorkShiftBUS();
        private readonly DepartmentBUS departmentBUS = new DepartmentBUS();
        private readonly RoomBUS roomBUS = new RoomBUS();

        private List<EmployeeDTO> employees = new List<EmployeeDTO>();
        private List<EmployeeShiftDTO> shifts = new List<EmployeeShiftDTO>();
        private List<WorkShiftDTO> workShifts = new List<WorkShiftDTO>();
        private List<DepartmentDTO> departments = new List<DepartmentDTO>();
        private List<RoomDTO> rooms = new List<RoomDTO>();
        private List<ShiftRequestRow> requests = new List<ShiftRequestRow>();

        public ucShiftRequestManagement()
        {
            InitializeComponent();
            btnCreate.Click += btnCreate_Click;
            LoadData();
        }

        public void LoadData()
        {
            employees = employeeBUS.GetAll();
            shifts = employeeShiftBUS.GetAll();
            workShifts = workShiftBUS.GetAll();
            departments = departmentBUS.GetAll();
            rooms = roomBUS.GetAll();
            requests = LoadShiftRequests();
            UpdateKpis();
            ShowTabOverview();
        }

        private void btnTabOverview_Click(object sender, EventArgs e) => ShowTabOverview();

        private void btnTabApproval_Click(object sender, EventArgs e) => ShowTabApproval();

        private void btnTabSchedule_Click(object sender, EventArgs e) => ShowTabSchedule();

        private void btnWarningAction_Click(object sender, EventArgs e) => ShowTabApproval();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EmployeeDTO employee = employees.FirstOrDefault();
            WorkShiftDTO workShift = workShifts.FirstOrDefault();
            DepartmentDTO department = employee != null
                ? departments.FirstOrDefault(item => item.DepartmentID == employee.DepartmentID)
                : departments.FirstOrDefault();

            EmployeeShiftDTO draft = new EmployeeShiftDTO
            {
                EmployeeID = employee?.EmployeeID ?? 0,
                ShiftID = workShift?.ShiftID ?? 0,
                WorkDate = DateTime.Today,
                DepartmentID = department?.DepartmentID,
                Status = "Approved"
            };

            if (AdminRecordDialogs.EditShift(draft, employees, workShifts, departments, rooms, true, out EmployeeShiftDTO created))
            {
                try
                {
                    if (employeeShiftBUS.RegisterShift(created))
                    {
                        LoadData();
                        ShowTabSchedule();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Không thể tạo ca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void panelHeader_Resize(object sender, EventArgs e)
        {
            if (btnCreate != null)
            {
                btnCreate.Location = new Point(panelHeader.Width - btnCreate.Width, 18);
            }
        }

        private void kpiFlow_Resize(object sender, EventArgs e) { }

        private void panelWarning_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(234, 179, 8), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, panelWarning.Width - 1, panelWarning.Height - 1);
        }

        private void panelWarning_Resize(object sender, EventArgs e)
        {
            if (btnWarningAction != null)
            {
                btnWarningAction.Location = new Point(panelWarning.Width - btnWarningAction.Width - 16, 10);
            }
        }

        private void panelTabs_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawLine(pen, 0, panelTabs.Height - 1, panelTabs.Width, panelTabs.Height - 1);

            foreach (Control control in panelTabs.Controls)
            {
                if (control is Button button && button.Tag?.ToString() == "active")
                {
                    using var blue = new Pen(Color.FromArgb(37, 99, 235), 2);
                    e.Graphics.DrawLine(blue, button.Left, panelTabs.Height - 2, button.Right, panelTabs.Height - 2);
                }
            }
        }

        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel card) return;

            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        }

        private void SetActiveTab(Button active)
        {
            foreach (Control child in panelTabs.Controls)
            {
                if (child is Button button)
                {
                    button.BackColor = button == active ? Color.FromArgb(239, 246, 255) : Color.White;
                    button.ForeColor = button == active ? Color.FromArgb(37, 99, 235) : Color.FromArgb(71, 85, 105);
                }
            }
        }

        private void ShowTabOverview()
        {
            SetActiveTab(btnTabOverview);
            panelTabContent.Controls.Clear();
            Panel card = BuildRequestSection(
                "Tổng quan yêu cầu ca trực",
                "Theo dõi yêu cầu đổi ca, ca đã duyệt và lịch làm việc cần kiểm tra.",
                new[]
                {
                    ("Chờ duyệt", $"{CountStatus("Pending")} yêu cầu", Color.FromArgb(161, 98, 7), Color.FromArgb(254, 249, 195)),
                    ("Đã duyệt", $"{CountStatus("Approved")} yêu cầu", Color.FromArgb(22, 163, 74), Color.FromArgb(220, 252, 231)),
                    ("Từ chối", $"{CountStatus("Rejected")} yêu cầu", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 226, 226))
                });
            AddLatestRequests(card);
            panelTabContent.Controls.Add(card);
        }

        private void ShowTabApproval()
        {
            SetActiveTab(btnTabApproval);
            panelTabContent.Controls.Clear();
            panelTabContent.Controls.Add(BuildRequestGrid(requests
                .Where(request => string.Equals(request.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                .ToList(), true));
        }

        private void ShowTabSchedule()
        {
            SetActiveTab(btnTabSchedule);
            panelTabContent.Controls.Clear();
            panelTabContent.Controls.Add(BuildScheduleGrid());
        }

        private Panel BuildRequestSection(
            string title,
            string description,
            (string Title, string Value, Color Accent, Color Back)[] blocks)
        {
            Panel card = BuildWhiteCard(title, 300);
            card.Width = Math.Max(760, panelTabContent.ClientSize.Width);
            int contentWidth = Math.Max(300, card.Width - 48);

            var descriptionLabel = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(24, 58),
                Size = new Size(contentWidth, 28),
                Text = description,
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(descriptionLabel);

            int left = 24;
            foreach (var block in blocks)
            {
                Panel infoBlock = BuildInfoBlock(block.Title, block.Value, block.Accent, block.Back);
                infoBlock.Location = new Point(left, 108);
                card.Controls.Add(infoBlock);
                left += infoBlock.Width + 16;
            }

            var emptyLabel = new Label
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(24, 230),
                Size = new Size(contentWidth, 28),
                Text = "Dữ liệu sẽ được cập nhật khi có yêu cầu đổi ca phát sinh.",
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(emptyLabel);

            return card;
        }

        private void AddLatestRequests(Panel card)
        {
            List<ShiftRequestRow> latest = requests
                .OrderByDescending(request => request.CreatedAt)
                .Take(5)
                .ToList();

            if (latest.Count == 0)
            {
                return;
            }

            Label title = new Label
            {
                Text = "Yêu cầu mới nhất",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(24, 218),
                Size = new Size(220, 24)
            };
            card.Controls.Add(title);

            DataGridView grid = CreateGrid();
            grid.Location = new Point(24, 248);
            grid.Size = new Size(Math.Max(700, card.Width - 48), 170);
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grid.Columns.Add("Requester", "NHÂN VIÊN");
            grid.Columns.Add("Target", "CA ĐỀ XUẤT");
            grid.Columns.Add("Reason", "LÝ DO");
            grid.Columns.Add("Status", "TRẠNG THÁI");

            foreach (ShiftRequestRow request in latest)
            {
                grid.Rows.Add(
                    request.RequesterName,
                    $"{request.TargetEmployeeName} - {request.TargetWorkDate:dd/MM/yyyy}",
                    request.Reason,
                    TranslateRequestStatus(request.Status));
            }

            card.Height = 450;
            card.Controls.Add(grid);
        }

        private Control BuildRequestGrid(List<ShiftRequestRow> data, bool allowActions)
        {
            Panel card = BuildWhiteCard("Danh sách yêu cầu đổi ca", 420);
            DataGridView grid = CreateGrid();
            grid.Dock = DockStyle.Fill;
            grid.Tag = allowActions ? "approval" : null;
            grid.CellClick += RequestGrid_CellClick;
            grid.Columns.Add("RequestID", "ID");
            grid.Columns["RequestID"].Visible = false;
            grid.Columns.Add("Requester", "NGƯỜI GỬI");
            grid.Columns.Add("CurrentShift", "CA HIỆN TẠI");
            grid.Columns.Add("Target", "CA ĐỀ XUẤT");
            grid.Columns.Add("Reason", "LÝ DO");
            grid.Columns.Add("Status", "TRẠNG THÁI");

            if (allowActions)
            {
                grid.Columns.Add("Approve", "");
                grid.Columns.Add("Reject", "");
            }

            foreach (ShiftRequestRow request in data)
            {
                int rowIndex = allowActions
                    ? grid.Rows.Add(
                        request.RequestID,
                        request.RequesterName,
                        request.CurrentShiftText,
                        $"{request.TargetEmployeeName} - {request.TargetShiftName} {request.TargetWorkDate:dd/MM/yyyy}",
                        request.Reason,
                        TranslateRequestStatus(request.Status),
                        "Duyệt",
                        "Từ chối")
                    : grid.Rows.Add(
                        request.RequestID,
                        request.RequesterName,
                        request.CurrentShiftText,
                        $"{request.TargetEmployeeName} - {request.TargetShiftName} {request.TargetWorkDate:dd/MM/yyyy}",
                        request.Reason,
                        TranslateRequestStatus(request.Status));
                grid.Rows[rowIndex].Tag = request;
            }

            if (data.Count == 0)
            {
                grid.Rows.Add(0, "Chưa có yêu cầu chờ duyệt", "", "", "", "");
            }

            card.Controls.Add(grid);
            grid.BringToFront();
            return card;
        }

        private Control BuildScheduleGrid()
        {
            Panel card = BuildWhiteCard("Lịch làm việc", 420);
            DataGridView grid = CreateGrid();
            grid.Dock = DockStyle.Fill;
            grid.Columns.Add("Employee", "NHÂN VIÊN");
            grid.Columns.Add("Role", "VAI TRÒ");
            grid.Columns.Add("Date", "NGÀY");
            grid.Columns.Add("Shift", "CA");
            grid.Columns.Add("Time", "THỜI GIAN");
            grid.Columns.Add("Room", "PHÒNG");
            grid.Columns.Add("Status", "TRẠNG THÁI");

            foreach (EmployeeShiftDTO shift in shifts
                .Where(item => item.WorkDate.Date >= DateTime.Today)
                .OrderBy(item => item.WorkDate)
                .ThenBy(item => item.StartTime)
                .Take(80))
            {
                grid.Rows.Add(
                    shift.EmployeeName,
                    shift.RoleName,
                    shift.WorkDate.ToString("dd/MM/yyyy"),
                    shift.ShiftName,
                    $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}",
                    string.IsNullOrWhiteSpace(shift.RoomCode) ? "Chưa phân phòng" : shift.RoomCode,
                    shift.Status);
            }

            card.Controls.Add(grid);
            grid.BringToFront();
            return card;
        }

        private DataGridView CreateGrid()
        {
            DataGridView grid = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersHeight = 42,
                Dock = DockStyle.None,
                ReadOnly = true,
                RowHeadersVisible = false,
                RowTemplate = { Height = 42 },
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            AdminUiStyle.ApplyGrid(grid);
            return grid;
        }

        private void RequestGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is not DataGridView grid
                || e.RowIndex < 0
                || e.ColumnIndex < 0
                || grid.Rows[e.RowIndex].Tag is not ShiftRequestRow request)
            {
                return;
            }

            string columnName = grid.Columns[e.ColumnIndex].Name;
            if (columnName == "Approve")
            {
                UpdateRequestStatus(request.RequestID, "Approved");
                LoadData();
                ShowTabApproval();
            }
            else if (columnName == "Reject")
            {
                UpdateRequestStatus(request.RequestID, "Rejected");
                LoadData();
                ShowTabApproval();
            }
        }

        private void UpdateKpis()
        {
            lblShiftTotalValue.Text = requests.Count.ToString("N0");
            lblShiftPendingValue.Text = CountStatus("Pending").ToString("N0");
            lblShiftApprovedValue.Text = CountStatus("Approved").ToString("N0");
            lblShiftRejectedValue.Text = CountStatus("Rejected").ToString("N0");
        }

        private int CountStatus(string status)
        {
            return requests.Count(request => string.Equals(request.Status, status, StringComparison.OrdinalIgnoreCase));
        }

        private List<ShiftRequestRow> LoadShiftRequests()
        {
            List<ShiftRequestRow> result = new List<ShiftRequestRow>();
            if (!SchemaHelper.TableExists("ShiftChangeRequests"))
            {
                return result;
            }

            EnsureShiftRequestDemoData();

            string query = @"
                SELECT scr.RequestID,
                       ISNULL(req.FullName, '') AS RequesterName,
                       ISNULL(curShift.Name, '') AS CurrentShiftName,
                       curEs.WorkDate AS CurrentWorkDate,
                       ISNULL(target.FullName, '') AS TargetEmployeeName,
                       ISNULL(targetShift.Name, '') AS TargetShiftName,
                       scr.TargetWorkDate,
                       ISNULL(scr.Reason, '') AS Reason,
                       ISNULL(scr.Status, 'Pending') AS Status,
                       ISNULL(scr.CreatedAt, GETDATE()) AS CreatedAt
                FROM ShiftChangeRequests scr
                LEFT JOIN Employees req ON scr.RequesterEmployeeID = req.EmployeeID
                LEFT JOIN EmployeeShifts curEs ON scr.CurrentEmployeeShiftID = curEs.ID
                LEFT JOIN Shifts curShift ON curEs.ShiftID = curShift.ShiftID
                LEFT JOIN Employees target ON scr.TargetEmployeeID = target.EmployeeID
                LEFT JOIN Shifts targetShift ON scr.TargetShiftID = targetShift.ShiftID
                ORDER BY scr.CreatedAt DESC, scr.RequestID DESC";

            DataTable table = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                DateTime currentDate = ReadDate(row, "CurrentWorkDate");
                result.Add(new ShiftRequestRow
                {
                    RequestID = ReadInt(row, "RequestID"),
                    RequesterName = ReadString(row, "RequesterName"),
                    CurrentShiftText = $"{ReadString(row, "CurrentShiftName")} {FormatDate(currentDate)}".Trim(),
                    TargetEmployeeName = ReadString(row, "TargetEmployeeName"),
                    TargetShiftName = ReadString(row, "TargetShiftName"),
                    TargetWorkDate = ReadDate(row, "TargetWorkDate"),
                    Reason = ReadString(row, "Reason"),
                    Status = ReadString(row, "Status"),
                    CreatedAt = ReadDate(row, "CreatedAt")
                });
            }

            return result;
        }

        private static void EnsureShiftRequestDemoData()
        {
            try
            {
                DatabaseHelper.ExecuteNonQuery(@"
IF NOT EXISTS (SELECT 1 FROM ShiftChangeRequests)
BEGIN
    ;WITH SourceShifts AS
    (
        SELECT TOP 6
               es.ID,
               es.EmployeeID,
               ROW_NUMBER() OVER (ORDER BY es.WorkDate, es.ID) AS rn
        FROM EmployeeShifts es
        WHERE es.WorkDate >= CAST(GETDATE() AS date)
        ORDER BY es.WorkDate, es.ID
    ),
    TargetEmployees AS
    (
        SELECT EmployeeID,
               ROW_NUMBER() OVER (ORDER BY EmployeeID DESC) AS rn
        FROM Employees
        WHERE ISNULL(Status, 'Active') <> 'Inactive'
    )
    INSERT INTO ShiftChangeRequests(RequesterEmployeeID, CurrentEmployeeShiftID, TargetEmployeeID, TargetShiftID, TargetWorkDate, Reason, Status)
    SELECT ss.EmployeeID,
           ss.ID,
           ISNULL(te.EmployeeID, ss.EmployeeID),
           (SELECT TOP 1 ShiftID FROM Shifts ORDER BY StartTime DESC),
           DATEADD(DAY, ss.rn, CAST(GETDATE() AS date)),
           CASE ss.rn
                WHEN 1 THEN N'Đổi ca để xử lý việc cá nhân'
                WHEN 2 THEN N'Xin đổi sang ca chiều'
                WHEN 3 THEN N'Nhờ đồng nghiệp hỗ trợ ca trực'
                WHEN 4 THEN N'Đã trao đổi nội bộ, cần admin duyệt'
                ELSE N'Yêu cầu đổi ca demo'
           END,
           CASE WHEN ss.rn <= 3 THEN 'Pending'
                WHEN ss.rn = 4 THEN 'Approved'
                ELSE 'Rejected'
           END
    FROM SourceShifts ss
    OUTER APPLY
    (
        SELECT TOP 1 EmployeeID
        FROM TargetEmployees te
        WHERE te.rn = ss.rn
          AND te.EmployeeID <> ss.EmployeeID
    ) te;
END");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Admin shift request demo seed failed: " + ex);
            }
        }

        private void UpdateRequestStatus(int requestId, string status)
        {
            DatabaseHelper.ExecuteNonQuery(
                @"UPDATE ShiftChangeRequests
                  SET Status = @Status, ReviewedAt = GETDATE()
                  WHERE RequestID = @RequestID",
                new[]
                {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@RequestID", requestId)
                });
        }

        private static int ReadInt(DataRow row, string column)
        {
            return row[column] == DBNull.Value ? 0 : Convert.ToInt32(row[column]);
        }

        private static string ReadString(DataRow row, string column)
        {
            return row[column] == DBNull.Value ? "" : row[column].ToString();
        }

        private static DateTime ReadDate(DataRow row, string column)
        {
            return row[column] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row[column]);
        }

        private static string FormatDate(DateTime date)
        {
            return date == DateTime.MinValue ? "" : date.ToString("dd/MM/yyyy");
        }

        private static string TranslateRequestStatus(string status)
        {
            return status switch
            {
                "Pending" => "Chờ duyệt",
                "Approved" => "Đã duyệt",
                "Rejected" => "Từ chối",
                _ => status
            };
        }

        private Panel BuildInfoBlock(string title, string value, Color accent, Color backColor)
        {
            var block = new Panel
            {
                BackColor = backColor,
                Size = new Size(240, 92)
            };

            block.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(16, 14),
                Size = new Size(208, 24),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            });

            block.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(16, 42),
                Size = new Size(208, 38),
                Text = value,
                TextAlign = ContentAlignment.MiddleLeft
            });

            return block;
        }

        private sealed class ShiftRequestRow
        {
            public int RequestID { get; set; }
            public string RequesterName { get; set; }
            public string CurrentShiftText { get; set; }
            public string TargetEmployeeName { get; set; }
            public string TargetShiftName { get; set; }
            public DateTime TargetWorkDate { get; set; }
            public string Reason { get; set; }
            public string Status { get; set; }
            public DateTime CreatedAt { get; set; }
        }

    }
}
