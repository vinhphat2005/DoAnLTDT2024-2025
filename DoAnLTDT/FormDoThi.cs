using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTDT
{
    public partial class FormDoThi : Form
    {

        //Phần tạo nút frontend
        private Button currentButton;
        private Random random;
        private int tempIndex;

        //Phần tạo các biến thực hiện
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
        // them mau de ve duong`
        public Color[] a = // lấy màu để vẽ kết quả của đồ thị liên thông
{
            Color.FromArgb(51, 255, 200),// màu xanh biển
            Color.FromArgb(255, 165, 0), // màu cam
            Color.FromArgb(20, 253, 30), // xanh lá
            Color.FromArgb(106, 90, 205), // màu tím 
            Color.FromArgb(108, 25, 5),// màu đỏ đậm
            Color.FromArgb(255, 153, 153), // màu hồng
            Color.FromArgb(200,11,14),// mau do
            Color.FromArgb(244,208,63),// mau vang
        };

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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
            VeDoThi(Edges);
            Edges = new Class_Graph.Edge();
            Nod = new Class_Graph.NodeGraph();
            btncreate = null;
            dx = dy = dx1 = dy1 = 0;
            dinh1 = dinh2 = -1;
        }

        private void btnXoaCanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (ListarrEdge.Count == 0)
            {
                MessageBox.Show("Không còn cạnh nào để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nod = new Class_Graph.NodeGraph();
                Edges = new Class_Graph.Edge();
                btncreate = null;
                dx = dy = dx1 = dy1 = 0;
                dinh1 = dinh2 = -1;
                return;
            }
            if (btncreate == null)
            {
                MessageBox.Show("Bạn chưa chọn cạnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            int n = ListarrEdge.Count;
            for (int i = 0; i < ListarrEdge.Count; i++)
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
                {

                    if (!ListarrEdge[i].SoSanhEdgeVH(Edges))
                    {
                        VeLaiDoThi(ListarrEdge[i]);
                    }
                    else
                    {
                        ListarrEdge.RemoveAt(i);
                        i = i - 1;
                        Matrix[dinh1, dinh2] = 0;
                        Matrix[dinh2, dinh1] = 0;
                        /*d1 = d2 = -1;*/
                    }
                }
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {

                    if (!ListarrEdge[i].SoSanhEdgeCH(Edges))
                    {
                        VeLaiDoThi(ListarrEdge[i]);
                    }
                    else
                    {
                        ListarrEdge.RemoveAt(i);
                        i = i - 1;
                        Matrix[dinh1, dinh2] = 0;
                    }
                }

            }
            if (ListarrEdge.Count > 0)
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng" && (n == ListarrEdge.Count))
                {
                    MessageBox.Show("Không tồn tại đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng" && n == ListarrEdge.Count)
                {
                    MessageBox.Show("Không tồn tại đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            Edges = new Class_Graph.Edge();
            Nod = new Class_Graph.NodeGraph();
            btncreate = null;
            dx = dy = dx1 = dy1 = 0;
            dinh1 = dinh2 = -1;
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
        #region Method vẽ đồ thị
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
        #region 3.Vẽ lại đồ thị sau khi xoá cạnh
        private void VeLaiDoThi(Class_Graph.Edge NodeG)
        {
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen BlackPen = new Pen(Color.Black, 2);
                dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen BlackPen = new Pen(Color.Black, 2);
                    dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                }

            }
        }


        #endregion
        #region 4. Vẽ Đường Đi Kết Quả BFS hay DFS
        private void VeDoThiDuongDi(Class_Graph.Edge NodeG)
        {
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen BlackPen = new Pen(Color.Red, 2);
                dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Pen BlackPen = new Pen(Color.Red, 2);
                    dc.DrawLine(BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, BlackPen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
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
        #region 6. Tạo ma trận có hướng
        private void TaolaiMaTranCH()
        {
            Matrix = new int[100, 100];
            for (int i = 0; i < ListarrEdge.Count; i++) // List danh sách các cạnh
            {
                Class_Graph.Edge Eg = ListarrEdge[i];
                for (int j = 0; j < ListarrNod.Count; j++) // list danh sách các node
                {
                    for (int l = 0; l < ListarrNod.Count; l++) // list danh sách các node
                    {
                        Class_Graph.NodeGraph Nod1 = new Class_Graph.NodeGraph();
                        Nod1.x = ListarrNod[j].x + 12;
                        Nod1.y = ListarrNod[j].y + 12;
                        Class_Graph.NodeGraph Nod2 = new Class_Graph.NodeGraph();
                        Nod2.x = ListarrNod[l].x + 12;
                        Nod2.y = ListarrNod[l].y + 12;
                        if (Eg.CheckMatrixCH(Nod1, Nod2))
                        {
                            Matrix[j, l] = 1;
                        }
                    }
                }
            }
        }
        #endregion
        #region 7. Tạo ma trận vô hướng
        private void TaolaiMaTranVH()
        {
            Matrix = new int[100, 100];
            for (int i = 0; i < ListarrEdge.Count; i++)
            {
                Class_Graph.Edge Eg = ListarrEdge[i];
                for (int j = 0; j < ListarrNod.Count; j++)
                {
                    for (int l = j + 1; l < ListarrNod.Count; l++)
                    {
                        Class_Graph.NodeGraph Nod1 = new Class_Graph.NodeGraph();
                        Nod1.x = ListarrNod[j].x + 12;
                        Nod1.y = ListarrNod[j].y + 12;
                        Class_Graph.NodeGraph Nod2 = new Class_Graph.NodeGraph();
                        Nod2.x = ListarrNod[l].x + 12;
                        Nod2.y = ListarrNod[l].y + 12;
                        if (Eg.CheckMatrixVH(Nod1, Nod2))
                        {
                            Matrix[j, l] = 1;
                            Matrix[l, j] = 1;
                        }
                    }
                }
            }
        }
        #endregion
        #region 8. Xét Sụ Thay Đổi Đồ Thị Mà Vẽ Lại Ma Trận Và Đồ Thị
        private void cbxLoaiDoThi_TextChanged(object sender, EventArgs e)
        {
            if (cbxLoaiDoThi.Text == string.Empty)
            {
                btnThemCanh.Enabled = false;
            }
            else
            {
                btnThemCanh.Enabled = true;
            }
            txtKetqua.Text = "Kết Quả";
            ResetDT();
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                TaolaiMaTranVH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Class_Graph.Edge> { };
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
            {
                TaolaiMaTranCH();
                string Mtran = string.Empty;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Class_Graph.Edge> { };
            }
        }
        #endregion
        #region 9. Reset Do thi
        // Vẽ lại đồ thị các cạnh thành màu đen dựa vào mảng cạnh, vẽ từng cạnh lại
        private void ResetDT()
        {
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            for (int i = 0; i < ListarrEdge.Count; i++)
            {
                VeLaiDoThi(ListarrEdge[i]);
            }
            foreach (Button btn in pnlVeDoThi.Controls.OfType<Button>())
            {
                btn.BackColor = Color.YellowGreen;
            }
        }
        #endregion
        #region 10. Vẽ liên thông
        private void VeDoThiLT(Class_Graph.Edge NodeG, Pen pen)
        {
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                Graphics dc = pnlVeDoThi.CreateGraphics();
                dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                dc.DrawLine(pen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
            }
            else
            {
                if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
                {
                    Graphics dc = pnlVeDoThi.CreateGraphics();
                    dc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    dc.DrawLine(pen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                    DrawArrowhead(dc, pen, NodeG.x, NodeG.y, NodeG.z, NodeG.t);
                }
            }
        }
        #endregion
        #region 11. Vẽ Thành Phần Liên Thông
        private void VeTPLT(Pen s)
        {
            for (int i = 0; i < ListarrEdge.Count; i++)
            {
                for (int j = 0; j < LNodLT.Count; j++)
                {
                    if (LNodLT[j].SoSanhNodeVH(ListarrEdge[i]))
                    {
                        VeDoThiLT(ListarrEdge[i], s);
                    }
                }
            }

        }
        #endregion
        #endregion

        #region Các phương pháp duyệt và trả kết quả
        #region 1. Duyệt theo chức năng người dùng chọn
        private void DuyetGraph()
        {
            if (cbxChucNang.Text == "Duyệt BFS" && Int32.TryParse(cbxDinhBatDau.Text, out PtuxoaNod) && Int32.TryParse(cbxDinhKetThuc.Text, out PtuxoaNod))
            {
                Dothi.duyetBFS(Convert.ToInt32(cbxDinhBatDau.Text), Convert.ToInt32(cbxDinhKetThuc.Text));
            }
            else if (cbxChucNang.Text == "Duyệt DFS" && Int32.TryParse(cbxDinhBatDau.Text, out PtuxoaNod) && Int32.TryParse(cbxDinhKetThuc.Text, out PtuxoaNod))
            {
                Dothi.duyetDFS(Convert.ToInt32(cbxDinhBatDau.Text), Convert.ToInt32(cbxDinhKetThuc.Text));
            }
            else if (cbxChucNang.Text == "Xét Liên Thông")
            {
                TPLT = Dothi.thanhPhanLienThong();  //  2       [0 1]       [2 3]

            }
        }
        #endregion
        #region 2. Lấy đường đi bfs
        private void getDD_BFS()
        {
            for (int i = Dothi.kqBFS.Count() - 1; i > 0; i--)
            {
                Eg.x = ListarrNod[Dothi.kqBFS[i]].x + 12;
                Eg.y = ListarrNod[Dothi.kqBFS[i]].y + 12;
                Eg.z = ListarrNod[Dothi.kqBFS[i - 1]].x + 12;
                Eg.t = ListarrNod[Dothi.kqBFS[i - 1]].y + 12;
                Egl.Add(Eg);
                Eg = new Class_Graph.Edge();
            }
        }
        #endregion
        #region 3. Lấy các đỉnh liên thông

        private void getDDLT(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                NodLT.x = ListarrNod[(int)(a[i] - '0')].x + 12;
                NodLT.y = ListarrNod[(int)a[i] - '0'].y + 12;
                LNodLT.Add(NodLT);
                NodLT = new Class_Graph.NodeGraph();
            }
        }
        #endregion
        #region 4. Đánh dấu đường BFS hoặc DFS
        private void DanhDauDuongDiTB()
        {
            pnlVeDoThi.Invalidate();
            pnlVeDoThi.Refresh();
            for (int i = 0; i < ListarrEdge.Count; i++)// 
            {
                VeLaiDoThi(ListarrEdge[i]);
            }
            for (int j = 0; j < Egl.Count; j++)
            {
                VeDoThiDuongDi(Egl[j]);// luu cac canh ket qua DFS hay BFS 
            }
        }
        #endregion
        #region 5. Duyệt BFS
        private void getDD_DFS()
        {
            for (int i = Dothi.kqDFS.Count() - 1; i > 0; i--)
            {
                Eg.x = ListarrNod[Dothi.kqDFS[i]].x + 12;
                Eg.y = ListarrNod[Dothi.kqDFS[i]].y + 12;
                Eg.z = ListarrNod[Dothi.kqDFS[i - 1]].x + 12;
                Eg.t = ListarrNod[Dothi.kqDFS[i - 1]].y + 12;
                Egl.Add(Eg);
                Eg = new Class_Graph.Edge();
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            dx = dy = dx1 = dy1 = 0;
            dinh1 = dinh2 = -1;
            Nod = new Class_Graph.NodeGraph();
            Edges = new Class_Graph.Edge();
            btncreate = null;
            if (cbxLoaiDoThi.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn loại đồ thị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxChucNang.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn chức năng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((cbxChucNang.Text == "Duyệt BFS" || cbxChucNang.Text == "Duyệt DFS") && (cbxDinhBatDau.Text == string.Empty || cbxDinhKetThuc.Text == String.Empty))
            {
                MessageBox.Show("Bạn chưa nhập đỉnh bắt đầu hoặc đỉnh kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
            {
                TaolaiMaTranVH();
                string Mtran = string.Empty;
                Mtran += sodinh.ToString() + Environment.NewLine;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Class_Graph.Edge> { };
                ResetDT();
            }
            if (cbxLoaiDoThi.Text == "Đồ Thị Có Hướng")
            {
                TaolaiMaTranCH();
                string Mtran = string.Empty;
                Mtran += sodinh.ToString() + Environment.NewLine;
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    for (int j = 0; j < ListarrNod.Count; j++)
                    {
                        Mtran += Matrix[i, j] + " ";
                    }
                    Mtran += Environment.NewLine;
                }
                txtMatran.Text = Mtran;
                Egl = new List<Class_Graph.Edge> { };
                ResetDT();
            }
            socanh = ListarrEdge.Count;
            sodinhcheck = ListarrNod.Count;
            Dothi.kqDFS.Clear();
            Dothi.kqBFS.Clear();
            btncreate = null;
            Dothi.readGRAPH(Matrix, sodinh);
            DuyetGraph(); // gọi lại
            i = Dothi.kqDFS.Count() - 1;
            dx = dy = dx1 = dy1 = 0;
            Dinh1 = Dinh2 = -1;
            dinh1 = dinh2 = -1;
            Nod = new Class_Graph.NodeGraph();
            Edges = new Class_Graph.Edge();
            if (ListarrNod.Count == 0) // && Xacnhan)
            {
                MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbxChucNang.Text == "Duyệt BFS" && cbxDinhKetThuc.Text != string.Empty && cbxDinhBatDau.Text != string.Empty)
            {
                if (Dothi.kqBFS.Count() == 0)
                {
                    MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string Ketqua = "";
                    for (int i = Dothi.kqBFS.Count() - 1; i >= 0; i--)
                    {
                        if (i != 0) // de khong xuat hien cai --> o phia cuoi
                        {
                            Ketqua += Dothi.kqBFS[i].ToString() + " --> ";
                        }
                        else
                        {
                            Ketqua += Dothi.kqBFS[i].ToString();
                        }
                    }
                    txtKetqua.Text = Ketqua;
                    getDD_BFS();
                    DanhDauDuongDiTB();
                    foreach (Button btn in pnlVeDoThi.Controls.OfType<Button>())
                    {
                        for (int i = 0; i < Dothi.kqBFS.Count; i++)
                            if (btn.Text == Dothi.kqBFS[i].ToString())
                            {
                                btn.BackColor = Color.Brown;
                            }
                    }
                    return;
                }

            }
            if (cbxChucNang.Text == "Duyệt DFS" && cbxDinhKetThuc.Text != string.Empty && cbxDinhBatDau.Text != string.Empty)
            {
                if (Dothi.kqDFS.Count() == 0)
                {
                    MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string trave = "";
                    for (int i = Dothi.kqDFS.Count() - 1; i >= 0; i--)
                    {
                        if (i != 0)
                        {
                            trave += Dothi.kqDFS[i].ToString() + " --> ";
                        }
                        else
                        {
                            trave += Dothi.kqDFS[i].ToString();
                        }
                    }
                    txtKetqua.Text = trave;
                    getDD_DFS();
                    DanhDauDuongDiTB();
                    foreach (Button btn in pnlVeDoThi.Controls.OfType<Button>())
                    {
                        for (int i = 0; i < Dothi.kqDFS.Count; i++)
                            if (btn.Text == Dothi.kqDFS[i].ToString())
                            {
                                btn.BackColor = Color.Brown;
                            }
                    }
                    return;
                }
            }
            if (cbxChucNang.Text == "Xét Liên Thông")
            {
                string showLT = string.Empty;
                if (TPLT[0] == "0")
                {
                    MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TPLT[0] == "1")
                {
                    for (int i = 1; i < TPLT.Length; i++)
                    {
                        showLT += "Thành Phần Liên Thông Duy Nhất: " + TPLT[i] + Environment.NewLine;
                        showLT += "Đồ Thị Liên Thông" + Environment.NewLine;
                        foreach (Button btn in pnlVeDoThi.Controls.OfType<Button>())
                        {
                            btn.BackColor = Color.Brown;
                        }
                        string arrListStr = TPLT[i].Replace(" ", "");
                        getDDLT(arrListStr);
                        Pen pen;
                        pen = new Pen(Color.Red, 2);
                        VeTPLT(pen);
                    }
                    txtKetqua.Text = showLT;
                    return;
                }
                else
                {
                    for (int i = 0; i < TPLT.Length; i++)
                    {
                        if (i == 0)
                        {
                            showLT += "Số Thành Phần Liên Thông: " + TPLT[0] + Environment.NewLine;
                        }
                        else
                        {
                            showLT += "Thành Phần Liên Thông Thứ " + i.ToString() + ": " + TPLT[i] + Environment.NewLine;
                            string arrListStr = TPLT[i].Replace(" ", "");
                            getDDLT(arrListStr); // lay cac dinh node phia trong do thi
                            Pen pen;
                            pen = new Pen(a[i - 1], 2);
                            VeTPLT(pen);
                            pen = null;
                            LNodLT = new List<Class_Graph.NodeGraph> { };
                        }
                    }
                    showLT += "Đồ Thị Không Liên Thông" + Environment.NewLine;
                    txtKetqua.Text = showLT;
                    for (int i = 1; i <= TPLT.Length; i++)
                    {
                        // xét tất cả các đỉnh, nếu có nhãn trùng với nMienLienThong, in ra
                        for (int j = 0; j < this.sodinh; j++)
                        {
                            if (Dothi.visited[j] == i)
                            {
                                foreach (Button btn in pnlVeDoThi.Controls.OfType<Button>())
                                {
                                    if (btn.Text == j.ToString())
                                    {
                                        btn.BackColor = a[i - 1];
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (txtMatran.Text == string.Empty || txtKetqua.Text == string.Empty || cbxLoaiDoThi.Text == String.Empty || cbxChucNang.Text == String.Empty)
            {
                MessageBox.Show("Bạn chưa tạo đồ thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Text Document File (*.txt)|*.txt|All File (*.*)|*.*" })
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string Mtran = string.Empty;
                        for (int i = 0; i < ListarrNod.Count; i++)
                        {
                            for (int j = 0; j < ListarrNod.Count; j++)
                            {
                                Mtran += Matrix[i, j] + " ";
                            }
                            Mtran += Environment.NewLine;
                        }
                        StreamWriter stream = new StreamWriter(saveFileDialog.FileName);
                        stream.WriteLine(sodinh.ToString());
                        stream.WriteLine(Mtran);
                        stream.Close();
                        MessageBox.Show("Bạn đã lưu File thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Show();
            this.Hide();
        }
        #endregion
        #endregion


        #region Load combo đỉnh bắt đầu và kết thúc
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

        #region Biến check tồn tại cho method vẽ đồ thị
        private bool check(int x, int y) // Dùng kiểm tra 
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
        #endregion


        private void btnDoThiMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDoThiClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbxChucNang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            btnDuyet.Text = cbxChucNang.Text;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnXoaDinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (ListarrNod.Count == 0)
            {
                MessageBox.Show("Không còn đỉnh để xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nod = new Class_Graph.NodeGraph();
                Edges = new Class_Graph.Edge();
                // làm mới dữ liệu
                btncreate = null;
                dx = dy = dx1 = dy1 = 0;
                dinh1 = dinh2 = -1;
                return;
            }
            if (btncreate != null)
            {
                int n = 0;
                int sonut = ListarrNod.Count();
                Nod.x = btncreate.Location.X;
                Nod.y = btncreate.Location.Y;
                Class_Graph.NodeGraph NodEdge = new Class_Graph.NodeGraph();
                NodEdge.x = btncreate.Location.X + 12;
                NodEdge.y = btncreate.Location.Y + 12;
                btncreate.BackColor = Color.YellowGreen;
                btncreate.ForeColor = Color.White;
                pnlVeDoThi.Controls.Clear(); // xóa hết tất cả panel
                pnlVeDoThi.Invalidate();
                pnlVeDoThi.Refresh();
                for (int i = 0; i < ListarrEdge.Count; i++)
                {
                    if (!NodEdge.SoSanhNodeVH(ListarrEdge[i])) // kiểm tra xem cạnh có phải là có hướng
                    {
                        VeLaiDoThi(ListarrEdge[i]); // vẽ lại tất cả các cạnh
                    }
                    else
                    {
                        ListarrEdge.RemoveAt(i); // xóa tất cả các cạnh có nối với đỉnh 
                        i = i - 1;
                    }
                }
                for (int i = 0; i < ListarrNod.Count; i++)
                {
                    if (!Nod.SoSanhNode(ListarrNod[i]))
                    {
                        Button btn = new Button();
                        btn.Width = 25;
                        btn.Height = 25;
                        btn.BackColor = Color.YellowGreen;
                        btn.ForeColor = Color.White;
                        btn.Location = new Point(ListarrNod[i].x, ListarrNod[i].y);
                        btn.Text = string.Format("{0}", n++);
                        btn.Click += new EventHandler(getToaDo);
                        pnlVeDoThi.Controls.Add(btn);
                    }
                    else
                    {
                        PtuxoaNod = i;
                    }
                }
                if (PtuxoaNod != -1 && ListarrNod.Count > 0)
                {
                    ListarrNod.RemoveAt(PtuxoaNod);
                    Nod = new Class_Graph.NodeGraph();
                    Edges = new Class_Graph.Edge();
                    btncreate = null;
                    dx = dy = dx1 = dy1 = 0;
                    dinh1 = dinh2 = -1;
                }
                if (sonut > ListarrNod.Count() && cbxLoaiDoThi.Text == "Đồ Thị Có Hướng") // sonut lớn hơn số nút hiện có chứng tỏ ma trận chưa được tạo
                {
                    TaolaiMaTranCH();
                }
                if (sonut > ListarrNod.Count() && cbxLoaiDoThi.Text == "Đồ Thị Vô Hướng")
                {
                    TaolaiMaTranVH();
                }
                sodinh = ListarrNod.Count; // so dinh
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn đỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Nod = new Class_Graph.NodeGraph();
            Edges = new Class_Graph.Edge();
            LoadComBoBoxDinhBatDau();
            LoadComBoBoxDinhKetThuc();
            btncreate = null;
            dx = dy = dx1 = dy1 = 0;
            dinh1 = dinh2 = -1;
        }

       

        

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DialogResult res = MessageBox.Show("Bạn muốn Reset đồ thị", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                cbxChucNang.SelectedIndex = -1;
                cbxLoaiDoThi.SelectedIndex = -1;
                pnlVeDoThi.Controls.Clear();
                pnlVeDoThi.Invalidate();
                pnlVeDoThi.Refresh();
                cbxDinhKetThuc.DataSource = null;
                cbxDinhBatDau.DataSource = null;
                txtKetqua.Text = "Kết Quả";
                btncreate = new Button();
                dx = 0; dy = 0; dx1 = 0; dy1 = 0;
                dinh1 = -1; dinh2 = -1;
                Dinh1 = -1; Dinh2 = -1;
                Class_Graph.Edge Edges = new Class_Graph.Edge();
                ListarrEdge = new List<Class_Graph.Edge> { };
                Class_Graph.NodeGraph Nod = new Class_Graph.NodeGraph();
                ListarrNod = new List<Class_Graph.NodeGraph> { };
                PtuxoaNod = -1;
                sodinh = 0;
                Matrix = new int[100, 100];
                DoAnLTDT.Class_Graph.Graph Dothi = new Class_Graph.Graph();
                Dothi.kqBFS.Clear();
                Dothi.kqDFS.Clear();
                TPLT = new string[] { };
                i = 0;
                btnDuyet.Text = "Duyệt";
                txtMatran.Text = "Ma Trận";
            }
        }

        private void FormDoThi_Load(object sender, EventArgs e)
        {

        }
        
    }
}
