namespace DoAnLTDT
{
    partial class FormMenu
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
            this.btnDoThi = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMaTran = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMenuMinimize = new System.Windows.Forms.Button();
            this.btnMenuClose = new System.Windows.Forms.Button();
            this.labelMenuTitle = new MaterialSkin.Controls.MaterialLabel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDoThi
            // 
            this.btnDoThi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDoThi.Depth = 0;
            this.btnDoThi.Location = new System.Drawing.Point(96, 124);
            this.btnDoThi.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDoThi.Name = "btnDoThi";
            this.btnDoThi.Primary = true;
            this.btnDoThi.Size = new System.Drawing.Size(123, 65);
            this.btnDoThi.TabIndex = 0;
            this.btnDoThi.Text = "Tạo đồ thị";
            this.btnDoThi.UseVisualStyleBackColor = false;
            this.btnDoThi.Click += new System.EventHandler(this.btnDoThi_Click);
            // 
            // btnMaTran
            // 
            this.btnMaTran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnMaTran.Depth = 0;
            this.btnMaTran.Location = new System.Drawing.Point(96, 229);
            this.btnMaTran.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMaTran.Name = "btnMaTran";
            this.btnMaTran.Primary = true;
            this.btnMaTran.Size = new System.Drawing.Size(123, 65);
            this.btnMaTran.TabIndex = 0;
            this.btnMaTran.Text = "Tạo Ma Trận";
            this.btnMaTran.UseVisualStyleBackColor = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.panelMenu.Controls.Add(this.btnMenuMinimize);
            this.panelMenu.Controls.Add(this.btnMenuClose);
            this.panelMenu.Controls.Add(this.labelMenuTitle);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(327, 54);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMenu_MouseDown);
            // 
            // btnMenuMinimize
            // 
            this.btnMenuMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuMinimize.FlatAppearance.BorderSize = 0;
            this.btnMenuMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuMinimize.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMenuMinimize.Location = new System.Drawing.Point(258, 3);
            this.btnMenuMinimize.Name = "btnMenuMinimize";
            this.btnMenuMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMenuMinimize.TabIndex = 1;
            this.btnMenuMinimize.Text = "-";
            this.btnMenuMinimize.UseVisualStyleBackColor = true;
            this.btnMenuMinimize.Click += new System.EventHandler(this.btnMenuMinimize_Click);
            // 
            // btnMenuClose
            // 
            this.btnMenuClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenuClose.FlatAppearance.BorderSize = 0;
            this.btnMenuClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuClose.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuClose.ForeColor = System.Drawing.Color.White;
            this.btnMenuClose.Location = new System.Drawing.Point(294, 3);
            this.btnMenuClose.Name = "btnMenuClose";
            this.btnMenuClose.Size = new System.Drawing.Size(30, 30);
            this.btnMenuClose.TabIndex = 1;
            this.btnMenuClose.Text = "x";
            this.btnMenuClose.UseVisualStyleBackColor = true;
            this.btnMenuClose.Click += new System.EventHandler(this.btnMenuClose_Click);
            // 
            // labelMenuTitle
            // 
            this.labelMenuTitle.AutoSize = true;
            this.labelMenuTitle.Depth = 0;
            this.labelMenuTitle.Font = new System.Drawing.Font("iCiel Cadena", 15F);
            this.labelMenuTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelMenuTitle.Location = new System.Drawing.Point(12, 12);
            this.labelMenuTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelMenuTitle.Name = "labelMenuTitle";
            this.labelMenuTitle.Size = new System.Drawing.Size(62, 28);
            this.labelMenuTitle.TabIndex = 0;
            this.labelMenuTitle.Text = "Menu";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(327, 403);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btnMaTran);
            this.Controls.Add(this.btnDoThi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnDoThi;
        private MaterialSkin.Controls.MaterialRaisedButton btnMaTran;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMenuClose;
        private MaterialSkin.Controls.MaterialLabel labelMenuTitle;
        private System.Windows.Forms.Button btnMenuMinimize;
    }
}

