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
            ConfigureShiftListLayout();
        }

        private void ucTechnicianShifts_Load(object sender, EventArgs e)
        {
            btnReg.Click += BtnReg_Click;
            LoadShifts();
        }

        private void ucTechnicianShifts_Resize(object sender, EventArgs e)
        {
            ConfigureShiftListLayout();
            AdjustCalendarLayout();
            ResizeShiftRows();
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
            pnlListPanel.AutoScroll = false;
            flpShiftsTable.AutoScroll = true;

            int countShifts = 0;
            try
            {
                countShifts = shiftBUS.GetShiftCount();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting shift count: " + ex);
            }

            lblStatTotalNum.Text = countShifts.ToString();
            lblStatHoursNum.Text = (countShifts * 5) + "h";

            List<TechnicianShiftDTO> weekShifts = new List<TechnicianShiftDTO>();
            try
            {
                weekShifts = shiftBUS.GetList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting shifts list: " + ex);
            }

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

            flpShiftsTable.SuspendLayout();
            flpShiftsTable.Controls.Clear();
            flpShiftsTable.Controls.Add(CreateShiftTableRow("NGÀY", "CA", "CHUYÊN KHOA", "PHÒNG KHÁM", "TRẠNG THÁI", true));
            foreach (var s in weekShifts)
            {
                flpShiftsTable.Controls.Add(CreateShiftTableRow(s.ShiftDate.ToString("dd/MM/yyyy"), s.ShiftName, s.Department, s.Room, s.Status, false));
            }
            if (weekShifts.Count == 0)
            {
                flpShiftsTable.Controls.Add(CreateShiftTableRow("-", "-", "Chưa có ca trực", "-", "-", false));
            }
            flpShiftsTable.ResumeLayout();

            ConfigureShiftListLayout();
            AdjustCalendarLayout();
            ResizeShiftRows();
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

        private Control CreateShiftTableRow(string date, string shift, string department, string room, string status, bool header)
        {
            var row = new ucTechnicianShiftTableRow
            {
                Margin = new Padding(0, 0, 0, header ? 6 : 8),
                Width = ShiftRowWidth()
            };
            row.Configure(date, shift, department, room, status, header);
            return row;
        }

        private int ShiftRowWidth()
        {
            return Math.Max(720, flpShiftsTable.ClientSize.Width - 8);
        }

        private void ResizeShiftRows()
        {
            int width = ShiftRowWidth();
            foreach (Control row in flpShiftsTable.Controls)
            {
                row.Width = width;
            }
        }

        private void ConfigureShiftListLayout()
        {
            if (pnlListPanel == null || flpShiftsTable == null || lblListTitle == null)
            {
                return;
            }

            pnlListPanel.SuspendLayout();

            lblListTitle.Location = new Point(18, 16);
            lblListTitle.Size = new Size(Math.Max(360, pnlListPanel.ClientSize.Width - 36), 34);
            lblListTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            flpShiftsTable.Location = new Point(18, 58);
            flpShiftsTable.Size = new Size(
                Math.Max(720, pnlListPanel.ClientSize.Width - 36),
                Math.Max(150, pnlListPanel.ClientSize.Height - 76));
            flpShiftsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpShiftsTable.FlowDirection = FlowDirection.TopDown;
            flpShiftsTable.WrapContents = false;
            flpShiftsTable.AutoScroll = true;
            flpShiftsTable.BringToFront();

            pnlListPanel.ResumeLayout();
        }

        private void pnlDaysContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDayDate1_Click(object sender, EventArgs e)
        {

        }

        private void lblDayDate2_Click(object sender, EventArgs e)
        {

        }

        private void btnShift3_Click(object sender, EventArgs e)
        {

        }
    }
}
