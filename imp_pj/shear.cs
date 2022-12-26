using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Shear
    {
        public static Bitmap Xsharing(Bitmap bitmap, int n)
        {
            //拉寬
            int x = (bitmap.Width) + (bitmap.Height * n);
            int y = bitmap.Height;
            bool[,] color = new bool[x, y];
            Bitmap Xsharing = new Bitmap(x, y, PixelFormat.Format24bppRgb);

            for (int j = 0; j < bitmap.Height; j++)
            {
                for (int i = 0; i < bitmap.Width; i++)
                {
                    int shx = i + n * j;
                    int shy = j;
                    shy = bitmap.Height - 1 - shy;
                    Xsharing.SetPixel(shx, shy, bitmap.GetPixel(i, bitmap.Height - 1 - j));
                    color[shx, shy] = true;
                }
            }
            for (int ry = 0; ry < y; ry++)
            {
                for (int rx = 0; rx < x; rx++)
                {
                    //不在圖範圍內
                    if (!color[rx, ry])
                    {
                        Xsharing.SetPixel(rx, ry, Color.Transparent);
                    }
                }
            }
            return Xsharing;
        }
    }
}
