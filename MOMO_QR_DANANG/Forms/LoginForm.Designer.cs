namespace MOMO_QR_DANANG
{
    partial class LoginForm
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cardPanel = new MOMO_QR_DANANG.RoundedPanel();
            this.cardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardPanel
            // 
            this.cardPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.cardPanel.BorderWidth = 1;
            this.cardPanel.Controls.Add(this.btnExit);
            this.cardPanel.Controls.Add(this.btnLogin);
            this.cardPanel.Controls.Add(this.lblError);
            this.cardPanel.Controls.Add(this.txtPassword);
            this.cardPanel.Controls.Add(this.lblPass);
            this.cardPanel.Controls.Add(this.txtUsername);
            this.cardPanel.Controls.Add(this.lblUser);
            this.cardPanel.Controls.Add(this.lblSub);
            this.cardPanel.Controls.Add(this.lblBrand);
            this.cardPanel.CornerRadius = 12;
            this.cardPanel.FillColor = System.Drawing.Color.White;
            this.cardPanel.Location = new System.Drawing.Point(50, 40);
            this.cardPanel.Name = "cardPanel";
            this.cardPanel.Size = new System.Drawing.Size(400, 460);
            this.cardPanel.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblBrand.Location = new System.Drawing.Point(20, 30);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(360, 48);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "HealthCare+";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSub.Location = new System.Drawing.Point(20, 80);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(360, 24);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Hệ thống phân luồng phòng khám";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblUser.Location = new System.Drawing.Point(40, 130);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(104, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.Location = new System.Drawing.Point(40, 155);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(320, 29);
            this.txtUsername.TabIndex = 3;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblPass.Location = new System.Drawing.Point(40, 205);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(70, 17);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(40, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(320, 29);
            this.txtPassword.TabIndex = 5;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblError.Location = new System.Drawing.Point(40, 275);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(320, 35);
            this.lblError.TabIndex = 6;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 325);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(320, 44);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnExit.Location = new System.Drawing.Point(40, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(320, 38);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(500, 540);
            this.Controls.Add(this.cardPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HealthCare+ - Đăng nhập";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.cardPanel.ResumeLayout(false);
            this.cardPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel cardPanel;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
    }
}

