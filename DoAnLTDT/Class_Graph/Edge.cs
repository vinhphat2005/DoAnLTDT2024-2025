using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT.Class_Graph
{
    class Edge
    {

        public int x, y, z, t;
        public bool SoSanhEdgeVH(Edge a)
        {
            if ((this.x == a.x && this.y == a.y && this.z == a.z && this.t == a.t) || (this.z == a.x && this.t == a.y && this.x == a.z && this.y == a.t))
            {
                return true;
            }
            else return false;
        }
        public bool SoSanhEdgeCH(Edge b)
        {
            if (this.x == b.x && this.y == b.y && this.z == b.z && this.t == b.t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMatrixCH(NodeGraph a, NodeGraph b)
        {
            if (this.x == a.x && this.y == a.y && this.z == b.x && this.t == b.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMatrixVH(NodeGraph a, NodeGraph b)
        {
            if (this.x == a.x && this.y == a.y && this.z == b.x && this.t == b.y || this.x == b.x && this.y == b.y && this.z == a.x && this.t == a.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckEdge()
        {
            return this.x != 0 && this.y != 0 && this.z != 0 && this.t != 0;
        }
    }
}
