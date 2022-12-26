using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class contrastPreset : Form
    {
        public contrastPreset(Bitmap origin)
        {
            InitializeComponent();
            pictureBox_source.Image = origin;
            preset(origin);
        }
        public Bitmap preset(Bitmap image)
        {
            Bitmap result = new Bitmap(image);
            Color color;
            int pixel;
            double[] rate = new double[256];
            double total = 0;
            int start = 0, end = 0;
            rate = Histogram_GrayAndEqualization.Return_PixelRate(image);
            for (int i = 0; i <= 255; i++)
            {
                total += rate[i];
                if (total < 0.05)
                {
                    start = i;
                    continue;
                }
                if (total > 0.95)
                {
                    end = i;
                    break;
                }
            }
            Console.WriteLine("start, end: " + start + ", " + end);
            for (int j = 0; j < image.Height; j++)
            {
                for(int i = 0; i < image.Width; i++)
                {
                    color = image.GetPixel(i, j);
                    if (color.R > end)
                    {
                        result.SetPixel(i, j, Color.White);
                    }
                    else if(color.R < start)
                    {
                        result.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        //for star.pcx
                        if (start == 254)
                            start = 0;
                        pixel = 255 / (end - start);
                        pixel *= color.R;
                        result.SetPixel(i, j, Color.FromArgb(pixel, pixel, pixel));
                    }
                }
            }
            pictureBox_result.Image = result;
            return result;
        }
    }
}
