using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Zoom
    {
        //鄰近值放大和縮小
        public static Bitmap zoomInImageNear(Bitmap Image, double times)
        {
            //原圖size
            int width = Image.Width;
            int height = Image.Height;
            //新圖size
            int new_width = (int)Math.Round(width * times);
            int new_height = (int)Math.Round(height * times);
            Bitmap newBitmap = new Bitmap(new_width, new_height, PixelFormat.Format24bppRgb);

            for (int y1 = 0; y1 < new_height; y1++)
            {
                for (int x1 = 0; x1 < new_width; x1++)
                {
                    //和原圖哪個座標近，就取其Pixel值作為新Pixel值
                    //四捨五入 
                    int x = (int)Math.Round(x1 * (1 / times));
                    int y = (int)Math.Round(y1 * (1 / times));
                    //反向映射座標，若不在原圖内，直接取邊界當作其Pixel
                    if (x > (width - 1))
                    {
                        x = width - 1;
                    }
                    if (y > (height - 1))
                    {
                        y = height - 1;
                    }
                    newBitmap.SetPixel(x1, y1, Image.GetPixel(x, y));
                }
            }
            return newBitmap;
        }
        //雙線性內插放大和縮小
        public static Bitmap zoomInImageLine(Bitmap Image, double times)
        {
            //原圖size
            int width = Image.Width;
            int height = Image.Height;
            //新圖size
            int new_width = (int)Math.Round(width * times);
            int new_height = (int)Math.Round(height * times);
            Bitmap newBitmap = new Bitmap(new_width, new_height, PixelFormat.Format24bppRgb);

            for (int y1 = 0; y1 < new_height; y1++)
            {
                for (int x1 = 0; x1 < new_width; x1++)
                {
                    double x = x1 * (1 / times);
                    double y = y1 * (1 / times);

                    //反向映射座標在原圖内
                    if (x <= (width - 1) & y <= (height - 1))
                    {
                        Color RGB = new Color();

                        int a1 = (int)x;
                        int a2 = (int)Math.Ceiling(x);
                        int a3 = (int)x;
                        int a4 = (int)Math.Ceiling(x);
                        int b1 = (int)y;
                        int b2 = (int)y;
                        int b3 = (int)Math.Ceiling(y);
                        int b4 = (int)Math.Ceiling(y);

                        //鄰近四點
                        double W = x - a1;
                        double X = a2 - x;
                        double Y = y - b1;
                        double Z = b3 - y;
                        //對應回原圖是非整數座標->雙線性內插。
                        if (W != 0 & X != 0 & Y != 0 & Z != 0)
                        {
                            byte R1 = Image.GetPixel(a1, b1).R;
                            byte G1 = Image.GetPixel(a1, b1).G;
                            byte B1 = Image.GetPixel(a1, b1).B;
                            byte R2 = Image.GetPixel(a2, b2).R;
                            byte G2 = Image.GetPixel(a2, b2).G;
                            byte B2 = Image.GetPixel(a2, b2).B;

                            byte R3 = Image.GetPixel(a3, b3).R;
                            byte G3 = Image.GetPixel(a3, b3).G;
                            byte B3 = Image.GetPixel(a3, b3).B;
                            byte R4 = Image.GetPixel(a4, b4).R;
                            byte G4 = Image.GetPixel(a4, b4).G;
                            byte B4 = Image.GetPixel(a4, b4).B;

                            byte R = (byte)((R1 * X + R2 * W) * Z + (R3 * X + R4 * W) * Y);
                            byte G = (byte)((G1 * X + G2 * W) * Z + (G3 * X + G4 * W) * Y);
                            byte B = (byte)((B1 * X + B2 * W) * Z + (B3 * X + B4 * W) * Y);

                            RGB = Color.FromArgb(R, G, B);
                        }
                        //若對應回原圖是整數座標就直接取其Pixel
                        else
                        {
                            RGB = Image.GetPixel((int)Math.Round(x), (int)Math.Round(y));
                        }
                        newBitmap.SetPixel(x1, y1, RGB);
                    }
                    //反向映射座標，若不在原圖内，直接取邊界當作其Pixel
                    else
                    { 
                        int x2 = (int)Math.Round(x);
                        int y2 = (int)Math.Round(y);
                        if (x2 > (width - 1))
                        {
                            x2 = width - 1;
                        }
                        if (y2 > (height - 1))
                        {
                            y2 = height - 1;
                        }
                        newBitmap.SetPixel(x1, y1, Image.GetPixel(x2, y2));
                    }
                }
            }
            return newBitmap;
        }
    }
}
