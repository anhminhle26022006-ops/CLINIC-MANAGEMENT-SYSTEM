using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.reception
{
    public partial class ConfirmAppointment : Form
    {

        public ConfirmAppointment(
        string patientName,
        string departmentName,
        string doctorName,
        string roomCode,
        string appointmentTime)
        {
            InitializeComponent();

            lbPatient.Text = patientName;
            lbDepartment.Text = departmentName;
            lbDoctor.Text = doctorName;
            lbRoom.Text = roomCode;
            lbTime.Text = appointmentTime;
        }

    }
}
