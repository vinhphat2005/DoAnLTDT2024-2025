using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTDT
{
    public partial class FormMenu : MaterialSkin.Controls.MaterialForm
    {
        public FormMenu()
        {
            InitializeComponent();
        }

      

        private void FormMenu_Load(object sender, EventArgs e)
        {
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            
        }

        private void btnDoThi_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDoThi graph = new FormDoThi();
            graph.FormClosed += (s, args) => this.Show(); // Hiện lại FormMenu khi FormDoThi đóng
            graph.Show();
        }
    }
}
