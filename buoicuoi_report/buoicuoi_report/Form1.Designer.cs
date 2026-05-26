namespace buoicuoi_report
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInLoaiSanPham = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnInLoaiSanPham
            // 
            this.btnInLoaiSanPham.Location = new System.Drawing.Point(140, 75);
            this.btnInLoaiSanPham.Name = "btnInLoaiSanPham";
            this.btnInLoaiSanPham.Size = new System.Drawing.Size(238, 107);
            this.btnInLoaiSanPham.TabIndex = 0;
            this.btnInLoaiSanPham.Text = "In";
            this.btnInLoaiSanPham.UseVisualStyleBackColor = true;
            this.btnInLoaiSanPham.Click += new System.EventHandler(this.btnInLoaiSanPham_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(81, 270);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1279, 440);
            this.reportViewer1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 753);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnInLoaiSanPham);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInLoaiSanPham;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}

