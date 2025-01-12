using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT.Class_Graph
{
    class Graph
    {
        public int sodinh;
        public int nTPLT;
        private int[,] a = new int[100, 100];
        private int[] LuuVetDFS = new int[100];
        private int[] LuuVetBFS = new int[100];
        public int[] visited = new int[100];
        public List<int> kqDFS = new List<int> { };
        public List<int> kqBFS = new List<int> { };
        #region ReadGraph
        public void readGRAPH(int[,] array, int sodinh)
        {

            this.sodinh = sodinh;
            for (int i = 0; i < this.sodinh; i++)
            {
                for (int j = 0; j < this.sodinh; j++)
                {
                    this.a[i, j] = array[i, j];
                }
            }
        }
        #endregion
        #region DFS
        public void DFS(int s)
        {
            Stack<int> st = new Stack<int>();
            st.Push(s);
            while (st.Count() > 0)
            {
                int xet = st.Peek();
                st.Pop();
                visited[xet] = 1;
                for (int i = sodinh - 1; i >= 0; i--)
                {
                    if (visited[i] == 0 && a[xet, i] != 0)
                    {
                        LuuVetDFS[i] = xet;
                        st.Push(i);
                    }
                }
            }
        }
        public void duyetDFS(int s, int f)
        {
            //Khởi tạo giá trị ban đầu, tất cả các đỉnh chưa đuợc duyệt và chưa lưu vết
            for (int i = 0; i < this.sodinh; i++)
            {
                this.visited[i] = 0;
                this.LuuVetDFS[i] = -1;
            }
            //Gọi hàm DFS
            this.DFS(s);
            if (this.visited[f] == 1)
            {
                //In ket qua
                int j = f;
                while (j != s)
                {
                    kqDFS.Add(j);
                    j = this.LuuVetDFS[j];
                }
                kqDFS.Add(s);
            }
        }
        #endregion
        #region BFS
        public void BFS(int s)
        {
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(s);
            while (Q.Count > 0)
            {
                s = Q.Dequeue();
                this.visited[s] = 1;
                for (int i = 0; i < this.sodinh; i++)
                    if (this.visited[i] == 0 && this.a[s, i] != 0)
                    {
                        Q.Enqueue(i);
                        this.LuuVetBFS[i] = s;
                    }
            }
        }
        public void duyetBFS(int s, int f)
        {
            //Khởi tạo giá trị ban đầu, tất cả các địh chư đuợc duyệt và chưa lưu vết
            for (int i = 0; i < this.sodinh; i++)
            {
                this.visited[i] = 0;
                this.LuuVetBFS[i] = -1;
            }
            //Gọi hàm BFS
            BFS(s);

            if (this.visited[f] == 1)
            {
                //In ket qua
                int j = f;
                while (j != s)
                {
                    kqBFS.Add(j);
                    j = this.LuuVetBFS[j];
                }
                kqBFS.Add(s);
            }
        }
        #endregion
        #region XetLienThong
        public void visitedLT(int s, int nLabel)
        {
            visited[s] = nLabel;
            for (int j = 0; j < sodinh; j++)
            {
                if (visited[j] == 0 && a[s, j] != 0)
                {
                    visitedLT(j, nLabel);
                }
            }
        }
        public void xetLT()
        {
            for (int i = 0; i < this.sodinh; i++)
                this.visited[i] = 0;
            // đặt số miền liên thông ban đầu la 0
            this.nTPLT = 0;

            // dùng một vòng for i để tìm đỉnh chưa xét, gọi hàm duyệt cho đỉnh này
            for (int i = 0; i < this.sodinh; i++)
                if (this.visited[i] == 0)
                {
                    this.nTPLT++;
                    // nSoMienLienThong là nhãn sẽ gán cho các đỉnh trong lần duyệt này
                    this.visitedLT(i, this.nTPLT);
                }
        }
        public string[] thanhPhanLienThong()
        {
            xetLT();
            string[] TPLT = new string[this.nTPLT + 1];
            TPLT[0] = this.nTPLT.ToString();
            for (int i = 1; i <= TPLT.Length; i++)
            {
                // xét tất cả các đỉnh, nếu có nhãn trùng với nMienLienThong, in ra
                for (int j = 0; j < this.sodinh; j++)
                {
                    if (visited[j] == i)
                    {
                        TPLT[i] += j.ToString() + " ";
                    }
                }
            }
            return TPLT;
        }
        #endregion
    }
}
