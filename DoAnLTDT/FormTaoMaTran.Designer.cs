namespace DoAnLTDT
{
    partial class FormTaoMaTran
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMaTranMinimize = new System.Windows.Forms.Button();
            this.btnMaTranClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMaTran = new System.Windows.Forms.Panel();
            this.btnRandom = new DoAnLTDT.CustomButton();
            this.btnTaoMaTran = new DoAnLTDT.CustomButton();
            this.btnDone = new DoAnLTDT.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoDinh = new System.Windows.Forms.TextBox();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnMaTranMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaTranClose);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(711, 80);
            this.panelTitleBar.TabIndex = 5;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMaTranMinimize
            // 
            this.btnMaTranMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaTranMinimize.FlatAppearance.BorderSize = 0;
            this.btnMaTranMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaTranMinimize.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaTranMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMaTranMinimize.Location = new System.Drawing.Point(640, 3);
            this.btnMaTranMinimize.Name = "btnMaTranMinimize";
            this.btnMaTranMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMaTranMinimize.TabIndex = 30;
            this.btnMaTranMinimize.Text = "-";
            this.btnMaTranMinimize.UseVisualStyleBackColor = true;
            this.btnMaTranMinimize.Click += new System.EventHandler(this.btnMaTranMinimize_Click);
            // 
            // btnMaTranClose
            // 
            this.btnMaTranClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaTranClose.FlatAppearance.BorderSize = 0;
            this.btnMaTranClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaTranClose.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaTranClose.ForeColor = System.Drawing.Color.White;
            this.btnMaTranClose.Location = new System.Drawing.Point(676, 3);
            this.btnMaTranClose.Name = "btnMaTranClose";
            this.btnMaTranClose.Size = new System.Drawing.Size(30, 30);
            this.btnMaTranClose.TabIndex = 31;
            this.btnMaTranClose.Text = "x";
            this.btnMaTranClose.UseVisualStyleBackColor = true;
            this.btnMaTranClose.Click += new System.EventHandler(this.btnMaTranClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("iCiel Cadena", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(242, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tạo Ma Trận Ngẫu Nhiên";
            // 
            // pnlMaTran
            // 
            this.pnlMaTran.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlMaTran.Location = new System.Drawing.Point(12, 151);
            this.pnlMaTran.Name = "pnlMaTran";
            this.pnlMaTran.Size = new System.Drawing.Size(687, 268);
            this.pnlMaTran.TabIndex = 7;
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnRandom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnRandom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRandom.BorderRadius = 20;
            this.btnRandom.BorderSize = 0;
            this.btnRandom.FlatAppearance.BorderSize = 0;
            this.btnRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.ForeColor = System.Drawing.Color.White;
            this.btnRandom.Location = new System.Drawing.Point(505, 86);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(99, 49);
            this.btnRandom.TabIndex = 39;
            this.btnRandom.Text = "Lấy số ngẫu nhiên";
            this.btnRandom.TextColor = System.Drawing.Color.White;
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnTaoMaTran
            // 
            this.btnTaoMaTran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnTaoMaTran.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnTaoMaTran.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnTaoMaTran.BorderRadius = 20;
            this.btnTaoMaTran.BorderSize = 0;
            this.btnTaoMaTran.FlatAppearance.BorderSize = 0;
            this.btnTaoMaTran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMaTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMaTran.ForeColor = System.Drawing.Color.White;
            this.btnTaoMaTran.Location = new System.Drawing.Point(413, 86);
            this.btnTaoMaTran.Name = "btnTaoMaTran";
            this.btnTaoMaTran.Size = new System.Drawing.Size(86, 49);
            this.btnTaoMaTran.TabIndex = 39;
            this.btnTaoMaTran.Text = "Tạo ma trận";
            this.btnTaoMaTran.TextColor = System.Drawing.Color.White;
            this.btnTaoMaTran.UseVisualStyleBackColor = false;
            this.btnTaoMaTran.Click += new System.EventHandler(this.btnTaoMaTran_Click);
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnDone.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnDone.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDone.BorderRadius = 20;
            this.btnDone.BorderSize = 0;
            this.btnDone.FlatAppearance.BorderSize = 0;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.Location = new System.Drawing.Point(610, 86);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(78, 49);
            this.btnDone.TabIndex = 39;
            this.btnDone.Text = "Hoàn tất";
            this.btnDone.TextColor = System.Drawing.Color.White;
            this.btnDone.UseVisualStyleBackColor = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            this.btnDone.MouseLeave += new System.EventHandler(this.btnDone_MouseLeave);
            this.btnDone.MouseHover += new System.EventHandler(this.btnDone_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 40;
            this.label1.Text = "Số đỉnh";
            // 
            // txtSoDinh
            // 
            this.txtSoDinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDinh.Location = new System.Drawing.Point(73, 97);
            this.txtSoDinh.Name = "txtSoDinh";
            this.txtSoDinh.Size = new System.Drawing.Size(65, 26);
            this.txtSoDinh.TabIndex = 41;
            // 
            // FormTaoMaTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 431);
            this.Controls.Add(this.txtSoDinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTaoMaTran);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.pnlMaTran);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTaoMaTran";
            this.Text = "FormTaoMaTran";
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button btnMaTranMinimize;
        private System.Windows.Forms.Button btnMaTranClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMaTran;
        private CustomButton btnRandom;
        private CustomButton btnTaoMaTran;
        private CustomButton btnDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoDinh;
    }
}