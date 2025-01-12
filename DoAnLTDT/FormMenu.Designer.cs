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
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(327, 403);
            this.Controls.Add(this.btnMaTran);
            this.Controls.Add(this.btnDoThi);
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnDoThi;
        private MaterialSkin.Controls.MaterialRaisedButton btnMaTran;
    }
}

