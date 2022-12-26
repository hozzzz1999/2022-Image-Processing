using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace imp_pj
{
    internal class Alpha
    {
        public Bitmap alphaImage(Bitmap frontImg, Bitmap behindImg, double alpha)
        {
            int height = frontImg.Height;
            int width = frontImg.Width;
            Bitmap aImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //alpha值越小 前景占比越多
                    //((1-a)/100)front + (a/100)behind
                    int newR = (int)Math.Round((1 - (alpha / 100.0)) * frontImg.GetPixel(x, y).R + (alpha / 100.0) * behindImg.GetPixel(x, y).R);
                    int newG = (int)Math.Round((1 - (alpha / 100.0)) * frontImg.GetPixel(x, y).G + (alpha / 100.0) * behindImg.GetPixel(x, y).G);
                    int newB = (int)Math.Round((1 - (alpha / 100.0)) * frontImg.GetPixel(x, y).B + (alpha / 100.0) * behindImg.GetPixel(x, y).B);
                    Color RGB = Color.FromArgb(newR, newG, newB);
                    aImage.SetPixel(x, y, RGB);
                }
            }
            return aImage;
        }
    }
}
