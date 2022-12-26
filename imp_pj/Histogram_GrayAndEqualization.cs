using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imp_pj
{
    public partial class Histogram_GrayAndEqualization : Form
    {
        public Histogram_GrayAndEqualization()
        {
            InitializeComponent();
        }
        public void Histogram(Bitmap source)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            int[] pixel = new int[256];
            double[] pixel_rate = new double[256];
            double[] CDF = new double[256];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    //Get pixel color 
                    Color c = source.GetPixel(x, y);
                    //input is gray level
                    if(c.R == c.G && c.R == c.B && c.G == c.B)
                    {
                        int grayNum = c.R;
                        pixel[grayNum] += 1;
                        pixel_rate[grayNum] += 1;
                    }
                    //input is RGB
                    //前處理轉灰
                    else
                    {
                        Bitmap graylevel;
                        Gray RGBToGray = new Gray();
                        graylevel = RGBToGray.RGBtoGray_average(source);
                        Histogram(graylevel);
                    }
                }
            }
            for (int i = 0; i < 256; i++)
            {
                chart1.Series[0].Points.AddXY(i, pixel[i]);
                double value = pixel_rate[i];
                //rate = value / size
                double rate = value / (source.Height * source.Width * 1.0);
                pixel_rate[i] = rate;
                //CDF
                if (i == 0)
                {
                    CDF[i + 1] = pixel_rate[i];
                }
                else
                {
                    CDF[i] = CDF[i - 1] + pixel_rate[i];
                }
                chart2.Series[0].Points.AddXY(i, CDF[i]);
            }
        }
        //獲得灰階圖片各Gray level的機率，回傳array。
        public static double[] Return_PixelRate(Bitmap source)
        {
            double[] pixel_rate = new double[256];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    //Get pixel color 
                    Color c = source.GetPixel(x, y);
                    //input is gray level
                    if (c.R == c.G && c.R == c.B && c.G == c.B)
                    {
                        int grayNum = c.R;
                        pixel_rate[grayNum] += 1;
                    }
                }
            }
            //0~255個別除以總量
            for (int i = 0; i < 256; i++)
            {
                double value = pixel_rate[i];
                //rate = value / size
                double rate = value / (source.Height * source.Width * 1.0);
                pixel_rate[i] = rate;
            }
            return pixel_rate;
        }
        public static double[] Return_RGBPixelRate(Bitmap source)
        {
            double[] pixel_rate = new double[256];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    //Get pixel color 
                    Color c = source.GetPixel(x, y);
                    //input is gray level

                    pixel_rate[c.R] += 1;
                    pixel_rate[c.G] += 1;
                    pixel_rate[c.B] += 1;
                }
            }
            //0~255個別除以總量
            for (int i = 0; i < 256; i++)
            {
                //Console.WriteLine(i + ": " + pixel_rate[i]);
                double value = pixel_rate[i];
                //rate = value / size
                double rate = value / (source.Height * source.Width * 3.0);
                pixel_rate[i] = rate;
            }
            return pixel_rate;
        }
        //for Otsu's use
        public int[] Return_histogram(Bitmap source)
        {
            int[] pixel = new int[256];
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    //Get pixel color 
                    Color c = source.GetPixel(x, y);
                    //input is gray level
                    if (c.R == c.G && c.R == c.B && c.G == c.B)
                    {
                        int grayNum = c.R;
                        pixel[grayNum] += 1;
                    }
                }
            }
            return pixel;
        }
        //灰階直方圖均衡化
        //傳入灰階圖片和灰階圖片各灰度的機率。
        public static Bitmap Equalization(Bitmap grayImage, double[] density)
        {
            for (int j = 0; j < grayImage.Height; j++)
            {
                for (int i = 0; i < grayImage.Width; i++)
                {
                    double densitySum = 0;
                    Color value = grayImage.GetPixel(i, j);
                    //累積機率 -> 不為1(gray)
                    for (int k = 0; k <= value.R; k++)
                    {    
                        densitySum += density[k];
                    }
                    //乘上255 -> 灰度分布均匀
                    byte s = (byte)Math.Round(255 * densitySum);
                    Color newValue = Color.FromArgb(s, s, s);
                    grayImage.SetPixel(i, j, newValue);
                }
            }
            return grayImage;
        }
    }
}
