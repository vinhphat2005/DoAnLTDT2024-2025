namespace DoAnLTDT
{
    partial class FormMaTran
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
            this.panelMaTranMenu = new System.Windows.Forms.Panel();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnTaoMaTran = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnVeDoThi = new System.Windows.Forms.Button();
            this.btnXoaDinh = new System.Windows.Forms.Button();
            this.btnThemDinh = new System.Windows.Forms.Button();
            this.btnXoaCanh = new System.Windows.Forms.Button();
            this.btnThemCanh = new System.Windows.Forms.Button();
            this.panelMaTranLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.pbBang = new System.Windows.Forms.PictureBox();
            this.lbDSDinh = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDSCanh = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.txtMaTran = new System.Windows.Forms.TextBox();
            this.pnlDuyet = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDinhBatDau = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDinhKetThuc = new System.Windows.Forms.ComboBox();
            this.cbxChucNang = new System.Windows.Forms.ComboBox();
            this.btnReadFile = new DoAnLTDT.CustomButton();
            this.panelTitleBar.SuspendLayout();
            this.panelMaTranMenu.SuspendLayout();
            this.panelMaTranLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlDuyet.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnMaTranMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaTranClose);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(955, 80);
            this.panelTitleBar.TabIndex = 3;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMaTranMinimize
            // 
            this.btnMaTranMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaTranMinimize.FlatAppearance.BorderSize = 0;
            this.btnMaTranMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaTranMinimize.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaTranMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMaTranMinimize.Location = new System.Drawing.Point(884, 3);
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
            this.btnMaTranClose.Location = new System.Drawing.Point(920, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(415, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(119, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tạo Ma Trận";
            // 
            // panelMaTranMenu
            // 
            this.panelMaTranMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMaTranMenu.Controls.Add(this.btnSaveFile);
            this.panelMaTranMenu.Controls.Add(this.btnTaoMaTran);
            this.panelMaTranMenu.Controls.Add(this.btnLamMoi);
            this.panelMaTranMenu.Controls.Add(this.btnDuyet);
            this.panelMaTranMenu.Controls.Add(this.btnVeDoThi);
            this.panelMaTranMenu.Controls.Add(this.btnXoaDinh);
            this.panelMaTranMenu.Controls.Add(this.btnThemDinh);
            this.panelMaTranMenu.Controls.Add(this.btnXoaCanh);
            this.panelMaTranMenu.Controls.Add(this.btnThemCanh);
            this.panelMaTranMenu.Controls.Add(this.panelMaTranLogo);
            this.panelMaTranMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMaTranMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMaTranMenu.Name = "panelMaTranMenu";
            this.panelMaTranMenu.Size = new System.Drawing.Size(220, 656);
            this.panelMaTranMenu.TabIndex = 2;
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaveFile.FlatAppearance.BorderSize = 0;
            this.btnSaveFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFile.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSaveFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveFile.Location = new System.Drawing.Point(0, 560);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSaveFile.Size = new System.Drawing.Size(220, 60);
            this.btnSaveFile.TabIndex = 9;
            this.btnSaveFile.Text = "Lưu file";
            this.btnSaveFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnTaoMaTran
            // 
            this.btnTaoMaTran.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaoMaTran.FlatAppearance.BorderSize = 0;
            this.btnTaoMaTran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoMaTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoMaTran.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTaoMaTran.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoMaTran.Location = new System.Drawing.Point(0, 500);
            this.btnTaoMaTran.Name = "btnTaoMaTran";
            this.btnTaoMaTran.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTaoMaTran.Size = new System.Drawing.Size(220, 60);
            this.btnTaoMaTran.TabIndex = 8;
            this.btnTaoMaTran.Text = "Tạo ma trận ngẫu nhiên";
            this.btnTaoMaTran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaoMaTran.UseVisualStyleBackColor = true;
            this.btnTaoMaTran.Click += new System.EventHandler(this.btnTaoMaTran_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(0, 440);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLamMoi.Size = new System.Drawing.Size(220, 60);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Reset";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDuyet
            // 
            this.btnDuyet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyet.FlatAppearance.BorderSize = 0;
            this.btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuyet.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDuyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuyet.Location = new System.Drawing.Point(0, 380);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDuyet.Size = new System.Drawing.Size(220, 60);
            this.btnDuyet.TabIndex = 6;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDuyet.UseVisualStyleBackColor = true;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnVeDoThi
            // 
            this.btnVeDoThi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVeDoThi.FlatAppearance.BorderSize = 0;
            this.btnVeDoThi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeDoThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeDoThi.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnVeDoThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeDoThi.Location = new System.Drawing.Point(0, 320);
            this.btnVeDoThi.Name = "btnVeDoThi";
            this.btnVeDoThi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnVeDoThi.Size = new System.Drawing.Size(220, 60);
            this.btnVeDoThi.TabIndex = 5;
            this.btnVeDoThi.Text = "Vẽ đồ thị";
            this.btnVeDoThi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVeDoThi.UseVisualStyleBackColor = true;
            this.btnVeDoThi.Click += new System.EventHandler(this.btnVeDoThi_Click);
            // 
            // btnXoaDinh
            // 
            this.btnXoaDinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXoaDinh.FlatAppearance.BorderSize = 0;
            this.btnXoaDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDinh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXoaDinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDinh.Location = new System.Drawing.Point(0, 260);
            this.btnXoaDinh.Name = "btnXoaDinh";
            this.btnXoaDinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnXoaDinh.Size = new System.Drawing.Size(220, 60);
            this.btnXoaDinh.TabIndex = 4;
            this.btnXoaDinh.Text = "Xoá đỉnh";
            this.btnXoaDinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaDinh.UseVisualStyleBackColor = true;
            this.btnXoaDinh.Click += new System.EventHandler(this.btnXoaDinh_Click);
            // 
            // btnThemDinh
            // 
            this.btnThemDinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemDinh.FlatAppearance.BorderSize = 0;
            this.btnThemDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDinh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThemDinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDinh.Location = new System.Drawing.Point(0, 200);
            this.btnThemDinh.Name = "btnThemDinh";
            this.btnThemDinh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnThemDinh.Size = new System.Drawing.Size(220, 60);
            this.btnThemDinh.TabIndex = 3;
            this.btnThemDinh.Text = "Thêm đỉnh";
            this.btnThemDinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemDinh.UseVisualStyleBackColor = true;
            this.btnThemDinh.Click += new System.EventHandler(this.btnThemDinh_Click);
            // 
            // btnXoaCanh
            // 
            this.btnXoaCanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXoaCanh.FlatAppearance.BorderSize = 0;
            this.btnXoaCanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCanh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnXoaCanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaCanh.Location = new System.Drawing.Point(0, 140);
            this.btnXoaCanh.Name = "btnXoaCanh";
            this.btnXoaCanh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnXoaCanh.Size = new System.Drawing.Size(220, 60);
            this.btnXoaCanh.TabIndex = 2;
            this.btnXoaCanh.Text = "Xoá cạnh";
            this.btnXoaCanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoaCanh.UseVisualStyleBackColor = true;
            this.btnXoaCanh.Click += new System.EventHandler(this.btnXoaCanh_Click);
            // 
            // btnThemCanh
            // 
            this.btnThemCanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemCanh.FlatAppearance.BorderSize = 0;
            this.btnThemCanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCanh.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnThemCanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemCanh.Location = new System.Drawing.Point(0, 80);
            this.btnThemCanh.Name = "btnThemCanh";
            this.btnThemCanh.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnThemCanh.Size = new System.Drawing.Size(220, 60);
            this.btnThemCanh.TabIndex = 1;
            this.btnThemCanh.Text = "Thêm cạnh";
            this.btnThemCanh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemCanh.UseVisualStyleBackColor = true;
            this.btnThemCanh.Click += new System.EventHandler(this.btnThemCanh_Click);
            // 
            // panelMaTranLogo
            // 
            this.panelMaTranLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelMaTranLogo.Controls.Add(this.lblLogo);
            this.panelMaTranLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMaTranLogo.Location = new System.Drawing.Point(0, 0);
            this.panelMaTranLogo.Name = "panelMaTranLogo";
            this.panelMaTranLogo.Size = new System.Drawing.Size(220, 80);
            this.panelMaTranLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.LightGray;
            this.lblLogo.Location = new System.Drawing.Point(75, 32);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(71, 20);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Chill Guy";
            this.lblLogo.Click += new System.EventHandler(this.lblLogo_Click);
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.BackColor = System.Drawing.SystemColors.Control;
            this.txtDuongDan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuongDan.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtDuongDan.Location = new System.Drawing.Point(317, 102);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.ReadOnly = true;
            this.txtDuongDan.Size = new System.Drawing.Size(384, 26);
            this.txtDuongDan.TabIndex = 39;
            // 
            // pbBang
            // 
            this.pbBang.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbBang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbBang.Location = new System.Drawing.Point(732, 97);
            this.pbBang.Name = "pbBang";
            this.pbBang.Size = new System.Drawing.Size(438, 547);
            this.pbBang.TabIndex = 58;
            this.pbBang.TabStop = false;
            this.pbBang.Paint += new System.Windows.Forms.PaintEventHandler(this.pbBang_Paint);
            // 
            // lbDSDinh
            // 
            this.lbDSDinh.FormattingEnabled = true;
            this.lbDSDinh.Location = new System.Drawing.Point(237, 320);
            this.lbDSDinh.Name = "lbDSDinh";
            this.lbDSDinh.Size = new System.Drawing.Size(155, 134);
            this.lbDSDinh.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(447, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 59;
            this.label6.Text = "Danh sách đỉnh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 60;
            this.label5.Text = "Danh sách cạnh";
            // 
            // lbDSCanh
            // 
            this.lbDSCanh.FormattingEnabled = true;
            this.lbDSCanh.Location = new System.Drawing.Point(451, 320);
            this.lbDSCanh.Name = "lbDSCanh";
            this.lbDSCanh.Size = new System.Drawing.Size(165, 134);
            this.lbDSCanh.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(226, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Chức Năng";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.groupBox1.Controls.Add(this.txtKetQua);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(230, 463);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 170);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKetQua.BackColor = System.Drawing.SystemColors.Control;
            this.txtKetQua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetQua.Location = new System.Drawing.Point(6, 19);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKetQua.Size = new System.Drawing.Size(412, 141);
            this.txtKetQua.TabIndex = 2;
            // 
            // txtMaTran
            // 
            this.txtMaTran.BackColor = System.Drawing.Color.White;
            this.txtMaTran.Location = new System.Drawing.Point(540, 145);
            this.txtMaTran.Multiline = true;
            this.txtMaTran.Name = "txtMaTran";
            this.txtMaTran.ReadOnly = true;
            this.txtMaTran.Size = new System.Drawing.Size(161, 140);
            this.txtMaTran.TabIndex = 39;
            // 
            // pnlDuyet
            // 
            this.pnlDuyet.BackColor = System.Drawing.Color.Transparent;
            this.pnlDuyet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlDuyet.Controls.Add(this.label2);
            this.pnlDuyet.Controls.Add(this.cbxDinhBatDau);
            this.pnlDuyet.Controls.Add(this.label3);
            this.pnlDuyet.Controls.Add(this.cbxDinhKetThuc);
            this.pnlDuyet.Location = new System.Drawing.Point(230, 185);
            this.pnlDuyet.Name = "pnlDuyet";
            this.pnlDuyet.Size = new System.Drawing.Size(304, 100);
            this.pnlDuyet.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đỉnh Bắt Đầu";
            // 
            // cbxDinhBatDau
            // 
            this.cbxDinhBatDau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDinhBatDau.FormattingEnabled = true;
            this.cbxDinhBatDau.Location = new System.Drawing.Point(154, 16);
            this.cbxDinhBatDau.Name = "cbxDinhBatDau";
            this.cbxDinhBatDau.Size = new System.Drawing.Size(139, 21);
            this.cbxDinhBatDau.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đỉnh Kết Thúc";
            // 
            // cbxDinhKetThuc
            // 
            this.cbxDinhKetThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDinhKetThuc.FormattingEnabled = true;
            this.cbxDinhKetThuc.Location = new System.Drawing.Point(153, 58);
            this.cbxDinhKetThuc.Name = "cbxDinhKetThuc";
            this.cbxDinhKetThuc.Size = new System.Drawing.Size(140, 21);
            this.cbxDinhKetThuc.TabIndex = 1;
            // 
            // cbxChucNang
            // 
            this.cbxChucNang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChucNang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxChucNang.FormattingEnabled = true;
            this.cbxChucNang.Items.AddRange(new object[] {
            "Duyệt BFS",
            "Duyệt DFS",
            "Xét Liên Thông"});
            this.cbxChucNang.Location = new System.Drawing.Point(365, 146);
            this.cbxChucNang.Name = "cbxChucNang";
            this.cbxChucNang.Size = new System.Drawing.Size(158, 27);
            this.cbxChucNang.TabIndex = 45;
            this.cbxChucNang.SelectedValueChanged += new System.EventHandler(this.cbxChucNang_SelectedValueChanged);
            // 
            // btnReadFile
            // 
            this.btnReadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnReadFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnReadFile.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReadFile.BorderRadius = 20;
            this.btnReadFile.BorderSize = 0;
            this.btnReadFile.FlatAppearance.BorderSize = 0;
            this.btnReadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadFile.ForeColor = System.Drawing.Color.White;
            this.btnReadFile.Location = new System.Drawing.Point(226, 90);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(85, 50);
            this.btnReadFile.TabIndex = 38;
            this.btnReadFile.Text = "Đọc File";
            this.btnReadFile.TextColor = System.Drawing.Color.White;
            this.btnReadFile.UseVisualStyleBackColor = false;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // FormMaTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 656);
            this.Controls.Add(this.cbxChucNang);
            this.Controls.Add(this.pnlDuyet);
            this.Controls.Add(this.txtMaTran);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDSDinh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbDSCanh);
            this.Controls.Add(this.pbBang);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMaTranMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMaTran";
            this.Text = "FormMaTran";
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelMaTranMenu.ResumeLayout(false);
            this.panelMaTranLogo.ResumeLayout(false);
            this.panelMaTranLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDuyet.ResumeLayout(false);
            this.pnlDuyet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button btnMaTranMinimize;
        private System.Windows.Forms.Button btnMaTranClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelMaTranMenu;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnVeDoThi;
        private System.Windows.Forms.Button btnXoaDinh;
        private System.Windows.Forms.Button btnThemDinh;
        private System.Windows.Forms.Button btnXoaCanh;
        private System.Windows.Forms.Button btnThemCanh;
        private System.Windows.Forms.Panel panelMaTranLogo;
        private System.Windows.Forms.Label lblLogo;
        private CustomButton btnReadFile;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.PictureBox pbBang;
        private System.Windows.Forms.Button btnTaoMaTran;
        private System.Windows.Forms.ListBox lbDSDinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbDSCanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.TextBox txtMaTran;
        private System.Windows.Forms.Panel pnlDuyet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDinhBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDinhKetThuc;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.ComboBox cbxChucNang;
    }
}