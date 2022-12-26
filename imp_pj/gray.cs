using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imp_pj
{
    internal class Gray
    {
        public Bitmap RGBtoGray_formula(Bitmap source)
        {
            //帶入 Y' = 0.299 R' + 0.587 G' + 0.114 B'
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    int gray = (int)(
                        (source.GetPixel(x, y).R) * 0.299 +
                        (source.GetPixel(x, y).G) * 0.587 +
                        (source.GetPixel(x, y).B) * 0.114);
                    //Console.WriteLine(gray);
                    Color color = Color.FromArgb(gray, gray, gray);
                    source.SetPixel(x, y, color);
                }
            }
            return source;
        }
        public Bitmap RGBtoGray_average(Bitmap source)
        {
            //帶入 Y' = 0.299 R' + 0.587 G' + 0.114 B'
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    int gray = (
                        source.GetPixel(x, y).R +
                        source.GetPixel(x, y).G +
                        source.GetPixel(x, y).B) / 3;
                    //Console.WriteLine(gray);
                    Color color = Color.FromArgb(gray, gray, gray);
                    source.SetPixel(x, y, color);
                }
            }
            return source;
        }
    }
}
