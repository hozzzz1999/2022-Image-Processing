using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace imp_pj
{
    internal class Negative
    {
        public static Bitmap RGB_Inverse(Bitmap source)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    // 取得每一個 pixel
                    Color pixel = source.GetPixel(i, j);
                    // 負片效果 將其反轉(255-pixel)
                    Color newColor = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    source.SetPixel(i, j, newColor);
                }
            }
            return source;
        }
        public static Bitmap Gray_Inverse(Bitmap source)
        {
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    // 取得每一個 pixel
                    Color pixel = source.GetPixel(i, j);
                    int gray = (int)(
                        (source.GetPixel(i, j).R) * 0.299 +
                        (source.GetPixel(i, j).G) * 0.587 +
                        (source.GetPixel(i, j).B) * 0.114) / 3;
                    // 負片效果 將其反轉(255-gray)
                    Color newColor = Color.FromArgb(255 - gray, 255 - gray, 255 - gray);
                    source.SetPixel(i, j, newColor);
                }
            }
            return source;
        }
    }
}
