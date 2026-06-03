using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DAL.DataContext;
using DTO;
using Newtonsoft.Json.Linq;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianShifts : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianShifts()
        {
            InitializeComponent();
        }

        private void ucTechnicianShifts_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucTechnicianShifts_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderShifts();
        }

        // 7. SHIFTS VIEW (TechnicianShiftForm)
        // ==========================================
        private void RenderShifts()
        {
            var page = BeginPage("Lịch Làm Việc", "Xem ca trực và phòng khám được phân công của Kỹ thuật viên");

            var btnReg = CreateFlatButton("Đăng ký ca mới", Color.White, primary, PageWidth() - 190, 0, 180, 42);
            btnReg.Margin = new Padding(0, -70, 0, 20);
            btnReg.Click += (s, ev) =>
            {
                RegisterShiftForm register = new RegisterShiftForm(currentUser != null ? currentUser.Name : "Lữ Võ Hoàng Phúc");
                if (register.ShowDialog() == DialogResult.OK) NavigateTo(TechnicianViewTarget.Shifts);
            };
            page.Controls.Add(btnReg);

            // Shift statistics
            int countShifts = 0;
            try
            {
                countShifts = shiftBUS.GetShiftCount();
            }
            catch { }

            var stats = CreateGrid(3, 110);
            stats.Controls.Add(CreateStatRowCard("Tổng ca đăng ký", countShifts.ToString(), "CAL", Color.FromArgb(219, 234, 254), primary), 0, 0);
            stats.Controls.Add(CreateStatRowCard("Ca đang trực", "1", "TIME", Color.FromArgb(254, 249, 195), Color.FromArgb(180, 83, 9)), 1, 0);
            stats.Controls.Add(CreateStatRowCard("Giờ hoàn thành", (countShifts * 5) + "h", "CLK", Color.FromArgb(220, 252, 231), Color.FromArgb(34, 139, 74)), 2, 0);
            page.Controls.Add(stats);

            // Calendar Section (Hardcoded layout displaying dynamic shifts)
            var calendar = CreateSection("Lịch làm việc tuần này", 290);
            string[] days = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };
            int cellW = (calendar.Width - 62) / 7;

            // Get shifts for the week
            List<ShiftDTO> weekShifts = new List<ShiftDTO>();
            try
            {
                weekShifts = shiftBUS.GetList();
            }
            catch { }

            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            for (int i = 0; i < 7; i++)
            {
                DateTime dayDate = startOfWeek.AddDays(i);
                calendar.Controls.Add(CreateLabel(days[i], 9.5F, FontStyle.Bold, textMain, 22 + i * cellW, 82, cellW, 24, ContentAlignment.MiddleCenter));

                var dayBox = new RoundedPanel
                {
                    BorderColor = dayDate.Date == DateTime.Today ? primary : Color.FromArgb(229, 231, 235),
                    CornerRadius = 8,
                    FillColor = dayDate.Date == DateTime.Today ? Color.FromArgb(239, 246, 255) : Color.White,
                    Location = new Point(22 + i * cellW, 112),
                    Size = new Size(cellW - 14, 130)
                };

                dayBox.Controls.Add(CreateLabel(dayDate.ToString("dd/MM"), 9.5F, FontStyle.Bold, textMain, 10, 10, 60, 22));

                // Find shift for this day
                var shift = weekShifts.FirstOrDefault(s => s.ShiftDate.Date == dayDate.Date);
                if (shift != null)
                {
                    var btnShiftText = CreateFlatButton(shift.ShiftName, Color.FromArgb(180, 83, 9), Color.FromArgb(254, 249, 195), 10, 36, dayBox.Width - 20, 28);
                    dayBox.Controls.Add(btnShiftText);
                    
                    var lblRoom = CreateLabel(shift.Room, 8F, FontStyle.Bold, primary, 10, 68, dayBox.Width - 20, 18);
                    dayBox.Controls.Add(lblRoom);
                    
                    var lblDept = CreateLabel(shift.Department, 7.5F, FontStyle.Regular, textMuted, 10, 88, dayBox.Width - 20, 36);
                    dayBox.Controls.Add(lblDept);
                }
                else
                {
                    dayBox.Controls.Add(CreateLabel("Trống ca", 8F, FontStyle.Italic, textMuted, 10, 50, dayBox.Width - 20, 22, ContentAlignment.MiddleCenter));
                }

                calendar.Controls.Add(dayBox);
            }
            page.Controls.Add(calendar);

            // Shift Table List
            var listPanel = CreateSection("Danh sách ca trực chi tiết", 310);
            AddShiftRow(listPanel, "NGÀY", "CA", "CHUYÊN KHOA", "PHÒNG KHÁM", "TRẠNG THÁI", 60, true);

            int yShift = 100;
            foreach (var s in weekShifts)
            {
                AddShiftRow(listPanel, s.ShiftDate.ToString("dd/MM/yyyy"), s.ShiftName, s.Department, s.Room, s.Status, yShift, false);
                yShift += 46;
            }
            page.Controls.Add(listPanel);
        }

        // ==========================================

    }
}


