using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class Histogram_RGB : Form
    {
        public Histogram_RGB()
        {
            InitializeComponent();
        }
        public void Histogram(Bitmap source)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            int[] R_pixel = new int[256];
            int[] G_pixel = new int[256];
            int[] B_pixel = new int[256];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    //Get pixel color 
                    Color c = source.GetPixel(x, y);
                    R_pixel[c.R] += 1;
                    G_pixel[c.G] += 1;
                    B_pixel[c.B] += 1;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                chart1.Series[0].Points.AddXY(i, R_pixel[i]);
                chart1.Series[1].Points.AddXY(i, G_pixel[i]);
                chart1.Series[2].Points.AddXY(i, B_pixel[i]);
            }
        }
    }
}
