﻿﻿namespace ClinicManagementSystem.Winforms.Forms
{
    partial class PayOsPaymentForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSoTaiKhoan = new TextBox();
            txtSoTien = new TextBox();
            txtNoiDung = new TextBox();
            label4 = new Label();
            label5 = new Label();
            picLogo = new PictureBox();
            button1 = new Button();
            label6 = new Label();
            button2 = new Button();
            groupBox1 = new GroupBox();
            picQRMOMO = new PictureBox();
            groupBox2 = new GroupBox();
            cboNganHang = new ComboBox();
            label8 = new Label();
            txtTenTaiKhoan = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQRMOMO).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 78);
            label1.Name = "label1";
            label1.Size = new Size(100, 18);
            label1.TabIndex = 0;
            label1.Text = "Mã đơn hàng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 153);
            label2.Name = "label2";
            label2.Size = new Size(57, 18);
            label2.TabIndex = 1;
            label2.Text = "Số tiền:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 187);
            label3.Name = "label3";
            label3.Size = new Size(70, 18);
            label3.TabIndex = 2;
            label3.Text = "Nội dung:";
            // 
            // txtSoTaiKhoan
            // 
            txtSoTaiKhoan.Location = new Point(134, 75);
            txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            txtSoTaiKhoan.Size = new Size(287, 26);
            txtSoTaiKhoan.TabIndex = 3;
            // 
            // txtSoTien
            // 
            txtSoTien.Location = new Point(134, 145);
            txtSoTien.Name = "txtSoTien";
            txtSoTien.Size = new Size(287, 26);
            txtSoTien.TabIndex = 4;
            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(134, 184);
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.Size = new Size(287, 26);
            txtNoiDung.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(131, 209);
            label4.Name = "label4";
            label4.Size = new Size(310, 18);
            label4.TabIndex = 6;
            label4.Text = "(PayOS sẽ rút gọn nội dung về tối đa 9 ký tự)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 235);
            label5.Name = "label5";
            label5.Size = new Size(44, 18);
            label5.TabIndex = 7;
            label5.Text = "Logo:";
            // 
            // picLogo
            // 
            picLogo.BackColor = SystemColors.ButtonHighlight;
            picLogo.Location = new Point(134, 235);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(64, 64);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 8;
            picLogo.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(118, 305);
            button1.Name = "button1";
            button1.Size = new Size(94, 23);
            button1.TabIndex = 9;
            button1.Text = "Chọn logo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DeepPink;
            label6.Location = new Point(272, 19);
            label6.Name = "label6";
            label6.Size = new Size(457, 36);
            label6.TabIndex = 10;
            label6.Text = "TẠO MÃ THANH TOÁN PAYOS";
            // 
            // button2
            // 
            button2.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DeepPink;
            button2.Location = new Point(290, 283);
            button2.Name = "button2";
            button2.Size = new Size(151, 45);
            button2.TabIndex = 11;
            button2.Text = "Tạo mã thanh toán";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.Zoom;
            groupBox1.Controls.Add(picQRMOMO);
            groupBox1.Location = new Point(530, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(345, 364);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mã QR PayOS";
            // 
            // picQRMOMO
            // 
            picQRMOMO.Location = new Point(6, 40);
            picQRMOMO.Name = "picQRMOMO";
            picQRMOMO.Size = new Size(333, 290);
            picQRMOMO.SizeMode = PictureBoxSizeMode.Zoom;
            picQRMOMO.TabIndex = 0;
            picQRMOMO.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cboNganHang);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtTenTaiKhoan);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtSoTaiKhoan);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(txtSoTien);
            groupBox2.Controls.Add(picLogo);
            groupBox2.Controls.Add(txtNoiDung);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(487, 364);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin thanh toán";
            // 
            // cboNganHang
            // 
            cboNganHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNganHang.FormattingEnabled = true;
            cboNganHang.Location = new Point(134, 40);
            cboNganHang.Name = "cboNganHang";
            cboNganHang.Size = new Size(287, 26);
            cboNganHang.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(47, 43);
            label8.Name = "label8";
            label8.Size = new Size(46, 18);
            label8.TabIndex = 14;
            label8.Text = "Cổng:";
            // 
            // txtTenTaiKhoan
            // 
            txtTenTaiKhoan.Location = new Point(134, 113);
            txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            txtTenTaiKhoan.Size = new Size(287, 26);
            txtTenTaiKhoan.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 116);
            label7.Name = "label7";
            label7.Size = new Size(84, 18);
            label7.TabIndex = 12;
            label7.Text = "Người mua:";
            // 
            // PayOsPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 458);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PayOsPaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo mã thanh toán PayOS";
            Load += PayOsPaymentForm_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQRMOMO).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoTaiKhoan;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picQRMOMO;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNganHang;
        private System.Windows.Forms.Label label8;
    }
}


