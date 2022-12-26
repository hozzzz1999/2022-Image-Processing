using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace imp_pj
{
    public partial class Huffman_screen : Form
    {
        int[] pixels = new int[256];
        double[] rates = new double[256];
        string[] codes = new string[256];
        public Huffman_screen(Bitmap source, int[] p, double[] r, string[] c)
        {
            InitializeComponent();
            pictureBox1.Image = source;
            pixels = p;
            rates = r;
            codes = c;
            fill_data(source);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Huffman_screen_Load(object sender, EventArgs e)
        {
            
        }
        private void fill_data(Bitmap source)
        {
            string[] str;
            for (int i = 0; i < 256; i++)
            {
                if (rates[i] == 0 || codes[i] == null)
                {
                    continue;
                }
                else
                {
                    str = new[] { pixels[i].ToString(), rates[i].ToString(), codes[i].ToString() };
                    dataGridView1.Rows.Add(str);
                }
            }
            dataGridView1.Refresh();
        }

    }
}
