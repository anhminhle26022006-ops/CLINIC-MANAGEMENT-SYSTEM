namespace TEST_MOCK_API
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
            dgvTest = new DataGridView();
            btnSync = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTest).BeginInit();
            SuspendLayout();
            // 
            // dgvTest
            // 
            dgvTest.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTest.Location = new Point(111, 115);
            dgvTest.Margin = new Padding(3, 4, 3, 4);
            dgvTest.Name = "dgvTest";
            dgvTest.RowHeadersWidth = 51;
            dgvTest.RowTemplate.Height = 24;
            dgvTest.Size = new Size(466, 252);
            dgvTest.TabIndex = 0;
            // 
            // btnSync
            // 
            btnSync.Location = new Point(792, 229);
            btnSync.Margin = new Padding(3, 4, 3, 4);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(75, 29);
            btnSync.TabIndex = 1;
            btnSync.Text = "MockApi";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 790);
            Controls.Add(btnSync);
            Controls.Add(dgvTest);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTest).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.Button btnSync;
    }
}

