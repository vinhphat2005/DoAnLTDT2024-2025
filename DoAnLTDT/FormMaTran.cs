using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTDT
{
    public partial class FormMaTran : Form
    {
        //Tạo nút
        private Button currentButton;
        private Random random;
        private int tempIndex;

        int[,] savematrix = new int[100, 100];
        Point[] point_Dinh = new Point[100];
        public int n_Point_Dinh = 0;
        public int[,] maTran = new int[100, 100];
        String duong_Dan = "";
        Class_Graph.Graph Dothi = new Class_Graph.Graph();
        string[] TPLT = new string[] { };
        AdjustableArrowCap arrowSize = new AdjustableArrowCap(7, 7);
        //--------------  
        private List<Class_Graph.NodeGraph> ListarrNod = new List<Class_Graph.NodeGraph> { };
        public int[,] Matrix = new int[100, 100];

        public FormMaTran()
        {
            InitializeComponent();
            random = new Random();
        }
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
            foreach (Control previousBtn in panelMaTranMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void btnMaTranClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaTranMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu FormMenu đã mở
            Form existingForm = Application.OpenForms["FormMenu"];
            if (existingForm != null)
            {
                existingForm.Show();
            }
            else
            {
                FormMenu menu = new FormMenu();
                menu.Show();
            }
            this.Close(); // Đóng form hiện tại để giải phóng tài nguyên
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                duong_Dan = open.FileName;
                txtDuongDan.Text = duong_Dan;
                StreamReader read = new StreamReader(open.FileName);
                txtMaTran.Text = read.ReadToEnd();
                read.Close();
            }
        }


        #region Các hàm kiểm tra
        #region Kiểm tra đồ thị vô hướng
        bool kiem_Tra_Do_Thi_Vo_Huong()
        {
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (maTran[i, j] != maTran[j, i]) return false;
                }
            }
            return true;
        }
        #endregion
        #region Kiểm tra tính hợp lệ
        bool kiem_Tra_Tinh_Hop_Le_Cua_Ma_Tran()
        {
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                if (maTran[i, i] != 0) return false;
            }
            return true;
        }
        #endregion
        #region Kiểm tra khoảng cách
        bool kiem_Tra_Khoang_Cach(int x, int y)
        {
            int x_Vector = 0, y_Vector = 0;
            int khoang_Cach = 0;
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                x_Vector = Math.Abs(x - point_Dinh[i].X);
                y_Vector = Math.Abs(y - point_Dinh[i].Y);
                khoang_Cach = (int)Math.Sqrt(Math.Pow(x_Vector, 2) + Math.Pow(y_Vector, 2));
                if (khoang_Cach < 50) return false;
            }
            return true;
        }
        #endregion
        #region Kiểm tra khoảng cách đỉnh
        bool KTKhoangCachDinh(int x, int y)
        {
            for (int i = 0; i < n_Point_Dinh; i++)
            {
                float kc = (float)(Math.Sqrt(Math.Pow(x - point_Dinh[i].X, 2) + Math.Pow(y - point_Dinh[i].Y, 2)));
                if (kc < 40) return true;
            }
            return false;
        }
        #endregion
        #region Tải dữ liệu lên cmbBox
        private void LoadComBoBoxDinhBatDau()
        {
            int[] ArrVertex = new int[n_Point_Dinh];
            for (int i = 0; i < n_Point_Dinh; i++)
            {
                ArrVertex[i] = i;
            }
            cbxDinhBatDau.DataSource = ArrVertex;
        }
        private void LoadComBoBoxDinhKetThuc()
        {
            int[] ArrVertex = new int[n_Point_Dinh];
            for (int i = 0; i < n_Point_Dinh; i++)
            {
                ArrVertex[i] = i;
            }
            cbxDinhKetThuc.DataSource = ArrVertex;
        }
        #endregion
        #endregion

        #region Chuyển đổi Có hướng -> Vô hướng
        private void ChuyenDoiCHSangVH()
        {
            for (int i = 0; i < n_Point_Dinh; i++)
            {
                for (int j = 0; j < n_Point_Dinh; j++)
                {
                    if (maTran[i, j] != 0)
                    {
                        savematrix[j, i] = savematrix[i, j] = 1;
                    }
                }
            }
        }
        #endregion


        #region Bảng và các chức năng xoay quanh bảng
        private void pbBang_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush MauTrang = new SolidBrush(Color.White);
            SolidBrush MauDen = new SolidBrush(Color.Black);
            SolidBrush MauDo = new SolidBrush(Color.Red);
            SolidBrush[] arr_Br = { new SolidBrush(Color.Aqua), new SolidBrush(Color.Orange), new SolidBrush(Color.Green), new SolidBrush(Color.Purple), new SolidBrush(Color.DarkRed), new SolidBrush(Color.Pink), new SolidBrush(Color.Red), new SolidBrush(Color.Yellow) };
            Pen[] arr_Pen = { new Pen(Color.Aqua, 2), new Pen(Color.Orange, 2), new Pen(Color.Green, 2), new Pen(Color.Purple, 2), new Pen(Color.DarkRed, 2), new Pen(Color.Pink, 2), new Pen(Color.Red, 2), new Pen(Color.Yellow, 2) };
            Pen pen_Black = new Pen(Color.Black, 2);
            Pen pen_Red = new Pen(Color.Red, 2);
            lbDSCanh.Items.Clear();

            #region Vẽ đồ thị
            // danh sách cạnh
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (maTran[i, j] != 0)
                    {
                        if (kiem_Tra_Do_Thi_Vo_Huong() && j > i)
                        {
                            g.DrawLine(pen_Black, point_Dinh[i], point_Dinh[j]);
                            lbDSCanh.Items.Add(i.ToString() + "-" + j.ToString());
                        }
                    }
                    if (maTran[i, j] != 0)
                    {
                        if (!kiem_Tra_Do_Thi_Vo_Huong())
                        {
                            g.DrawLine(pen_Black, point_Dinh[i], point_Dinh[j]);
                            pen_Black.EndCap = LineCap.ArrowAnchor;
                            pen_Black.CustomEndCap = arrowSize;
                            lbDSCanh.Items.Add(i.ToString() + "-" + j.ToString());
                        }
                        g.DrawLine(pen_Black, point_Dinh[i], point_Dinh[j]);
                    }
                }
            }
            lbDSDinh.Items.Clear();
            // danh sách đỉnh
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                g.FillEllipse(MauDo, point_Dinh[i].X - 10, point_Dinh[i].Y - 10, 20, 20);
                g.DrawString((i).ToString(), Font, MauTrang, point_Dinh[i].X - 5, point_Dinh[i].Y - 5);
                lbDSDinh.Items.Add("Đỉnh: " + i.ToString());
            }
            // làm lại ma trận
            txtMaTran.Text = n_Point_Dinh.ToString() + "\r\n";
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j != 0) txtMaTran.Text += " ";
                    txtMaTran.Text += maTran[i, j].ToString();
                }
                if (i != n_Point_Dinh - 1) txtMaTran.Text += "\r\n";
            }
            #endregion
            #region TPLT   
            if (Dothi.nTPLT != 0)
            {
                if (kiem_Tra_Do_Thi_Vo_Huong())
                {
                    for (int i = 1; i <= Dothi.nTPLT; ++i)
                    {
                        int dem = 0;
                        for (int j = 0; j < Dothi.sodinh; ++j)
                        {
                            if (Dothi.visited[j] == i)
                            {

                                if (dem == 0)// trường hợp thành phần liên thông có 1 đỉnh
                                {
                                   
                                    dem = 1;
                                    g.FillEllipse(arr_Br[i - 1], point_Dinh[j].X - 10, point_Dinh[j].Y - 10, 20, 20);
                                    g.DrawString((j).ToString(), Font, MauTrang, point_Dinh[j].X - 5, point_Dinh[j].Y - 5);
                                }
                                else if (dem == 1)
                                {
                                    for (int ii = 0; ii < n_Point_Dinh; ++ii)
                                    {
                                        if (maTran[j, ii] != 0)
                                        {
                                            g.DrawLine(arr_Pen[i - 1], point_Dinh[ii], point_Dinh[j]);
                                            g.FillEllipse(arr_Br[i - 1], point_Dinh[ii].X - 10, point_Dinh[ii].Y - 10, 20, 20);
                                            g.FillEllipse(arr_Br[i - 1], point_Dinh[j].X - 10, point_Dinh[j].Y - 10, 20, 20);
                                     
                                            g.DrawString((ii).ToString(), Font, MauTrang, point_Dinh[ii].X - 5, point_Dinh[ii].Y - 5);
                                            g.DrawString((j).ToString(), Font, MauTrang, point_Dinh[j].X - 5, point_Dinh[j].Y - 5);
                                          
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    ChuyenDoiCHSangVH();
                    for (int i = 1; i <= Dothi.nTPLT; ++i)
                    {
                        int dem = 0;
                        for (int j = 0; j < n_Point_Dinh; ++j)
                        {
                            if (Dothi.visited[j] == i)
                            {
                                if (dem == 0)// trường hợp thành phần liên thông có 1 đỉnh
                                {
                                    
                                    dem = 1;
                                    g.FillEllipse(arr_Br[i - 1], point_Dinh[j].X - 10, point_Dinh[j].Y - 10, 20, 20);
                                    g.DrawString((j).ToString(), Font, MauTrang, point_Dinh[j].X - 5, point_Dinh[j].Y - 5);
                                    AdjustableArrowCap arrowSize = new AdjustableArrowCap(5, 5);// ve do thi co huong
                                    arr_Pen[i - 1].EndCap = LineCap.ArrowAnchor;
                                    arr_Pen[i - 1].CustomEndCap = arrowSize;
                                }
                                else if (dem == 1)
                                {
                                    for (int ii = 0; ii < n_Point_Dinh; ++ii)
                                    {
                                        arr_Pen[i - 1].EndCap = LineCap.ArrowAnchor;
                                        arr_Pen[i - 1].CustomEndCap = arrowSize;
                                        if (savematrix[j, ii] != 0)
                                        {


                                            g.DrawLine(arr_Pen[i - 1], point_Dinh[ii], point_Dinh[j]);
                                            g.FillEllipse(arr_Br[i - 1], point_Dinh[ii].X - 10, point_Dinh[ii].Y - 10, 20, 20);
                                            g.FillEllipse(arr_Br[i - 1], point_Dinh[j].X - 10, point_Dinh[j].Y - 10, 20, 20);
                                            g.DrawString((ii).ToString(), Font, MauTrang, point_Dinh[ii].X - 5, point_Dinh[ii].Y - 5);
                                            g.DrawString((j).ToString(), Font, MauTrang, point_Dinh[j].X - 5, point_Dinh[j].Y - 5);

                                        }
                                    }
                                }
                            }
                        }

                    }
                    Dothi.nTPLT = 0;
                }
            }
            #endregion
            #region DFS
            if (Dothi.kqDFS.Count() != 0)
            {
                if (kiem_Tra_Do_Thi_Vo_Huong())
                {
                    int demm = 1;// 
                    for (int i = 0; i < Dothi.kqDFS.Count(); ++i)
                    {
                        if (demm == 1)
                        {
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqDFS[i]].X - 10, point_Dinh[Dothi.kqDFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqDFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqDFS[i]].X - 5, point_Dinh[Dothi.kqDFS[i]].Y - 5);
                            demm = 2;
                        }
                        else
                        {
                            g.DrawLine(pen_Red, point_Dinh[Dothi.kqDFS[i - 1]], point_Dinh[Dothi.kqDFS[i]]);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqDFS[i - 1]].X - 10, point_Dinh[Dothi.kqDFS[i - 1]].Y - 10, 20, 20);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqDFS[i]].X - 10, point_Dinh[Dothi.kqDFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqDFS[i - 1]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqDFS[i - 1]].X - 5, point_Dinh[Dothi.kqDFS[i - 1]].Y - 5);
                            g.DrawString((Dothi.kqDFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqDFS[i]].X - 5, point_Dinh[Dothi.kqDFS[i]].Y - 5);
                        }
                    }
                    Dothi.kqDFS.Clear();
                    pbBang.Refresh();
                }
                else
                {
                    int demm = 1;// 
                    for (int i = 0; i < Dothi.kqDFS.Count(); ++i)
                    {
                        if (demm == 1)
                        {
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqDFS[i]].X - 10, point_Dinh[Dothi.kqDFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqDFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqDFS[i]].X - 5, point_Dinh[Dothi.kqDFS[i]].Y - 5);
                            demm = 2;
                        }
                        else
                        {
                            pen_Red.StartCap = LineCap.ArrowAnchor;
                            pen_Red.CustomStartCap = arrowSize;
                            g.DrawLine(pen_Red, point_Dinh[Dothi.kqDFS[i - 1]], point_Dinh[Dothi.kqDFS[i]]);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqDFS[i - 1]].X - 10, point_Dinh[Dothi.kqDFS[i - 1]].Y - 10, 20, 20);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqDFS[i]].X - 10, point_Dinh[Dothi.kqDFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqDFS[i - 1]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqDFS[i - 1]].X - 5, point_Dinh[Dothi.kqDFS[i - 1]].Y - 5);
                            g.DrawString((Dothi.kqDFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqDFS[i]].X - 5, point_Dinh[Dothi.kqDFS[i]].Y - 5);
                        }
                    }
                    Dothi.kqDFS.Clear();
                    pbBang.Refresh();

                }
            }
            #endregion
            #region BFS
            if (Dothi.kqBFS.Count() != 0)
            {
                if (kiem_Tra_Do_Thi_Vo_Huong())
                {
                    int demm = 1;
                    for (int i = 0; i < Dothi.kqBFS.Count(); ++i)
                    {
                        if (demm == 1)
                        {
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqBFS[i]].X - 10, point_Dinh[Dothi.kqBFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqBFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqBFS[i]].X - 5, point_Dinh[Dothi.kqBFS[i]].Y - 5);
                            demm = 2;
                        }
                        else
                        {
                            g.DrawLine(pen_Red, point_Dinh[Dothi.kqBFS[i - 1]], point_Dinh[Dothi.kqBFS[i]]);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqBFS[i - 1]].X - 10, point_Dinh[Dothi.kqBFS[i - 1]].Y - 10, 20, 20);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqBFS[i]].X - 10, point_Dinh[Dothi.kqBFS[i]].Y - 10, 20, 20);
                            //g.FillEllipse(MauTrang, (point_Dinh[a_bfs[i - 1]].X + point_Dinh[a_bfs[i]].X) / 2 - 10, (point_Dinh[a_bfs[i - 1]].Y + point_Dinh[a_bfs[i]].Y) / 2 - 10, 20, 20);
                            g.DrawString((Dothi.kqBFS[i - 1]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqBFS[i - 1]].X - 5, point_Dinh[Dothi.kqBFS[i - 1]].Y - 5);
                            g.DrawString((Dothi.kqBFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqBFS[i]].X - 5, point_Dinh[Dothi.kqBFS[i]].Y - 5);
                            //g.DrawString(maTran[a_bfs[i - 1], a_bfs[i]].ToString(), Font, MauDen, (point_Dinh[a_bfs[i - 1]].X + point_Dinh[a_bfs[i]].X) / 2 - 5, (point_Dinh[a_bfs[i - 1]].Y + point_Dinh[a_bfs[i]].Y) / 2 - 5);

                        }
                    }
                    Dothi.kqBFS.Clear();
                    pbBang.Refresh();
                }
                else
                {
                    int demm = 1;// 
                    for (int i = 0; i < Dothi.kqBFS.Count(); ++i)
                    {
                        if (demm == 1)
                        {
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqBFS[i]].X - 10, point_Dinh[Dothi.kqBFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqBFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqBFS[i]].X - 5, point_Dinh[Dothi.kqBFS[i]].Y - 5);
                            demm = 2;
                        }
                        else
                        {
                            pen_Red.StartCap = LineCap.ArrowAnchor;
                            pen_Red.CustomStartCap = arrowSize;
                            g.DrawLine(pen_Red, point_Dinh[Dothi.kqBFS[i - 1]], point_Dinh[Dothi.kqBFS[i]]);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqBFS[i - 1]].X - 10, point_Dinh[Dothi.kqBFS[i - 1]].Y - 10, 20, 20);
                            g.FillEllipse(MauDo, point_Dinh[Dothi.kqBFS[i]].X - 10, point_Dinh[Dothi.kqBFS[i]].Y - 10, 20, 20);
                            g.DrawString((Dothi.kqBFS[i - 1]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqBFS[i - 1]].X - 5, point_Dinh[Dothi.kqBFS[i - 1]].Y - 5);
                            g.DrawString((Dothi.kqBFS[i]).ToString(), Font, MauTrang, point_Dinh[Dothi.kqBFS[i]].X - 5, point_Dinh[Dothi.kqBFS[i]].Y - 5);
                        }
                    }
                    Dothi.kqBFS.Clear();
                    pbBang.Refresh();
                }
            }
            #endregion
        }
        #endregion

        #region Button VeDoThi
        private void btnVeDoThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Dothi.nTPLT = 0;
            n_Point_Dinh = 0;
            if (txtMaTran.Text != "0\r\n")
            {
                int temp = 0;
                // đọc File 
                if (duong_Dan != "")
                {
                    StreamReader read = new StreamReader(duong_Dan.Trim()); // mở file lên đọc
                    string dong = "";
                    dong = read.ReadLine();// đếm có bao nhiêu dòng
                    bool check_n = int.TryParse(dong, out temp);// đang lưu số đỉnh
                    string[] str = new string[100];
                    for (int i = 0; i < temp; ++i)// duyệt đỉnh
                    {
                        dong = read.ReadLine();
                        str = dong.Split(new char[] { ' ' });// tạo dòng 
                        for (int j = 0; j < temp; ++j)
                        {
                            int _temp = 0;
                            string s = str[j];// chuỗi s lưu số dưới dạng ký tự 
                            bool check = int.TryParse(s, out _temp);// lưu số vào trong biến _temp
                            if (check) maTran[i, j] = _temp;
                        }
                    }
                    read.Close();
                    duong_Dan = "";
                }
                else
                {
                    string dong = "";
                    dong = txtMaTran.Text;
                    bool check = int.TryParse(dong[0].ToString(), out temp);
                    check = false;
                    int k = 0;
                    string[] str = new string[100];
                    dong = "";
                    for (int i = 3; i < txtMaTran.Text.Length; ++i)
                    {
                        if (txtMaTran.Text[i] != '\r')
                        {
                            dong += txtMaTran.Text[i];
                        }
                        else
                        {
                            str = dong.Split(new char[] { ' ' });
                            for (int j = 0; j < temp; ++j)
                            {
                                check = int.TryParse(str[j], out maTran[k, j]);
                            }
                            ++i;
                            ++k;
                            dong = "";
                        }
                        #region Ghi Chu
                        //if (i == txtMaTran.Text.Length - 1)
                        //{
                        //    str = dong.Split(new char[] { ' ' });
                        //    for (int j = 0; j < temp; ++j)
                        //    {
                        //        check = int.TryParse(str[j], out maTran[k, j]);
                        //    }
                        //    ++i;
                        //    ++k;
                        //    dong = "";
                        //}
                        #endregion
                    }
                }
                n_Point_Dinh = temp;
                if (kiem_Tra_Tinh_Hop_Le_Cua_Ma_Tran() && kiem_Tra_Do_Thi_Vo_Huong())
                {
                    n_Point_Dinh = 0;
                    Random rd = new Random();
                    while (n_Point_Dinh < temp)
                    {
                        // 594, 510
                        point_Dinh[n_Point_Dinh].X = rd.Next(30, 480);
                        point_Dinh[n_Point_Dinh].Y = rd.Next(30, 420);
                        if (n_Point_Dinh != 0)
                        {
                            if (kiem_Tra_Khoang_Cach(point_Dinh[n_Point_Dinh].X, point_Dinh[n_Point_Dinh].Y) == false) continue;
                        }
                        ++n_Point_Dinh;
                    }
                    pbBang.Refresh();
                }
                else
                {
                    n_Point_Dinh = 0;
                    Random rd = new Random();
                    while (n_Point_Dinh < temp)
                    {
                        // 594, 510
                        point_Dinh[n_Point_Dinh].X = rd.Next(30, 480);
                        point_Dinh[n_Point_Dinh].Y = rd.Next(30, 420);
                        if (n_Point_Dinh != 0)
                        {
                            if (kiem_Tra_Khoang_Cach(point_Dinh[n_Point_Dinh].X, point_Dinh[n_Point_Dinh].Y) == false) continue;
                        }
                        ++n_Point_Dinh;
                    }
                    pbBang.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đọc File", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKetQua.Text = String.Empty;
            }
            LoadComBoBoxDinhBatDau();
            LoadComBoBoxDinhKetThuc();
            pbBang.Refresh();
        }
        #endregion

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (cbxChucNang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chức năng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Dothi.readGRAPH(maTran, n_Point_Dinh);
            if (btnDuyet.Text == "Xét Liên Thông")
            {
                TPLT = Dothi.thanhPhanLienThong();
                string showLT = string.Empty;
                if (TPLT[0] == "0")
                {
                    MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (TPLT[0] == "1")
                {
                    for (int i = 1; i < TPLT.Length; i++)
                    {
                        showLT += "Thành Phần Liên Thông Duy Nhất: " + TPLT[i] + Environment.NewLine;
                    }
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
                        }
                    }
                }
                if (Convert.ToInt32(TPLT[0]) == 1)
                {
                    showLT += "Đồ Thị Liên Thông" + Environment.NewLine;
                }
                else
                {
                    showLT += "Đồ Thị Không Liên Thông" + Environment.NewLine;
                }
                txtKetQua.Text = showLT;
                pbBang.Refresh();
            }
            else if (btnDuyet.Text == "Duyệt BFS")
            {
                if (txtMaTran.Text == "0\r\n")
                {
                    MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Dothi.duyetBFS(Convert.ToInt32(cbxDinhBatDau.Text), Convert.ToInt32(cbxDinhKetThuc.Text));
                    if (Dothi.kqBFS.Count() == 0)
                    {
                        MessageBox.Show("Không có đường đi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        string trave = "";
                        for (int i = Dothi.kqBFS.Count() - 1; i >= 0; i--)
                        {
                            if (i != 0)
                            {
                                trave += Dothi.kqBFS[i].ToString() + "-->";
                            }
                            else
                            {
                                trave += Dothi.kqBFS[i].ToString();
                            }
                        }
                        txtKetQua.Text = trave;
                        pbBang.Refresh();
                    }
                }
            }
            else if (btnDuyet.Text == "Duyệt DFS")
            {
                if (txtMaTran.Text == "0\r\n")
                {
                    MessageBox.Show("Bạn chưa vẽ đồ thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Dothi.duyetDFS(Convert.ToInt32(cbxDinhBatDau.Text), Convert.ToInt32(cbxDinhKetThuc.Text));
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
                                trave += Dothi.kqDFS[i].ToString() + "-->";
                            }
                            else
                            {
                                trave += Dothi.kqDFS[i].ToString();
                            }
                        }
                        txtKetQua.Text = trave;
                        pbBang.Refresh();
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DialogResult res = MessageBox.Show("Bạn chắc muốn làm mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                for (int i = 0; i < n_Point_Dinh; i++)
                {
                    for (int j = 0; j < n_Point_Dinh; j++)
                    {
                        maTran[i, j] = 0;
                    }
                }
                txtMaTran.Text = string.Empty;
                txtKetQua.Text = string.Empty;
                n_Point_Dinh = 0;
                duong_Dan = "";
                pbBang.Controls.Clear();
                pbBang.Invalidate();
                cbxChucNang.SelectedIndex = -1;
                cbxDinhBatDau.DataSource = null;
                cbxDinhKetThuc.DataSource = null;
                pbBang.Refresh();
                btnDuyet.Text = "Duyệt";
                txtDuongDan.Text = String.Empty;
            }
        }

        private void btnThemCanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            int DinhDau = 0, DinhCuoi = 0;
            if (kiem_Tra_Do_Thi_Vo_Huong())
            {
                if (cbxDinhBatDau.Text != String.Empty && cbxDinhKetThuc.Text != String.Empty)
                {
                    DinhDau = int.Parse(cbxDinhBatDau.Text);
                    DinhCuoi = int.Parse(cbxDinhKetThuc.Text);
                    if (DinhCuoi == DinhDau)
                    {
                        MessageBox.Show("Bạn nhập sai rồi. Cạnh đã bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        maTran[DinhDau, DinhCuoi] = 1;
                        maTran[DinhCuoi, DinhDau] = 1;
                    }
                }
            }
            else
            {
                if (cbxDinhBatDau.Text != String.Empty && cbxDinhKetThuc.Text != String.Empty)
                {
                    DinhDau = int.Parse(cbxDinhBatDau.Text);
                    DinhCuoi = int.Parse(cbxDinhKetThuc.Text);
                    if (DinhCuoi == DinhDau)
                    {
                        MessageBox.Show("Bạn nhập sai rồi. Cạnh đã bị trùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else maTran[DinhDau, DinhCuoi] = 1;
                    //maTran[DinhCuoi, DinhDau] = 1;
                }
            }
            pbBang.Refresh();
        }
        private void cbxChucNang_SelectedValueChanged(object sender, EventArgs e)
        {
            btnDuyet.Text = cbxChucNang.Text;
            pbBang.Controls.Clear();
            pbBang.Invalidate();
            pbBang.Refresh();
        }
        void TaoViTriDinh(int dem)
        {
            Random rnd = new Random();
            int randomX, randomY;
            while (true)
            {
                randomX = rnd.Next(12, 450);
                randomY = rnd.Next(20, 340);
                if (!KTKhoangCachDinh(randomX, randomY))// để không bị đè lên
                {
                    point_Dinh[dem] = new Point(randomX, randomY);
                    break;
                }
            }
        }
        private void btnThemDinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            for (int i = 0; i <= n_Point_Dinh; i++)
            {
                maTran[n_Point_Dinh, i] = 0;
                maTran[i, n_Point_Dinh] = 0;
            }
            TaoViTriDinh(n_Point_Dinh);
            n_Point_Dinh++;
            pbBang.Refresh();
            LoadComBoBoxDinhKetThuc();
            LoadComBoBoxDinhBatDau();
        }

        private void btnXoaCanh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            string str = "";
            string dinhDau_Str = "";
            string dinhCuoi_Str = "";
            int dinhDau = 0, dinhCuoi = 0;
            foreach (string item in lbDSCanh.SelectedItems)
            {
                str = item;
            }
            if (str != "")
            {
                int dem = 1;
                for (int i = 0; i < str.Length; ++i)
                {
                    if (str[i] == '-')
                    {
                        ++dem;
                        continue;
                    }
                    if (dem == 1) dinhDau_Str += str[i];
                    if (dem == 2) dinhCuoi_Str += str[i];
                }
                bool check_DinhDau = int.TryParse(dinhDau_Str, out dinhDau);
                bool check_DinhCuoi = int.TryParse(dinhCuoi_Str, out dinhCuoi);
            }
            if (kiem_Tra_Do_Thi_Vo_Huong())
            {
                maTran[dinhDau, dinhCuoi] = 0;
                maTran[dinhCuoi, dinhDau] = 0;
            }
            else
            {
                maTran[dinhDau, dinhCuoi] = 0;
            }
            pbBang.Refresh();
        }

        private void btnXoaDinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            int index = -1;
            string str = "";
            foreach (string item in lbDSDinh.SelectedItems)
            {
                str = item;
            }
            index = lbDSDinh.Items.IndexOf(str);
            lbDSDinh.Items.Remove(str);
            if (index != -1)
            {
                for (int i = index; i < n_Point_Dinh - 1; i++)
                {
                    point_Dinh[i] = point_Dinh[i + 1];
                }

                for (int i = index; i < n_Point_Dinh; i++)
                {
                    for (int j = 0; j < n_Point_Dinh; j++)
                    {
                        if (i != j)
                        {
                            maTran[i, j] = maTran[i + 1, j];
                            maTran[j, i] = maTran[j, i + 1];
                        }
                    }
                }
                n_Point_Dinh--;
                pbBang.Refresh();
            }
            LoadComBoBoxDinhBatDau();
            LoadComBoBoxDinhKetThuc();
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Text Document File (*.txt)|*.txt|All File (*.*)|*.*" })
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string Mtran = string.Empty;
                    for (int i = 0; i < n_Point_Dinh; i++)
                    {
                        for (int j = 0; j < n_Point_Dinh; j++)
                        {
                            Mtran += maTran[i, j] + " ";
                        }
                        Mtran += Environment.NewLine;
                    }
                    StreamWriter stream = new StreamWriter(saveFileDialog.FileName);
                    stream.WriteLine(n_Point_Dinh.ToString());
                    stream.WriteLine(Mtran);
                    stream.Close();
                    MessageBox.Show("Bạn đã lưu File thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnTaoMaTran_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            FormTaoMaTran tmt = new FormTaoMaTran();
            tmt.ShowDialog();
            n_Point_Dinh = tmt.sodinh;
            maTran = tmt.matran;
            txtMaTran.Text = n_Point_Dinh.ToString() + "\r\n";
            for (int i = 0; i < n_Point_Dinh; ++i)
            {
                for (int j = 0; j < n_Point_Dinh; ++j)
                {
                    if (j != 0) txtMaTran.Text += " ";
                    txtMaTran.Text += maTran[i, j].ToString();
                }
                if (i != n_Point_Dinh - 1) txtMaTran.Text += "\r\n";
            }
        }
      
    }
}
