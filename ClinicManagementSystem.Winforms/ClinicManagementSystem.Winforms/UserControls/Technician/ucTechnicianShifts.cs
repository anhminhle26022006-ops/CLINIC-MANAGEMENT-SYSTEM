using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;
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
            btnReg.Click += BtnReg_Click;
            LoadShifts();
        }

        private void ucTechnicianShifts_Resize(object sender, EventArgs e)
        {
            AdjustCalendarLayout();
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            RegisterShiftForm register = new RegisterShiftForm(currentUser != null ? currentUser.Name : "Lữ Võ Hoàng Phúc");
            if (register.ShowDialog() == DialogResult.OK)
            {
                LoadShifts();
            }
        }

        private void LoadShifts()
        {
            int countShifts = 0;
            try
            {
                countShifts = shiftBUS.GetShiftCount();
            }
            catch { }

            lblStatTotalNum.Text = countShifts.ToString();
            lblStatHoursNum.Text = (countShifts * 5) + "h";

            List<ShiftDTO> weekShifts = new List<ShiftDTO>();
            try
            {
                weekShifts = shiftBUS.GetList();
            }
            catch { }

            // Populate Calendar
            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            RoundedPanel[] dayPanels = { pnlDay1, pnlDay2, pnlDay3, pnlDay4, pnlDay5, pnlDay6, pnlDay7 };
            Label[] dateLabels = { lblDayDate1, lblDayDate2, lblDayDate3, lblDayDate4, lblDayDate5, lblDayDate6, lblDayDate7 };
            Button[] shiftButtons = { btnShift1, btnShift2, btnShift3, btnShift4, btnShift5, btnShift6, btnShift7 };
            Label[] roomLabels = { lblRoom1, lblRoom2, lblRoom3, lblRoom4, lblRoom5, lblRoom6, lblRoom7 };
            Label[] deptLabels = { lblDept1, lblDept2, lblDept3, lblDept4, lblDept5, lblDept6, lblDept7 };

            for (int i = 0; i < 7; i++)
            {
                DateTime dayDate = startOfWeek.AddDays(i);
                dateLabels[i].Text = dayDate.ToString("dd/MM");

                // Highlight today
                if (dayDate.Date == DateTime.Today.Date)
                {
                    dayPanels[i].BorderColor = primary;
                    dayPanels[i].FillColor = Color.FromArgb(239, 246, 255);
                }
                else
                {
                    dayPanels[i].BorderColor = Color.FromArgb(229, 231, 235);
                    dayPanels[i].FillColor = Color.White;
                }

                var shift = weekShifts.FirstOrDefault(s => s.ShiftDate.Date == dayDate.Date);
                if (shift != null)
                {
                    shiftButtons[i].Text = shift.ShiftName;
                    shiftButtons[i].BackColor = Color.FromArgb(254, 249, 195);
                    shiftButtons[i].ForeColor = Color.FromArgb(180, 83, 9);
                    shiftButtons[i].Visible = true;

                    roomLabels[i].Text = shift.Room;
                    roomLabels[i].ForeColor = primary;

                    deptLabels[i].Text = shift.Department;
                    deptLabels[i].ForeColor = textMuted;
                }
                else
                {
                    shiftButtons[i].Text = "Trống";
                    shiftButtons[i].BackColor = Color.FromArgb(243, 244, 246);
                    shiftButtons[i].ForeColor = textMuted;

                    roomLabels[i].Text = "-";
                    roomLabels[i].ForeColor = textMuted;

                    deptLabels[i].Text = "-";
                    deptLabels[i].ForeColor = textMuted;
                }
            }

            // Populate Shifts Table (remove dynamic rows first, keep header and title)
            for (int idx = pnlListPanel.Controls.Count - 1; idx >= 0; idx--)
            {
                if (pnlListPanel.Controls[idx] != lblListTitle && pnlListPanel.Controls[idx] != flpShiftsTable)
                {
                    pnlListPanel.Controls.RemoveAt(idx);
                }
            }

            AddShiftRow(pnlListPanel, "NGÀY", "CA", "CHUYÊN KHOA", "PHÒNG KHÁM", "TRẠNG THÁI", 60, true);

            int yShift = 100;
            foreach (var s in weekShifts)
            {
                AddShiftRow(pnlListPanel, s.ShiftDate.ToString("dd/MM/yyyy"), s.ShiftName, s.Department, s.Room, s.Status, yShift, false);
                yShift += 46;
            }

            AdjustCalendarLayout();
        }

        private void AdjustCalendarLayout()
        {
            if (pnlDaysContainer.Width < 100) return;
            int cellW = pnlDaysContainer.Width / 7;
            RoundedPanel[] dayPanels = { pnlDay1, pnlDay2, pnlDay3, pnlDay4, pnlDay5, pnlDay6, pnlDay7 };

            for (int i = 0; i < 7; i++)
            {
                dayPanels[i].Width = cellW - 10;
                dayPanels[i].Left = i * cellW;
            }
        }
    }
}
