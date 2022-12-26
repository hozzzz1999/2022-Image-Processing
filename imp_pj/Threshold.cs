using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace imp_pj
{
    public partial class Threshold : Form
    {
        Bitmap Source, Result;
        public Threshold(Bitmap image)
        {
            InitializeComponent();
            Source = image;
            pictureBox_Source.Image = Source;
        }
        //手動拉bar
        public Bitmap Thresholding(int T)
        {
            textBox_Threshing.Enabled = true;
            trackBar_Threshing.Enabled = true;
            Bitmap newBitmap = new Bitmap(Source.Width, Source.Height);
            Result = new Bitmap(Source.Width, Source.Height);
            for (int j = 0; j < Source.Height; j++)
            {
                for (int i = 0; i < Source.Width; i++)
                {
                    int oldGraylevel = Source.GetPixel(i, j).R;
                    //二值化 大於T值設白
                    if(oldGraylevel >= T)
                    {
                        newBitmap.SetPixel(i, j, Color.White);
                    }
                    //小於則設黑
                    else
                    {
                        newBitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }
            return newBitmap;
        }
        private void trackBar_Threshing_Scroll(object sender, EventArgs e)
        {
            label_mode.Text = "Manual Thresholding";
            int T = trackBar_Threshing.Value;
            textBox_Threshing.Text = trackBar_Threshing.Value.ToString();
            Result = Thresholding(T);
            pictureBox_Result.Image = Result;
        }
        //找到最好的Threshold
        //計算最小之變異數為T
        public static Bitmap Get_Otsu(Bitmap image)
        {
            Gray gray = new Gray();
            image = gray.RGBtoGray_average(image);
            //最佳二值化
            Threshold Threshold = new Threshold(image);
            Threshold.Thresholding_Otsu();
            image = (Bitmap)Threshold.pictureBox_Result.Image;
            return image;
        }
        public void Thresholding_Otsu()
        {
            Result = new Bitmap(Source.Width, Source.Height);
            //求各pixel之個數
            Histogram_GrayAndEqualization histo = new Histogram_GrayAndEqualization();
            int[] histogram = new int[256];
            histogram = histo.Return_histogram(Source);

            int Size = Source.Height * Source.Width;
            int threshold;
            //儲存差異集合
            double[] variances = new double[256];
            //T為0~255，最佳Threshold的擬定值
            for (int T = 0; T < histogram.Length; T++)
            {
                //T值左右兩個區域pixel個數
                double space1 = 0, space2 = 0;
                //兩個區域pixel值總和
                double total1 = 0, total2 = 0;
                //區域平均數
                double avg1 = 0, avg2 = 0;
                //區域權重
                double weight1 = 0, weight2 = 0;
                //區域1和2之變異數
                double variance1 = 0, variance2 = 0;
                //0~T-1之間pixel個數和pixel值總和
                for (int i = 0; i < T; i++)
                {
                    space1 += histogram[i];
                    //eg. pixel 5 有10個 總數需加10*5 50個
                    total1 += histogram[i] * i;
                }
                ////T~256之間pixel個數和pixel值總和
                for (int j = T; j < variances.Length; j++)
                {
                    space2 += histogram[j];
                    total2 += histogram[j] * j;
                }
                //占比 = 各空間 / Size
                weight1 = space1 / Size;
                weight2 = space2 / Size;
                //平均 = 範圍內Pixel總數 / 範圍
                if (space1 == 0) { avg1 = 0; }
                else avg1 = total1 / space1;
                if (space2 == 0) { avg2 = 0; }
                else avg2 = total2 / space2;
                //0 ~ T-1 的變異數
                //variance^2 = [(x1 - avg)^2 + (x2 - avg)^2 + ... + (xn - avg)^2] / n   (n=範圍)
                for (int i = 0; i < T; i++)
                {
                    variance1 += (Math.Pow((i - avg1), 2) * histogram[i]);
                }
                if(space1 == 0) { variance1 = 0; }
                else variance1 = variance1 / space1;
                //T ~ 255 的變異數
                for (int j = T; j < 256; j++)
                {
                    variance2 += (Math.Pow((j - avg2), 2) * histogram[j]);
                }
                if (space2 == 0) { variance2 = 0; }
                else variance2 = variance2 / space2;
                //Otsu's formula w1*v1^2 + w2*v2^2 (v1^2 = variance1, v2^2 = variance2)
                variances[T] = weight1 * variance1 + weight2 * variance2;
            }
            //找到最小的那個gray level，就是最佳的閥值(T)
            double min = variances[0];
            threshold = 0;
            for (int i = 1; i < variances.Length; i++)
            {
                if (variances[i] < min)
                {
                    min = variances[i];
                    threshold = i;
                }
            }
            label_mode.Text = "Ostu's Thresholding";
            Result = Thresholding(threshold);
            pictureBox_Result.Image = Result;
            textBox_Threshing.Text = threshold.ToString();
            trackBar_Threshing.Value = threshold;
            textBox_Threshing.Enabled = false;
            trackBar_Threshing.Enabled = false;
        }
    }
}
