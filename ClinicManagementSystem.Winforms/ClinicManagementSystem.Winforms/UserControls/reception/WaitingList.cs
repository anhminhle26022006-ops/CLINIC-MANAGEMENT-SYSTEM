using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class WaitingList : UserControl
    {
        private readonly WaitingListController controller = new();
        private List<DoctorQueueDTO> allDoctors = new();

        public WaitingList()
        {
            InitializeComponent();

            flpDoctor.AutoScroll = true;
            flpDoctor.WrapContents = true;
            flpDoctor.FlowDirection = FlowDirection.LeftToRight;

            flpDepartment.WrapContents = true;
        }

        private void WaitingList_Load(
    object sender,
    EventArgs e)
        {
            LoadDashboardCards();

            allDoctors =
                controller.GetDoctorQueues();

            LoadDepartments();

            if (allDoctors.Any())
            {
                LoadDoctorCards(allDoctors);
            }

        }

        private void LoadDashboardCards()
        {
            lbWaiting.Text =
                controller.GetWaitingCount().ToString();

            lbDoing.Text =
                controller.GetExaminingCount().ToString();

            lbDone.Text =
                controller.GetCompletedCount().ToString();

            lbActiveRoom.Text =
                controller.GetActiveRoomCount().ToString();

            int totalRooms =
                controller.GetTotalRoomCount();

            label12.Text =
                $" / {totalRooms}";
        }

        private Button CreateDepartmentButton(
    string departmentName)
        {
            Button btn = new Button
            {
                Text = departmentName,
                Width = 150,
                Height = 45,
                Margin = new Padding(5),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(245, 245, 245),
                ForeColor = Color.FromArgb(44, 62, 80),
                Font = new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold)
            };

            btn.FlatAppearance.BorderSize = 0;

            return btn;
        }

        private void LoadDepartments()
        {
            flpDepartment.Controls.Clear();

            var departments = controller
       .GetDepartments()
       .Where(d =>
           d.DepartmentName != "Hành chính" &&
           d.DepartmentName != "Tiếp nhận" &&
           d.DepartmentName != "Nhà thuốc")
       .ToList();

            bool firstButton = true;

            foreach (var department in departments)
            {
                Button btn =
                    CreateDepartmentButton(
                        department.DepartmentName);

                if (firstButton)
                {
                    btn.BackColor = Color.RoyalBlue;
                    btn.ForeColor = Color.White;
                    firstButton = false;
                }

                btn.Click += (s, e) =>
                {
                    foreach (Button b in flpDepartment.Controls)
                    {
                        b.BackColor =
                            Color.FromArgb(245, 245, 245);

                        b.ForeColor =
                            Color.Black;
                    }

                    btn.BackColor =
                        Color.RoyalBlue;

                    btn.ForeColor =
                        Color.White;

                    var filtered =
                        allDoctors
                        .Where(x =>
                            x.DepartmentName ==
                            department.DepartmentName)
                        .ToList();

                    LoadDoctorCards(filtered);
                };

                flpDepartment.Controls.Add(btn);
            }
        }


        private void LoadDoctorCards(
    List<DoctorQueueDTO> doctors)
        {
            flpDoctor.Controls.Clear();

            int cardWidth =
    (flpDoctor.ClientSize.Width
     - SystemInformation.VerticalScrollBarWidth
     - 30) / 2;

            foreach (var doctor in doctors)
            {
                DoctorCard card = new DoctorCard();

                card.Size = new Size(
                    cardWidth,
                    450);

                card.Margin = new Padding(5);

                card.SetupDoctorCard(doctor);

                flpDoctor.Controls.Add(card);
            }
        }
    }
}
