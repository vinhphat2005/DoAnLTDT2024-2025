using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTDT.Class_Graph
{
    internal class NodeGraph
    {
        public int x;
        public int y;
        public bool SoSanhNodeVH(Edge a)
        {
            if ((this.x == a.x && this.y == a.y) || (this.x == a.z && this.y == a.t))
            {
                return true;
            }
            else return false;
        }
        public bool SoSanhNode(NodeGraph a)
        {
            if (this.x == a.x && this.y == a.y)
            {
                return true;
            }
            else return false;
        }
    }

}

