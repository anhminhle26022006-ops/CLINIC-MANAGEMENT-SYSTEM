using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoicuoi_report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnInLoaiSanPham_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var query = from loai in db.LoaiSanPhams 
                        select loai;
            reportViewer1.LocalReport.DataSources.Clear();

            // Thay đổi thành tên Namespace của bạn (ví dụ project tên là buoicuoi_report)
            reportViewer1.LocalReport.ReportEmbeddedResource = "buoicuoi_report.Report_loaiSP.rdlc";

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetLoaiSanPham", query));
            reportViewer1.RefreshReport();
        }
    }
}
