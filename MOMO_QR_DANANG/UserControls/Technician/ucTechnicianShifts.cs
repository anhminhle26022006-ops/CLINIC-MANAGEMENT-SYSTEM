using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MOMO_QR_DANANG.DataAccess;
using MOMO_QR_DANANG.Models;
using Newtonsoft.Json.Linq;

namespace MOMO_QR_DANANG.UserControls.Technician
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
            var page = BeginPage("Lá»‹ch LÃ m Viá»‡c", "Xem ca trá»±c vÃ  phÃ²ng khÃ¡m Ä‘Æ°á»£c phÃ¢n cÃ´ng cá»§a Ká»¹ thuáº­t viÃªn");

            var btnReg = CreateFlatButton("ÄÄƒng kÃ½ ca má»›i", Color.White, primary, PageWidth() - 190, 0, 180, 42);
            btnReg.Margin = new Padding(0, -70, 0, 20);
            btnReg.Click += (s, ev) =>
            {
                RegisterShiftForm register = new RegisterShiftForm(currentUser != null ? currentUser.Name : "Lá»¯ VÃµ HoÃ ng PhÃºc");
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
            stats.Controls.Add(CreateStatRowCard("Tá»•ng ca Ä‘Äƒng kÃ½", countShifts.ToString(), "CAL", Color.FromArgb(219, 234, 254), primary), 0, 0);
            stats.Controls.Add(CreateStatRowCard("Ca Ä‘ang trá»±c", "1", "TIME", Color.FromArgb(254, 249, 195), Color.FromArgb(180, 83, 9)), 1, 0);
            stats.Controls.Add(CreateStatRowCard("Giá» hoÃ n thÃ nh", (countShifts * 5) + "h", "CLK", Color.FromArgb(220, 252, 231), Color.FromArgb(34, 139, 74)), 2, 0);
            page.Controls.Add(stats);

            // Calendar Section (Hardcoded layout displaying dynamic shifts)
            var calendar = CreateSection("Lá»‹ch lÃ m viá»‡c tuáº§n nÃ y", 290);
            string[] days = { "Thá»© 2", "Thá»© 3", "Thá»© 4", "Thá»© 5", "Thá»© 6", "Thá»© 7", "Chá»§ Nháº­t" };
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
                    dayBox.Controls.Add(CreateLabel("Trá»‘ng ca", 8F, FontStyle.Italic, textMuted, 10, 50, dayBox.Width - 20, 22, ContentAlignment.MiddleCenter));
                }

                calendar.Controls.Add(dayBox);
            }
            page.Controls.Add(calendar);

            // Shift Table List
            var listPanel = CreateSection("Danh sÃ¡ch ca trá»±c chi tiáº¿t", 310);
            AddShiftRow(listPanel, "NGÃ€Y", "CA", "CHUYÃŠN KHOA", "PHÃ’NG KHÃM", "TRáº NG THÃI", 60, true);

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

