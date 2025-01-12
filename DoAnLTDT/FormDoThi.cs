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
    public partial class FormDoThi : Form
    {

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Button btncreate = new Button();
        private int dx = 0, dy = 0, dx1 = 0, dy1 = 0; // dx,dy là tọa độ trong không gian Oxy của nút 1, dx1 dy1 là tọa độ trong không gian Oxy của nút 2
        private int dinh1 = -1, dinh2 = -1;  // d1,d2 là 2 biến dùng để lưu tạm thứ tự đỉnh để xác định đúng Dinh1,Dinh2
        private int Dinh1 = -1, Dinh2 = -1;
        private Class_Graph.Edge Edges = new Class_Graph.Edge();// khởi tạo biến cạnh để lưu cạnh tạm thời khi lấy tọa độ giữa 2 node
        private List<Class_Graph.Edge> ListarrEdge = new List<Class_Graph.Edge> { };// khoi tao mot list co du lieu la can
        private Class_Graph.NodeGraph Nod = new Class_Graph.NodeGraph();
        private List<Class_Graph.NodeGraph> ListarrNod = new List<Class_Graph.NodeGraph> { };
        private int PtuxoaNod = -1; // biến lưu tạm hỗ trợ việc xóa nút
        private int sodinh = 0;
        private int sodinhcheck = 0;
        public int[,] Matrix = new int[100, 100];
        private DoAnLTDT.Class_Graph.Graph Dothi = new Class_Graph.Graph();
        private string[] TPLT = new string[] { }; // biến lưu kết quả khi duyệt TPLT
        private int i = 0;
        private List<Class_Graph.Edge> Egl = new List<Class_Graph.Edge> { }; // khoi tao mot list co du lieu la canh ket qua cua DFS hay BFS
        private List<Class_Graph.NodeGraph> LNodLT = new List<Class_Graph.NodeGraph> { };
        private Class_Graph.Edge Eg = new Class_Graph.Edge();
        private Class_Graph.NodeGraph NodLT = new Class_Graph.NodeGraph();
        private int socanh = 0;
        public FormDoThi()
        {
            InitializeComponent();
            random = new Random();
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.Colorlist.Count);
            while (tempIndex == index)
            {
               index = random.Next(ThemeColor.Colorlist.Count);
            }
            tempIndex = index;
            string color = ThemeColor.Colorlist[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelTitleBar.BackColor = color;
                    //panelDoThiLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3); //2 cai nay dung de doi mau cai title luon nen neu thich thi su dung
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelDoThiMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnThemCanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnXoaCanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void pnlVeDoThi_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = new Button();
            btn.Width = 25;
            btn.Height = 25;
            btn.Location = new Point(e.X, e.Y);
            btn.Name = string.Format("{0},{1}", e.X, e.Y);
            btn.Text = string.Format("{0}", sodinh++);
            btn.BackColor = Color.YellowGreen;
            btn.ForeColor = Color.White;
            btn.Click += new EventHandler(getToaDo);
            pnlVeDoThi.Controls.Add(btn);
            Nod.x = e.X;
            Nod.y = e.Y;
            ListarrNod.Add(Nod);
            Nod = new Class_Graph.NodeGraph();
            LoadComBoBoxDinhBatDau();
            LoadComBoBoxDinhKetThuc();
        }
        #region Method Vẽ đồ thị
        #region 1. Lấy toạ độ các đỉnh
        public void getToaDo(object sender, EventArgs e)
        {
            btncreate = (Button)sender;
            if (dx != 0 && dx1 != 0)
            {
                dx = dy = dx1 = dy1 = 0;
                dx = btncreate.Location.X + 12;
                dy = btncreate.Location.Y + 12;
                Edges.x = dx;
                Edges.y = dy;
                Edges.z = dx1;
                Edges.t = dy1;
            }
            if (dx == 0 && dy == 0)
            {
                dx = btncreate.Location.X + 12;
                dy = btncreate.Location.Y + 12;
                Edges.x = dx;
                Edges.y = dy;
            }
            else
            {
                if (dx1 == 0 && dy1 == 0)
                {
                    dx1 = btncreate.Location.X + 12;
                    dy1 = btncreate.Location.Y + 12;
                    Edges.z = dx1;
                    Edges.t = dy1;
                }
            }
            if (dx1 == dx)
            {
                dx1 = dy1 = 0;
                Edges.z = dx1;
                Edges.t = dy1;
            }
            if (dinh1 != -1 && dinh2 != -1)
            {
                dinh1 = dinh2 = -1;
                dinh1 = Convert.ToInt32(btncreate.Text);
                Dinh1 = dinh1;
                Dinh2 = dinh2;
            }
            if (dinh1 == -1 && dinh2 == -1)
            {
                dinh1 = Convert.ToInt32(btncreate.Text);
                Dinh1 = dinh1;

            }
            else
            {
                if (dinh2 == -1)
                {
                    dinh2 = Convert.ToInt32(btncreate.Text);
                    Dinh2 = dinh2;
                }
            }
            if (dinh1 == dinh2)
            {
                dinh2 = -1;
                Dinh2 = dinh2;
            }
            // txtKetqua.Text = dx.ToString() + " " + dy.ToString() + " " + Dinh1.ToString() + " " + dx1.ToString() + " " + dy1.ToString() + " " + Dinh2.ToString();
            // txtKetqua.Text = dx.ToString() + " " + dy.ToString() + ' ' + dx1.ToString() + " " + dy1.ToString();
            txtKetqua.Text = Dinh1.ToString() + "  " + Dinh2.ToString();
        }
        #endregion
        #region 2. Vẽ các cạnh
        private void VeDoThi(Class_Graph.Edge NodeG)
        {
            // kiểm tra xem tọa độ tất cả các cạnh có khác 0 không?
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng" && NodeG.CheckEdge() && check(Dinh1, Dinh2))
            {

                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen BlackPen = new Pen(Color.Black, 2);
                dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                dx = dy = dx1 = dy1 = 0;
                ListarrEdge.Add(NodeG);
                Matrix[Dinh1, Dinh2] = 1;
                Matrix[Dinh2, Dinh1] = 1;
            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng" && NodeG.CheckEdge() && check(Dinh1, Dinh2))
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen BlackPen = new Pen(Color.Black, 2);
                    dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    dx = dy = dx1 = dy1 = 0;
                    ListarrEdge.Add(NodeG);
                    Matrix[Dinh1, Dinh2] = 1;
                }
            }
        }
        #endregion
        #region 5. Vẽ hướng đồ thị
        private void DrawArrowhead(Graphics gr, Pen pen, int x, int y, int z, int t) //vẽ hướng đồ thị có hướng
        {
            float dx = z - x; //toa do vector cua doan thang tu (x, y)
            float dy = t - y; //toa do vector z, t
            float dist = (float)Math.Sqrt(dx * dx + dy * dy); // su dung pytago tinh duoc khoang cach giua 2 diem
            dx /= dist;
            dy /= dist; // chuan hoa 
            const float scale = 5; // nhan voi scale de tao do dai phu hop
            dx *= scale;
            dy *= scale;
            float p1x = -dy; // xoay vector (dx,dy) mot goc -+90do nham` tao ra 2 vector vuong goc (p1x, p1y) (p2x, p2y) -> ve hai canh cua dau mui ten
            float p1y = dx;
            float p2x = dy;
            float p2y = -dx;
            float cx = (x + z) / 2f; //trung diem x,y ->
            float cy = (y + t) / 2f; //trung diem z, t
            float cxy = (cx + z) / 2f; //trung diem (cx, cy)
            float cyx = (cy + t) / 2f; 
            PointF[] points =
            {
        new PointF (cxy - dx + p1x, cyx - dy + p1y), //goc trai mui ten
        new PointF (cxy, cyx), //dinh dau mui ten, cho~ mui ten chi toi
        new PointF (cxy - dx + p2x, cyx - dy + p2y), //goc phai mui ten
            };
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //lam min duong` ke~ 
            gr.DrawLines(pen, points); // ve cac duong noi 3 diem trong mang points -> thanh hinh mui ten
        }
        #endregion
        #endregion
        #region load combo đỉnh bắt đầu và kết thúc
        private void LoadComBoBoxDinhBatDau()
        {
            int[] ArrVertex = new int[sodinh];
            for (int i = 0; i < sodinh; i++)
            {
                ArrVertex[i] = i;
            }
            cbxDinhBatDau.DataSource = ArrVertex;
        }
        private void LoadComBoBoxDinhKetThuc()
        {
            int[] ArrVertex = new int[sodinh];
            for (int i = 0; i < sodinh; i++)
            {
                ArrVertex[i] = i;
            }
            cbxDinhKetThuc.DataSource = ArrVertex;
        }
        #endregion
        private bool check(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                return Matrix[x, y] != 1;
            }
            else
            {
                return false;
            }
        }
        private void btnXoaDinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void FormDoThi_Load(object sender, EventArgs e)
        {

        }
    }
}
