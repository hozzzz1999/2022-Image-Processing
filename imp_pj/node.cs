using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    public class Node
    {
        private double weight;
        private int lChild;
        private int rChild;
        private int index;
        private int pixel;
        private string code;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int LChild
        {
            get { return this.lChild; }
            set { lChild = value; }
        }

        public int RChild
        {
            get { return this.rChild; }
            set { rChild = value; }
        }

        public int Index
        {
            get { return this.index; }
            set { index = value; }
        }
        public int Pixel
        {
            get { return this.index; }
            set { pixel = value; }
        }
        public string Code
        {
            get { return this.code; }
            set { code = value; }
        }

        public Node()
        {
            weight = 0;
            lChild = -1;
            rChild = -1;
            index = -1;
            pixel = -1;
            code = null;
        }

        public Node(double w, int lc, int rc, int i, int p, string s)
        {
            weight = w;
            lChild = lc;
            rChild = rc;
            index = i;
            pixel = p;
            code = s;
        }
    }
}
