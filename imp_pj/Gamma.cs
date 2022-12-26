using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace imp_pj
{
    public partial class Gamma : Form
    {
        public Gamma(Bitmap source)
        {
            InitializeComponent();
            gamma(source);
            pictureBox_ori.Image = source;
        }
        
        private void gamma(Bitmap image)
        {
            double gamma1 = 0.1;
            double gamma2 = 0.2;
            double gamma3 = 0.4;
            double gamma5 = 2.5;
            double gamma6 = 5.0;
            double gamma7 = 10.0;
            Bitmap gamma_img_0 = new Bitmap(image);
            Bitmap gamma_img_1 = new Bitmap(image);
            Bitmap gamma_img_2 = new Bitmap(image);
            Bitmap gamma_img_3 = new Bitmap(image);
            Bitmap gamma_img_4 = new Bitmap(image);
            Bitmap gamma_img_5 = new Bitmap(image);
            for (int j = 0; j < image.Height; j++)
            {
                for (int i = 0; i < image.Width; i++)
                {
                    Color color1 = image.GetPixel(i, j);
                    double r = color1.R / 255.0;
                    double g = color1.G / 255.0;
                    double b = color1.B / 255.0;

                    int R1 = Convert.ToInt32(Math.Pow(r, gamma1) * 255.0f);
                    int G1 = Convert.ToInt32(Math.Pow(g, gamma1) * 255.0f);
                    int B1 = Convert.ToInt32(Math.Pow(b, gamma1) * 255.0f);
                    gamma_img_0.SetPixel(i, j, Color.FromArgb(R1, G1, B1));


                    int R2 = Convert.ToInt32(Math.Pow(r, gamma2) * 255.0f);
                    int G2 = Convert.ToInt32(Math.Pow(g, gamma2) * 255.0f);
                    int B2 = Convert.ToInt32(Math.Pow(b, gamma2) * 255.0f);
                    gamma_img_1.SetPixel(i, j, Color.FromArgb(R2, G2, B2));

                    int R3 = Convert.ToInt32(Math.Pow(r, gamma3) * 255.0f);
                    int G3 = Convert.ToInt32(Math.Pow(g, gamma3) * 255.0f);
                    int B3 = Convert.ToInt32(Math.Pow(b, gamma3) * 255.0f);
                    gamma_img_2.SetPixel(i, j, Color.FromArgb(R3, G3, B3));

                    int R4 = Convert.ToInt32(Math.Pow(r, gamma5) * 255.0f);
                    int G4 = Convert.ToInt32(Math.Pow(g, gamma5) * 255.0f);
                    int B4 = Convert.ToInt32(Math.Pow(b, gamma5) * 255.0f);
                    gamma_img_3.SetPixel(i, j, Color.FromArgb(R4, G4, B4));

                    int R5 = Convert.ToInt32(Math.Pow(r, gamma6) * 255.0f);
                    int G5 = Convert.ToInt32(Math.Pow(g, gamma6) * 255.0f);
                    int B5 = Convert.ToInt32(Math.Pow(b, gamma6) * 255.0f);
                    gamma_img_4.SetPixel(i, j, Color.FromArgb(R5, G5, B5));

                    int R6 = Convert.ToInt32(Math.Pow(r, gamma7) * 255.0f);
                    int G6 = Convert.ToInt32(Math.Pow(g, gamma7) * 255.0f);
                    int B6 = Convert.ToInt32(Math.Pow(b, gamma7) * 255.0f);
                    gamma_img_5.SetPixel(i, j, Color.FromArgb(R6, G6, B6));
                }
            }
            pictureBox01.Image = gamma_img_0;
            pictureBox02.Image = gamma_img_1;
            pictureBox04.Image = gamma_img_2;
            pictureBox25.Image = gamma_img_3;
            pictureBox5.Image = gamma_img_4;
            pictureBox10.Image = gamma_img_5;
        }


    }
}
