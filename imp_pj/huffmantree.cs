using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace imp_pj
{
    public class HuffmanTree
    {
        private List<Node> _tmp;
        private List<Node> _nodes;
        int leaf_count = 0;
        public HuffmanTree(double[] weights)
        {
            if (weights.Length < 2)
            {
                throw new Exception("leafs need to be > 2");
            }

            int n = weights.Length;

            //Array.Sort(weights);

            // build leaf
            List<Node> lstLeafs = new List<Node>(n);
            for (int i = 0; i < n; i++)
            {
                //大於0才編碼
                if(weights[i] > 0)
                {
                    var node = new Node();
                    node.Weight = weights[i];
                    node.Index = i;
                    node.Pixel = i;
                    lstLeafs.Add(node);
                }
            }
            leaf_count = lstLeafs.Count;
            lstLeafs.Sort(delegate (Node x, Node y) {
                return x.Weight.CompareTo(y.Weight);
            });


            //tmp container
            _tmp = new List<Node>(2 * n - 1);

            //all container
            _nodes = new List<Node>(_tmp.Capacity);

            _tmp.AddRange(lstLeafs);
            _nodes.AddRange(_tmp);
            //Console.WriteLine("Count: " + _nodes.Count);
            //Coding(_nodes[_nodes.Count - 1]);
        }
        string[] pixel_decode = new string[256];
        string current = null;
        int counter_len = 0;
        public void Coding(Node node)
        {
            //Console.WriteLine("index: " + node.Index);
            if (node.LChild != -1 && node.RChild != -1)
            {
                for (int i = 0; i < _nodes.Count; i++)
                {
                    if (node.LChild == _nodes[i].Index)
                    {
                        current = current + "0";
                        Console.WriteLine("current: " + current);
                        Coding(_nodes[i]);
                        current = current.Substring(0 , current.Length - 1);
                        
                    }
                }
                for (int j = 0; j < _nodes.Count; j++)
                {
                    if (node.RChild == _nodes[j].Index)
                    {
                        current = current + "1";
                        Console.WriteLine("current: " + current);
                        Coding(_nodes[j]);
                        current = current.Substring(0, current.Length - 1);
                    }
                }
            }
            //leaf
            else
            {
                for(int i = 0; i < _nodes.Count; i++)
                {
                    if(node.Index == _nodes[i].Index)
                    {
                        Console.WriteLine("index: " + node.Index + "leaf: " + current);
                        _nodes[i].Code = current;
                    }
                }
                //_nodes[node.Index - 1].Code = current;
                //pixel_decode[node.Index - 1] = current;
                //current = current.Substring(0, current.Length - 1);
            }
        }
        public string[] huffmancode()
        {
            for(int i = 0; i < _nodes.Count; i++)
            {
                
                if (_nodes[i].Code == null)
                {
                    _nodes[i].Code = "X";
                }
                pixel_decode[i] = _nodes[i].Code;
                Console.WriteLine("i: " + i + "str: " + pixel_decode[i]);
            }
            
            return pixel_decode;
        }

        // build tree
        public void Create()
        {
            while (this._tmp.Count > 1)
            {
                var tmp = new Node(this._tmp[0].Weight + this._tmp[1].Weight, _tmp[0].Index, _tmp[1].Index, Math.Max(this._tmp.Max(c => c.Index), 255) + 1, -1, null);
                this._tmp.Add(tmp);
                this._nodes.Add(tmp);

                //删除已经处理过的二个节点
                this._tmp.RemoveAt(0);
                this._tmp.RemoveAt(0);


                //重新按权重值从小到大排序
                this._tmp = this._tmp.OrderBy(c => c.Weight).ToList();
            }
        }

        // output
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //Console.WriteLine("Count: " + _nodes.Count);
            for (int i = 0; i < _nodes.Count; i++)
            {
                var n = _nodes[i];
                sb.AppendLine("index:" + n.Index.ToString() + ", weight:" + n.Weight.ToString().PadLeft(2, ' ') + ", lChild_index:" + n.LChild.ToString().PadLeft(2, ' ') + ", rChild_index:" + n.RChild.ToString().PadLeft(2, ' ') + ", Pixel:" +  n.Pixel.ToString().PadLeft(2, ' '));
            }
            return sb.ToString();
        }
        public void printNode()
        {
            Coding(_nodes[_nodes.Count - 1]);
        }
    }
}
