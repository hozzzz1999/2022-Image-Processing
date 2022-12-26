using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Rotation
    {
        //正向失真旋轉
        public Bitmap rotateImageDis(Bitmap Image, double degree)
        {
            int Width = Image.Width;
            int Height = Image.Height;
            //四捨五入，求出旋轉後圖片大小。
            double Wt = (int)(Math.Abs(Width * Math.Cos(Math.PI * (degree / 180))) + Math.Abs(Height * Math.Sin(Math.PI * (degree / 180))) + 0.5);
            double Lt = (int)(Math.Abs(Width * Math.Sin(Math.PI * (degree / 180))) + Math.Abs(Height * Math.Cos(Math.PI * (degree / 180))) + 0.5);
            //旋轉後 新圖的長寬更正
            Bitmap rotateImageData = new Bitmap((int)Wt, (int)Lt, PixelFormat.Format24bppRgb);

            //x、y即原圖座標，x_rotated、y_rotated即旋轉後座標。
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    //將原圖座標pixel對應過去新圖座標的pixel上
                    int x_rotated = (int)Math.Round(x * Math.Cos(Math.PI * (degree / 180)) - y * Math.Sin(Math.PI * (degree / 180)) - (Width - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) + (Height - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) + (Wt - 1) / 2.0);
                    int y_rotated = (int)Math.Round(x * Math.Sin(Math.PI * (degree / 180)) + y * Math.Cos(Math.PI * (degree / 180)) - (Width - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) - (Height - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) + (Lt - 1) / 2.0);
                    //新圖pixel更新
                    rotateImageData.SetPixel(x_rotated, y_rotated, Image.GetPixel(x, y));
                }
            }
            return rotateImageData;
        }
        //反向double linear interpolation 無失真
        public Bitmap rotateImageOri(Bitmap Image, double degree)
        {
            int Width = Image.Width;
            int Height = Image.Height;
            //四捨五入，求出旋轉後圖片大小。
            double Wt = (int)(Math.Abs(Width * Math.Cos(Math.PI * (degree / 180))) + Math.Abs(Height * Math.Sin(Math.PI * (degree / 180))) + 0.5);
            double Lt = (int)(Math.Abs(Width * Math.Sin(Math.PI * (degree / 180))) + Math.Abs(Height * Math.Cos(Math.PI * (degree / 180))) + 0.5);
            Bitmap rotateImageData = new Bitmap((int)Wt, (int)Lt, PixelFormat.Format24bppRgb);

            //x_BeforeRotate、y_BeforeRotate即旋轉後座標，x、y即原圖座標。
            for (int y_BeforeRotate = 0; y_BeforeRotate < Lt; y_BeforeRotate++)
            {
                for (int x_BeforeRotate = 0; x_BeforeRotate < Wt; x_BeforeRotate++)
                {
                    //先求出旋轉後的圖片大小
                    double x = x_BeforeRotate * Math.Cos(Math.PI * (degree / 180)) + y_BeforeRotate * Math.Sin(Math.PI * (degree / 180)) - (Wt - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) - (Lt - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) + (Width - 1) / 2.0;
                    double y = -x_BeforeRotate * Math.Sin(Math.PI * (degree / 180)) + y_BeforeRotate * Math.Cos(Math.PI * (degree / 180)) + (Wt - 1) / 2.0 * Math.Sin(Math.PI * (degree / 180)) - (Lt - 1) / 2.0 * Math.Cos(Math.PI * (degree / 180)) + (Height - 1) / 2.0;
                    //Console.WriteLine(x + "  " + y);
                    //對應回原圖
                    //在(0,0),(1,0)之間：f(x,0) = [f(0,0) * (1-x) / 1] + [f(1,0) * (x-0) / 1]
                    //在(0,1),(1,1)之間：f(x,1) = [f(0,1) * (1-x) / 1] + [f(1,1) * (x-0) / 1]
                    //有了f(x,0),f(x,1) 後進行 y方向上的線性插值法：f(x,y) = [f(x,0) * (1-y) / 1] + [f(x,1) * (y-0) / 1]
                    //x, y 的判斷x >= 0和y >= 0 會導致 轉90,180,270,360會有一條黑邊 待精度修正
                    if (x >= 0 && x <= (Width - 1) && y >= 0 && y <= (Height - 1))
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

                        double xa13 = x - a1;
                        double xa24 = a2 - x;
                        double yb12 = y - b1;
                        double yb34 = b3 - y;

                        //對應回原圖是非整數座標，雙線性插值。
                        if (xa13 != 0 & xa24 != 0 & yb12 != 0 & yb34 != 0)
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

                            byte R = (byte)((R1 * xa24 + R2 * xa13) * yb34 + (R3 * xa24 + R4 * xa13) * yb12);
                            byte G = (byte)((G1 * xa24 + G2 * xa13) * yb34 + (G3 * xa24 + G4 * xa13) * yb12);
                            byte B = (byte)((B1 * xa24 + B2 * xa13) * yb34 + (B3 * xa24 + B4 * xa13) * yb12);

                            RGB = Color.FromArgb(R, G, B);
                        }
                        //對應回原圖是整數座標,直接取Pixel 和set回去新圖
                        else
                        {
                            RGB = Image.GetPixel(a1, b1);
                        }
                        rotateImageData.SetPixel(x_BeforeRotate, y_BeforeRotate, RGB);
                    }
                }
            }
            return rotateImageData;
        }
    }
}
